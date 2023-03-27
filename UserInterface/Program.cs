using Core.Repository;
using Environment.Settings;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.CategoryRepository;
using Repository.ProductRepository;
using Service.CategoryService;
using Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Generic Implementation
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
//Product Implementation
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

//Category implementation
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

//Relational Database Implementation
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString")));

//Implement Settings
var databaseSettings = builder.Configuration.GetSection(nameof(DatabaseConnectionString));
builder.Services.Configure<DatabaseConnectionString>(databaseSettings);

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});




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