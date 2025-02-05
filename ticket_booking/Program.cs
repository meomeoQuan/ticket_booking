using Microsoft.EntityFrameworkCore;
using ticket_booking.Data;
using ticket_booking.Hubs;
using ticket_booking.Repositories.ChatRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<ChatHub>("/ConnectedHub");

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=Home}/{action=Index}/{id?}");//
    //endpoints.MapHub<ChatHub>("/chatHub"); // Ánh xạ đường dẫn "/chatHub" đến ChatHub class
    // ... các cấu hình endpoint khác
});

app.Run();

