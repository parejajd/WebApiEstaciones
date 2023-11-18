namespace Modelos;

public class Combustible
{
    public string TipoCombustible { get; set; }
    public double CostoGalon { get; set; }

    public Combustible(string tipoCombustible, double costoGalon)
    {
        this.TipoCombustible = tipoCombustible;
        this.CostoGalon = costoGalon;
    }
}