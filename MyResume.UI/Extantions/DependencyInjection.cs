using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using MyResume.Infrastructure.AppContext;

namespace MyResume.UI.Extantions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {

            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true; //aşağıdan yukarı gelsin giderken yukarıdan aşağıya gitsin.
                config.DurationInSeconds = 3; //3 saniye göüzküsün
                config.Position = NotyfPosition.BottomRight;//sağ altta gözüksün.
                config.IsDismissable = true; //yokedilebilir.x işareti gelsin.
            });

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
