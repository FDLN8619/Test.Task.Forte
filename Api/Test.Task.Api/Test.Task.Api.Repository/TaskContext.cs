using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Entities;
using Test.Task.Api.Domain.Enums;

namespace Test.Task.Api.Repository
{
    public class TaskContext : DbContext
    {
        //Inyectamos Configuracion para obtner la cadena de conexion del appSettings
        private readonly IConfiguration _configuration;
        public TaskContext(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        public TaskContext()
        {
        }
        //creamos nuestros DbSet(tablas) en base a la entidad creada(Task)
        public DbSet<ETask> Tasks { get; set; }
        //se configura cadena de conexion que viene del appsettings
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TareasDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        // al creat el modelo se realiza una conversion para la numeracion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<ETask>()
            .Property(e => e.EStatus)
            .HasConversion(
                v => v.ToString(),
                v => (Status)Enum.Parse(typeof(Status), v));
        }
    }
}
