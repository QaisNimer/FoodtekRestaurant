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
using BrainstormingFoodTek.Helpers.ValidationFields;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<RestaurantDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-QS28KQP\\SQLEXPRESS;Initial Catalog=RestaurantDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddDbContext<RestaurantDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-QS28KQP\\SQLEXPRESS;Initial Catalog=RestaurantDB;User Id=admin;Password=Test@1234;Trust Server Certificate=True"));
builder.Services.AddScoped<IItems, ItemsService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IDiscount, DiscountService>();
builder.Services.AddScoped<INotification, NotificationServices>();
builder.Services.AddScoped<ICart, CartService>();
builder.Services.AddScoped<IFavorite, FavoriteService>();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddSingleton<TokenProviderHelper>();
builder.Services.AddScoped<ItemsService>();
builder.Services.AddScoped<NotificationServices>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ITokenProvider, TokenProviderHelper>();
builder.Services.AddScoped<ItemsValidation>();
builder.Services.AddScoped<GenerateJwtTokenHelper>();
builder.Services.AddScoped<ValidateUserExist>();
builder.Services.AddScoped<OTPBasedOnUserRole>();
builder.Services.AddScoped<MailingHelper>();
// Add Authentication and Authorization with JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = true; // for development
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

// When You Want To Test Locally Comment This, If Publish Keep It
app.UseSwagger();
app.UseSwaggerUI(
    c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrainstormingFoodTek API V1");
        c.RoutePrefix = string.Empty;
    }
    );
// Until Here To Test Locally

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrainstormingFoodTek API V1");
//    }  // Set Swagger endpoint
//    );
//}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
