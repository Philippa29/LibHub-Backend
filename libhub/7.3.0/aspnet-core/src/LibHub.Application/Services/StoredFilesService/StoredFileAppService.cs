

using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using LibHub.Domain;

using LibHub.Services.StoredFilesService;
using LibHub.Domain.StoredFiles;
using LibHub.Services.Dtos;
using LibHub.Services.StoredFilesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LibHub.Helper;

namespace LibHub.Services.StoredFileService
{
    public class StoredFileAppService : ControllerBase, IStoredFileAppService
    {
        const string BASE_FILE_PATH = "App_Data/Images";

        private readonly IRepository<StoredFile, Guid> _storedFileRepository;
        private readonly IMapper _mapper;
        public StoredFileAppService(IRepository<StoredFile, Guid> storedFileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _storedFileRepository = storedFileRepository;
        }

        [HttpPost, Route("Upload")]
        [Consumes("multipart/form-data")]
        public async Task<StoredFile> CreateStoredFile([FromForm] StoredFileDto input)
        {
            if (!Utils.IsImage(input.File))
                throw new ArgumentException("The file is not a valid image.");

            var existingFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.FileName == input.File.FileName);

            if (existingFile != null)
            {
                // If a file with the same filename exists, return the existing file
                return existingFile;
            }
            else
            {
                var storedFile = _mapper.Map<StoredFile>(input);
                storedFile.FileType = input.File.ContentType;

                var filePath = $"{BASE_FILE_PATH}/{input.File.FileName}"; //png if it's an image

                using (var fileStream = input.File.OpenReadStream())
                {
                    await SaveFile(filePath, fileStream);
                }

                storedFile.FileName = input.File.FileName;
                storedFile.FileType = input.File.ContentType;

                return await _storedFileRepository.InsertAsync(storedFile);
            }
        }

        [HttpPut, Route("Update")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateStoredFile( [FromForm] StoredFileDto input)
        {
            // Retrieve the existing stored file from the database based on the provided GUID
            var existingStoredFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

            // Check if the file exists
            if (existingStoredFile == null)
            {
                // Handle the case where the file with the provided GUID does not exist
                return NotFound(); // Or return an appropriate error response
            }

            // Delete the old image file
            await DeleteOldFile(existingStoredFile);

            // Process the new image and save it to the appropriate location
            var newFilePath = await SaveFileForUpdate(input.File);

            // Update the properties of the existing stored file with the new information
            existingStoredFile.FileName = input.File.FileName;
            existingStoredFile.FileType = input.File.ContentType;
            // Update any other relevant properties as needed

            // Save the changes to the database
            await _storedFileRepository.UpdateAsync(existingStoredFile);

            // Return a success response
            return Ok(existingStoredFile); // Or return any other appropriate response
        }





        private async Task DeleteOldFile(StoredFile existingStoredFile)
        {
            // Construct the file path of the old image
            var oldFilePath = Path.Combine(BASE_FILE_PATH, existingStoredFile.FileName);

            // Delete the old image file if it exists
            if (System.IO.File.Exists(oldFilePath)) // Fully qualify System.IO.File
            {
                System.IO.File.Delete(oldFilePath); // Fully qualify System.IO.File
            }
        }

        private async Task<string> SaveFileForUpdate(IFormFile newImage)
        {
            if (!Utils.IsImage(newImage))
            {
                throw new ArgumentException("The file is not a valid image.");
            }

            //var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var fileName = newImage.FileName;
            var filePath = Path.Combine(BASE_FILE_PATH, fileName);

            using (var fileStream = newImage.OpenReadStream())
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fs);
            }

            return filePath;
        }

        private async Task SaveFile(string filePath, Stream stream)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetStoredFile(Guid id)
        {

            var storedFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (storedFile == null)
                //return Content("filename not present");
                throw new UserFriendlyException("File not found");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           BASE_FILE_PATH, storedFile.FileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
        {
            {".txt", "text/plain"},
            {".pdf", "application/pdf"},
            {".doc", "application/vnd.ms-word"},
            {".docx", "application/vnd.ms-word"},
            {".xls", "application/vnd.ms-excel"},
            {".png", "image/png"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".gif", "image/gif"},
            {".csv", "text/csv"}
        };
        }

    }
}