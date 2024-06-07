namespace EphProvider.Configurations
{
    public class TokenConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; } // Expiration time in minutes
    }
}
