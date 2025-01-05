using BlogApp.API;
using BlogApp.BL;
using BlogApp.BL.DTOs.Options;
using BlogApp.DAL;
using BlogApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
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
            Array.Empty<string>()
        }
    });
});
builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
});
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddJwtOptions(builder.Configuration);
// builder.Services.AddEmailOptions(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidation();
builder.Services.AddAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.EnablePersistAuthorization();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();