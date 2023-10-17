using BusinessLogicLayer;
using BusinessLogicLayer.interfaces;
using DataAccessLayer;
using DataAccessLayer.interfaces;

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
