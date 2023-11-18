using Modelos;

namespace Servicios;

public class BdEstaciones
{
    //Campo de la clase
    private EstacionDeServicio[] estaciones;

 
    //Constructor de la clase
    public BdEstaciones()
    {
        this.estaciones = new EstacionDeServicio[0];
    }
 
    //Metodos de la clase que permiten agregar estaciones
    public void AgregarEstacion(EstacionDeServicio estacion)
    {
        Array.Resize(ref this.estaciones, this.estaciones.Length + 1);
        this.estaciones[this.estaciones.Length - 1] = estacion;
    }


    //Ver la lista de estaciones
    public EstacionDeServicio[] ListarEstaciones()
    {
        return this.estaciones;
    }
}

