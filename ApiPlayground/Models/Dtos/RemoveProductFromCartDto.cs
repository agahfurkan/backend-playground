namespace ApiPlayground.Models.Dtos
{
    public class RemoveProductFromCartDto
    {
        public long UserId { get; set; }
        public int ProductId { get; set; }
    }
}