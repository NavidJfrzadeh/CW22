using App.Domain.AppService;
using App.Domain.Service;
using App.Infra.DataAccess.Repo.EF;
using App.Infra.Database.SQLServer.EF;
using Core.AdminEntity.Contracts;
using Core.BaseService;
using Core.CarEntity.Contracts;
using Core.LogEntity.Contracts;
using Core.RequestEntity.Contracts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//add DbContext to Container
//builder.Services.AddDbContext<AppDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString"));
//});


var Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();


//get ConnectionString
var connectionString = Configuration.GetSection("ConntectionStrings:AppConnectionString").Value;



//builder.Logging.ClearProviders();
//builder.Services.AddLogging(LoggingBuilder =>
//{
//    //LoggingBuilder.AddConsole();
//    //LoggingBuilder.AddSeq("http://localhost:5341", "lMPa0VbbxSlBTx8OL6YT");

//    LoggingBuilder.AddSerilog();
//});



//builder design pattern
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
})
    .UseSerilog((context, config) =>
    {
        //config.MinimumLevel.Information();
        //config.WriteTo.Seq("http://localhost:5341", Serilog.Events.LogEventLevel.Information, apiKey: "lMPa0VbbxSlBTx8OL6YT");
        config.WriteTo.File("D:\\My Files\\MaktabC#\\CW22\\Logs\\log.txt", Serilog.Events.LogEventLevel.Error);

        config.WriteTo.Seq(
            Configuration.GetSection("seq:ServerURL").Value,
            Serilog.Events.LogEventLevel.Information,
            apiKey: Configuration.GetSection("seq:apiKey").Value
            );

    });



//Car Request
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();

//car Brands
builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();

//admin 
builder.Services.AddScoped<IAdminAppService, AdminAppService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();

//Log
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

//base
builder.Services.AddScoped<IBaseService, BaseService>();

//ApDbContext
builder.Services.AddScoped<AppDbContext, AppDbContext>();

var app = builder.Build();

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
