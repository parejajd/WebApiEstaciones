// Permitimos usar las clases de los proyectos Modelos y Servicios
using Modelos;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Adicionamos el servicio de la base de datos de estaciones
// para que este disponible en toda la aplicacion y pueda llamarse en los servicios
// Esto es un singleton, es decir, solo se crea una vez y se usa en toda la aplicacion
builder.Services.AddSingleton<BdEstaciones>();
 
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
app.MapGet("/estaciones", (BdEstaciones bd) =>
{
    var estaciones = bd.ListarEstaciones();
    return estaciones;
})
.WithName("ListaEstaciones")
.WithOpenApi();

//Se agrega una estacion
app.MapPost("/estaciones", (BdEstaciones bd, EstacionDeServicio estacion) =>
{
    bd.AgregarEstacion(estacion);
    return estacion;
})
.WithName("AgregarEstacion")
.WithOpenApi();

app.Run();
