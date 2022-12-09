using HotDesk.API.Config;
using HotDesk.API.Services;
using HotDesk.API.Services.DesksService;
using HotDesk.API.Services.LocationsService;
using HotDesk.API.Services.ReservationsService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("Database"));


builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ILocationService, LocationsService>();
builder.Services.AddScoped<IReservationService, ReservationsService>();
builder.Services.AddScoped<IDeskService, DesksService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

app.UseCors("corsapp");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

