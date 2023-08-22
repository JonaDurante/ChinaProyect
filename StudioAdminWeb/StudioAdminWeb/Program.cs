// 1. Using para trabajar con EF
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudioAdminData;
using StudioAdminData.DataAcces;
using StudioAdminData.Interfaces;
using StudioAdminData.Models.Abstract;
using StudioAdminData.Services;

var builder = WebApplication.CreateBuilder(args);

// 2. agregar conexion a base de datos
const string CONNECTIONNAME = "SudioAdminDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
// 3. Add Context to Services of builder
builder.Services.AddDbContext<StudioAdminDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add services of JWT aurtorization
builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// 4. Add Custom Services (folder services)
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<ICommonServices<BaseEntity>, CommonServices<BaseEntity>>();
builder.Services.AddScoped<IThirdServices, ThirdServices>();
builder.Services.AddScoped<IUserService, UserService>();

// 8 Add Autorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// 9 Config autentication in Swagger 
builder.Services.AddSwaggerGen(options =>
{
    // Definimos la seguridad
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Autorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization Header using Bearer Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

// 5. Cors Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPollicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader(); // Ré generica, modificar
    });
});


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

// 6. Tell app to use CORS
app.UseCors("CorsPollicy");

app.Run();
