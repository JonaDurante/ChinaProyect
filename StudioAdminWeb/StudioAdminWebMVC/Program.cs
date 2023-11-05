// 1. Using para trabajar con EF
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using StudioAdminData.DataAccess;
using StudioAdminData.Interfaces;
using StudioAdminData.Services;
using StudioAdminWebMVC;
using StudioAdminWebMVC.Helppers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Config Serilog
builder.Host.UseSerilog((HostBuilderCtx, LoggerConf) => {
    LoggerConf
    .WriteTo.Console() // Escribe en la consola
    .WriteTo.Debug()   // Escriba en debug
    .ReadFrom.Configuration(HostBuilderCtx.Configuration);
});

// 2. agregar conexion a base de datos
const string CONNECTIONNAME = "SudioAdminDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);
// 3. Add Context to Services of builder
builder.Services.AddDbContext<StudioAdminDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add services of JWT aurtorization
builder.Services.AddJwtTokenServices(builder.Configuration); //--> Aquí genera el error

// Add services to the container.
builder.Services.AddControllers();
// HttpClient For request
builder.Services.AddHttpClient();

// 4. Add Custom Services (folder services)
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped(typeof(ICommonServices<>), typeof(CommonServices<>));
builder.Services.AddScoped<IThirdServices, ThirdServices>();
builder.Services.AddScoped<IUserService, UserService>();

//Versionado
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
});

// Documentacion de versiones para que los controllers reciban la versión.
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV"; // ej 1.0.0 
    setup.SubstituteApiVersionInUrl = true;
});

// 8 Add Autorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
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

//builder.Services.ConfigureOptions<ConfigureSwaggerOptions>(); //incorpora las opciones a la documentacion.

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

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSerilogRequestLogging();

// 6. Tell app to use CORS
app.UseCors("CorsPollicy");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
