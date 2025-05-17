using konversiExcelDanPdf.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;

namespace konversiExcelDanPdf {
  public class Program {
    public static void Main(string[] args) {
      /* ============================== services ============================== */
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllersWithViews();
      builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
      /* ============================== pipeline ============================== */
      var app = builder.Build();
      if (!app.Environment.IsDevelopment()){
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRotativa();
      app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id=4}");
      app.Run();
    }
  }
}
