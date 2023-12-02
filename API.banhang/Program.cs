using BusinessLogicLayer;
using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataAccessLayer.interfaces;
using DataModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<iLogin, LoginDAL>();
builder.Services.AddTransient<iLoginBUL, loginBUL>();
builder.Services.AddTransient<iCategoryBUL, CategoryBUL>();
builder.Services.AddTransient<IcategoryDAL, CategoryDAL>();
builder.Services.AddTransient<IproductBUL, productBUL>();
builder.Services.AddTransient<iProductDAL, ProductDAL>();
builder.Services.AddTransient<IHoaDonBul, HoaDonBUL>();
builder.Services.AddTransient<iHoadonDAL, HoadonDAL>();
builder.Services.AddTransient<iNhaCCDAL, NhaCungCapDAL>();
builder.Services.AddTransient<iNhaCungCapBUL, NhaCungCapBUL>();
builder.Services.AddTransient<InhapHangBUL, NhapHangBUL>();
builder.Services.AddTransient<iHdNhapDAL, HDNhapDAL>();
builder.Services.AddTransient<iThongKeDAL, ThongKeDAL>();
builder.Services.AddTransient<ithongkeBUL, ThongKeBUL>();
// configure strongly typed settings objects
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});




// Configure the HTTP request pipeline.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
