using Autofac;
using Autofac.Integration.Mvc;
using Examiner.Core.DomainModels;
using Examiner.Infrastructure.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examiner.MvcClient
{
    public partial class Startup
    {
        // Aby uzyskać więcej informacji o konfigurowaniu uwierzytelniania, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterType<ExaminerDBContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();
            builder.RegisterType<RoleManager<IdentityRole>>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserManager<ApplicationUser>>().AsSelf().InstancePerRequest();
            builder.RegisterType<SignInManager<ApplicationUser, string>>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Umożliwia aplikacji weryfikowanie znacznika zabezpieczeń podczas logowania się użytkownika.
                    // Jest to funkcja zabezpieczeń używana w przypadku zmiany hasła lub dodawania logowania zewnętrznego do konta.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<ApplicationUser>, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Umożliwia aplikacji tymczasowe przechowywanie informacji o użytkownikach, gdy używają drugiego etapu w procesie uwierzytelniania dwuetapowego.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
        }
    }
}