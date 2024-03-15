using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using LibHub.Domain.StoredFiles;
using LibHub.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace LibHub.Services.StoredFilesService
//{
//    public class StoredFileAppService : ControllerBase, IStoredFileAppService
//    {
//    //    const string BASE_FILE_PATH = "App_Data/Images";
//    //    private readonly IRepository<StoredFile, Guid> _storedFileRepository;
//    //    private readonly IMapper _mapper;
//    //    public StoredFileAppService(IRepository<StoredFile, Guid> storedFileRepository, IMapper mapper)
//    //    {
//    //        _mapper = mapper;
//    //        _storedFileRepository = storedFileRepository;
//    //    }

//    //    public async Task<StoredFile> CreateStoredFile([FromForm] StoredFileDto input)
//    //    {
//    //        //Validations
//    //        if (input.FileName == null || input.File.Length == 0)
//    //            throw new UserFriendlyException("The file is empty.");

//    //        if (!IsImage(input.File))
//    //            throw new ArgumentException("The file is not a valid image.");

//    //        var checkAvailability = await _storedFileRepository.FirstOrDefaultAsync(x => x.FileName == input.File.FileName);
//    //        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

//    //        var storedFile = _mapper.Map<StoredFile>(input);
//    //        storedFile.FileName = checkAvailability != null ? $"{timestamp}_{input.File.FileName}" : input.File.FileName;
//    //        storedFile.FileType = input.File.ContentType;

//    //        var filePath = $"{BASE_FILE_PATH}/{input.File.FileName}"; //png if it's an image

//    //        using (var fileStream = input.FileName.OpenReadStream())
//    //        {
//    //            await SaveFile(filePath, fileStream);
//    //            //return File(fileStream, "pdf", input.File.FileName);
//    //        }
//    //        return await _storedFileRepository.InsertAsync(storedFile);

//    //    }

//    //    private async Task SaveFile(string filePath, Stream stream)
//    //    {
//    //        using (var fs = new FileStream(filePath, FileMode.Create))
//    //        {
//    //            await stream.CopyToAsync(fs);
//    //        }
//    //    }

//    //    private bool IsImage(IFormFile file)
//    //    {
//    //        if (file.ContentType.ToLower() != "image/jpg" &&
//    //            file.ContentType.ToLower() != "image/jpeg" &&
//    //            file.ContentType.ToLower() != "image/pjpeg" &&
//    //            file.ContentType.ToLower() != "image/gif" &&
//    //            file.ContentType.ToLower() != "image/x-png" &&
//    //            file.ContentType.ToLower() != "image/png")
//    //        {
//    //            return false;
//    //        }

//    //        // Alternatively, you can also check the file's magic numbers (file signature).
//    //        // For example, to check for PNG files:
//    //        // var headerBytes = new byte[8];
//    //        // using var stream = file.OpenReadStream();
//    //        // stream.Read(headerBytes, 0, 8);
//    //        // var header = Encoding.UTF8.GetString(headerBytes);
//    //        // return header.StartsWith("\x89PNG\r\n\x1a\n");

//    //        return true;
//    //    }

//    //    [HttpGet]
//    //    public async Task<IActionResult> GetStoredFile(Guid id)
//    //    {

//    //        var storedFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == id);
//    //        if (storedFile == null)
//    //            //return Content("filename not present");
//    //            throw new UserFriendlyException("File not found");

//    //        var path = Path.Combine(
//    //                       Directory.GetCurrentDirectory(),
//    //                       "App_Data/Images", storedFile.FileName);

//    //        var memory = new MemoryStream();
//    //        using (var stream = new FileStream(path, FileMode.Open))
//    //        {
//    //            await stream.CopyToAsync(memory);
//    //        }
//    //        memory.Position = 0;
//    //        return File(memory, GetContentType(path), Path.GetFileName(path));


//    //    }

//    //    //[HttpGet]
//    //    //public async Task<IActionResult> GetStoredFileByPersonId(Guid id)
//    //    //{
//    //    //    var personService = IocManager.Instance.Resolve<IRepository<Person, Guid>>();

//    //    //    var storedFileId = await personService.GetAllIncluding(x => x.StoredFile)
//    //    //        .Where(x => x.Id == id)
//    //    //        .Select(x => x.StoredFile.Id)
//    //    //        .FirstOrDefaultAsync();
//    //    //    var storedFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == storedFileId);

//    //    //    if (storedFile == null)
//    //    //        //return Content("filename not present");
//    //    //        throw new UserFriendlyException("File not found");

//    //    //    var path = Path.Combine(
//    //    //                   Directory.GetCurrentDirectory(),
//    //    //                   "App_Data/Images", storedFile.FileName);

//    //    //    var memory = new MemoryStream();
//    //    //    using (var stream = new FileStream(path, FileMode.Open))
//    //    //    {
//    //    //        await stream.CopyToAsync(memory);
//    //    //    }
//    //    //    memory.Position = 0;
//    //    //    return File(memory, GetContentType(path), Path.GetFileName(path));


//    //    //}

//    //    private string GetContentType(string path)
//    //    {
//    //        var types = GetMimeTypes();
//    //        var ext = Path.GetExtension(path).ToLowerInvariant();
//    //        return types[ext];
//    //    }

//    //    private Dictionary<string, string> GetMimeTypes()
//    //    {
//    //        return new Dictionary<string, string>
//    //        {
//    //            {".txt", "text/plain"},
//    //            {".pdf", "application/pdf"},
//    //            {".doc", "application/vnd.ms-word"},
//    //            {".docx", "application/vnd.ms-word"},
//    //            {".xls", "application/vnd.ms-excel"},
//    //            {".png", "image/png"},
//    //            {".jpg", "image/jpeg"},
//    //            {".jpeg", "image/jpeg"},
//    //            {".gif", "image/gif"},
//    //            {".csv", "text/csv"}
//    //        };
//    //    }

//    //}
//}
