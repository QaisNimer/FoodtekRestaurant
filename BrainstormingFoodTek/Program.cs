using BrainstormingFoodTek.Helpers.ItemsValidation;
using BrainstormingFoodTek.Interfaces;
using BrainstormingFoodTek.Models;
using BrainstormingFoodTek.Services;
using Microsoft.EntityFrameworkCore;
using BrainstormingFoodTek.Helpers.UserValidation;
using BrainstormingFoodTek.Helpers.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BrainstormingFoodTek.Helpers.OTPUserSelection;
using BrainstormingFoodTek.Helpers.SendingEmail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodtekDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-QS28KQP\\SQLEXPRESS;Initial Catalog=RestaurantDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddScoped<IItems, ItemsService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IDiscount, DiscountService>();
builder.Services.AddScoped<INotification, NotificationServices>();
builder.Services.AddScoped<ICart, CartService>();
builder.Services.AddScoped<IFavorite, FavoriteService>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
//builder.Services.AddSingleton<TokenProviderHelper>();
builder.Services.AddScoped<ITokenProvider, TokenProviderHelper>();
builder.Services.AddScoped<ItemsValidation>();
builder.Services.AddScoped<GenerateJwtTokenHelper>();
builder.Services.AddScoped<ValidateUserExist>();
builder.Services.AddScoped<OTPBasedOnUserRole>();
builder.Services.AddScoped<MailingHelper>();
// Add Authentication and Authorization with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // for development
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:IssuerIP"],
            ValidAudience = builder.Configuration["JWT:AudienceIP"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero // No extra time allowed after expiration
        };
    });
var app = builder.Build();
//Token Also
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
