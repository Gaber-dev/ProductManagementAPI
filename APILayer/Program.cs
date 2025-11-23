
using BussinessLayer.Services.CustomerServices;
using BussinessLayer.Services.OrderServices;
using BussinessLayer.Services.ProductServices;
using DataAccessLayer.Data;
using DataAccessLayer.Repository;
using DataAccessLayer.Repository.CustomersRepository;
using DataAccessLayer.Repository.GenericsRepository;
using DataAccessLayer.Repository.OrdersRepository;
using DataAccessLayer.Repository.ProductsOrderRepository;
using DataAccessLayer.Repository.ProductsRepository;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );


            // Add services to the container.
            builder.Services.AddScoped<IProductRepository , ProductRepository>();
            builder.Services.AddScoped<IOrderRepository , OrderRepository>();
            builder.Services.AddScoped<ICustomerRepository , CustomerRepository>();
            builder.Services.AddScoped<IProductOrderRepository , ProductOrderRepository>();
            builder.Services.AddScoped<ICustomerService , CustomerService>();
            builder.Services.AddScoped<IProductService , ProductService>();
            builder.Services.AddScoped<IOrderService , OrderService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
