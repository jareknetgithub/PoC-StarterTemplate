namespace PoCStarterTemplate.Auth
{
    sealed class Allow : Permissions
    {
        public const string Account_Read = "100";
        public const string Account_Update = "101";
        public const string Account_Delete = "102";

        public const string Special_User = "-9999";
    }
}
