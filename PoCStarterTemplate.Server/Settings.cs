namespace PoCStarterTemplate
{
    sealed class Settings
    {
        public string AppName { get; set; }
        public DatabaseSettings Database { get; set; }
        public JWTAuthSettings Auth { get; set; }
    }
    public class DatabaseSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class JWTAuthSettings
    {
        public int TokenValidityMinutes { get; set; }
        public string SigningKey { get; set; }
    }
}
