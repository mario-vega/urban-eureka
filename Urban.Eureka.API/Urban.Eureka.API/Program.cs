using Urban.Eureka.API.Repository;
using Urban.Eureka.API.Repository.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", policyBuilder =>
	{
		policyBuilder.AllowAnyHeader()
						.AllowAnyMethod()
						.WithOrigins("http://localhost:4200");
	});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
