namespace Modelos;

public class EstacionDeServicio
{
    public Combustible[] Combustibles { get; set; }
    public bool EstaAbierta { get; set; }
    public string Direccion { get; set; }

    public EstacionDeServicio(bool estaAbierta, string direccion, Combustible[] combustibles)
    {
        this.EstaAbierta = estaAbierta;
        this.Direccion = direccion;
        this.Combustibles = combustibles;
    }
}