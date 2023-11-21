// Permitimos usar las clases de los proyectos Modelos y Servicios
using Modelos;
using Servicios;
using AccesoADatos;
//Importamos el Proveedor de Ef Core para SQL Server
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

//Configurar el contexto de la base de datos 
//Esta linea Toma del archivo appsettings.json la cadena de conexion
//y la pasa al contexto de la base de datos
//Ademas configura que se use SQL Server
builder.Services.AddDbContext<EstacionesDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

// Adicionamos el servicio de la base de datos de estaciones
// para que este disponible en toda la aplicacion y pueda llamarse en los servicios
// Esto es un singleton, es decir, solo se crea una vez y se usa en toda la aplicacion
// Se deshabilita porque ya no es necesaria - puedes borrarla
//builder.Services.AddSingleton<BdEstaciones>();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Se obtiene el listado de estaciones
//Se usa el contexto de la base de datos
app.MapGet("/estaciones", (EstacionesDbContext bd) =>
{
    var estaciones = bd.EstacionDeServicio.ToList();
    return estaciones;
})
.WithName("ListaEstaciones")
.WithOpenApi();

//Se agrega una estacion
//Observa que tambien se usa el contexto de la base de datos
app.MapPost("/estaciones", (EstacionesDbContext bd, EstacionDeServicio estacion) =>
{
    //Se agrega el objeto estacion al contexto de la base de datos    
    bd.Add(estacion);
    //Se guardan los cambios en la base de datos
    bd.SaveChanges();
    
    return estacion;
})
.WithName("AgregarEstacion")
.WithOpenApi();

app.Run();
