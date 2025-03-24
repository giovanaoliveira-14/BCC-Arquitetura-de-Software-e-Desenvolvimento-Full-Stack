namespace DDDCommerceBCC.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public decimal Total { get; set; }
    public DateTime DataPedido { get; set; }
}
