namespace Modelos;

public class EstacionDeServicio
{
    public int EstacionDeServicioId { get; set; }
    public List<Combustible> Combustibles { get; set; }
    public bool EstaAbierta { get; set; }
    public string Direccion { get; set; } 
}