using LibHub.Debugging;

namespace LibHub
{
    public class LibHubConsts
    {
        public const string LocalizationSourceName = "LibHub";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "e5d013e65c354595b945c3ffc445e0cc";
    }
}
