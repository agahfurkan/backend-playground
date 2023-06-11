namespace ApiPlayground.Models.Dtos;

public class AddProductToCartDto
{
    public long UserId { get; set; }
    public int ProductId { get; set; }
}