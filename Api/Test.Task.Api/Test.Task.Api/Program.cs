using Microsoft.EntityFrameworkCore;
using Test.Task.Api.Repository;
using Test.Task.Api.Repository.Interfaces;
using Test.Task.Api.Service;
using Test.Task.Api.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Se agrega Interfaces e implementaciones de interfaz de repository t Service
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<ITaskService, TaskService>();

builder.Services.AddDbContext<TaskContext>();

//builder.Services.AddDbContext<TareaContext>(opt =>
//{
//    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
//});

var app = builder.Build();

//Al Iniciar se ejecuta la ultima migracion creada, si no existe la BD la crea y todos sus objetos
using(var scope = app.Services.CreateScope())
{
    TaskContext context = scope.ServiceProvider.GetRequiredService<TaskContext>();
    context.Database.Migrate();
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//Permitimos todos los origenes y metodos(Put,Delete..etc) para asi poder realizar peticiones. Nota: esto puede cambiar si solo queremos algunos origenes para que que puedan realizar una peticion
app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());

app.Run();
