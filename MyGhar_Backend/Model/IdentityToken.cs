namespace MyGhar_Backend.Model
{
    public class IdentityToken
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; } // seconds
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IsHttpError { get; set; }
        public bool HttpErrorStatusCode { get; set; }
        public string HttpErrorReason { get; set; }
        public string IdentityTokenProp { get; set; }
        public string IsError { get; set; }
        public DateTime TokenDateTime { get; set; }
    }
}
