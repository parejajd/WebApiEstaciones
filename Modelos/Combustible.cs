namespace Modelos;

public class Combustible
{
    public int CombustibleId { get; set; }
    public string TipoCombustible { get; set; }
    public double CostoGalon { get; set; }

    public EstacionDeServicio EstacionDeServicio { get; set; }
}