namespace ApiPlayground.Models
{
    public class LoginUserResponse : GenericResponseModel
    {
        public string Token { get; set; }
        public long UserId { get; set; }
    }
}