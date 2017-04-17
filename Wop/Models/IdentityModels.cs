using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Wop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Sticker> Stickers { get; set; }
        public DbSet<Select> Selects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class StikDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext user)
        {
            user.Stickers.Add(new Sticker { Title = "Гнев отца", UserName = "Marsel@mail.ru", Text = "Мальчик маленький Том ожидал приезда отца,которого очень давно не видел. Тетя и дядя,ругая мальчика, говорили,что приедет папа и гнев его будет ужасен. Мальчик так и представил себе :папа+ его гнев.Он встретил литератора,который красочно нарисовал,что гнев имеет четыре ноги,четыре руки(он думал о дяде и тете),а мальчик вновь представил себе чудовище.",Url= "http://www.edmegolearning.com/wp-content/uploads/2016/01/140387907-1024x723.jpg", Date = DateTime.Now });
            user.Stickers.Add(new Sticker { Title = "На Берлин", UserName = "LeninGrad@rut.bu", Text = "Летом 1942 года Огарков, обычный связист, оказался в немецком плену. Там же боец познакомился с еще одним пленником рядовым Джурабаевым. Договорившись о побеге, молодые солдаты поджидали лишь лучшего случая, а когда он наконец таки пробил пленники сбежали. Немцы открыли на бойцов настоящую охоту, но новым приятелям удавалось с каждым разом давать отпор и вместе с тем становиться ближе. Однако не стоило Огаркову и Джурабаеву забывать о том, что война имеет свои правила, и дружбе и любви порой не место в ней.", Url= "https://2stick.ru/image/cache/data/prazdnik/may/9M0080-500x500.png", Date = DateTime.Now });
            user.Stickers.Add(new Sticker { Title = "Говорд Трамп", UserName = "TrampMl@amerik.su",Url= "http://www.wcqj.com/wp-content/uploads/2016/01/Donald-Trump-WCQJ.jpg", Text = "The interviews weren’t conducted to “fuck someone over ... we were having a good time. I fully knew what I was doing when I interviewed Trump. I knew I had a guy who loved to talk about sex ... I had a guy who loved to evaluate women on a scale of 1 to 10. These are avenues I went down because I knew it would entertain the audience.”", Date = DateTime.Now });
            base.Seed(user);
        }
    }
}