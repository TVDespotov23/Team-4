using SchoolLibrary.Data.Repositories; // Заменете с вашия namespace за репозитори
using SchoolLibrary.Services;       // Заменете с вашия namespace за услуги

var builder = WebApplication.CreateBuilder(args);

// 1. Включваме контролерите и изгледите (MVC)
builder.Services.AddControllersWithViews();

// 2. Регистрираме класовете ви с Dependency Injection
builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
builder.Services.AddSingleton(sp => new BookService(sp.GetRequiredService<IBookRepository>()));

var app = builder.Build();

// 3. Настройваме маршрута по подразбиране (Books е името на нашия контролер без думата Controller)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

// 4. Стартираме сървъра
app.Run();