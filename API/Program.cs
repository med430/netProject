using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                    typeof(Application.Features.Commands.CreateProduct.CreateProductCommandHandler).Assembly,
                    typeof(Domain.Entities.Product).Assembly,
                    typeof(API.Program).Assembly,
                    typeof(Persistence.Repositories.InMemoryRepository).Assembly
                ));
            builder.Services.AddSingleton<Application.Interfaces.IProductRepository, Persistence.Repositories.InMemoryRepository>();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
