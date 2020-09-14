using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabsV05.DAL.Data;
using WebLabsV05.DAL.Entities;
using WebLabsV05.Entities;

namespace lab1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                      UserManager<ApplicationUser> userManager,
                                      RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

           //проверка наличия групп объектов
            if (!context.AutoGroups.Any())
            {
                context.AutoGroups.AddRange(
                new List<AutoGroup>
                {
                    new AutoGroup {GroupName="VW"},
                    new AutoGroup {GroupName="Toyota"},
                    new AutoGroup {GroupName="Skoda"},
                    new AutoGroup {GroupName="Mazda"},
                    new AutoGroup {GroupName="Ford"},
                    new AutoGroup {GroupName="BMW"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Autos.Any())
            {
                context.Autos.AddRange(
                new List<Auto>
                {
                    new Auto {AutoName="Volkswagen Polo IV 2005",
                    Description="Авто в хорошем состоянии, есть пару нюансов. Новая резина, два комплекта колёс зима и лето. Авто каждый день на ходу. Вопросы по телефону. Минимальный торг.",
                    AutoCost =3650, AutoGroupId=1, Image="VW1.jpg" },
                    new Auto {AutoName="Volkswagen Polo V Рестайлинг 2016",
                    Description="Отличное состояние, сервисная книга, пробег оригинал, богатая комплектация. Торг.",
                    AutoCost =7850, AutoGroupId=1, Image="VW2.jpg" },
                    new Auto {AutoName="Volkswagen Passat B5 1998",
                    Description="Passat B5 1998 г.в. отличный и приемистый двигатель ADR 20v (125 л.с.) без турбины. По подвеске и двигателю нареканий нет. МКПП. Только с переоформлением. Торг уместен у капота.",
                    AutoCost =3650, AutoGroupId=1, Image="VW3.jpg" },
                    new Auto {AutoName="Toyota Camry VIII (XV70) 2018",
                    Description="Машина в хорошем состоянии. На гарантии . Была куплена и обслуживается у официального дилера Toyota в Минске. Один владелец. Комплектация Классик. Цвет белый  6-ступенчатая АКП. Салон кожа. Мультимедийная система с 7-дюймовым цветным дисплеем. Комплект зимней резины. Заявленный расход топлива: город/загород/смешанный 11,5/6,4/8,3 (л/100км).",
                    AutoCost =23976, AutoGroupId=2, Image="T1.jpg" },
                    new Auto {AutoName="Toyota RAV 4 II (XA20) 2002",
                    Description="Отличное состояние. Один владелец в РБ. Автомобиль полностью обслужен и готов к дальнейшей эксплуатации. Оформим кредит и лизинг в течение часа на данный автомобиль прямо на месте. Возможна любая форма оплаты (наличный, безналичный расчет). Примем Ваш автомобиль в зачёт. Мы находимся на территории Автомобильного рынка Ждановичи.",
                    AutoCost =6300, AutoGroupId=2, Image="T2.jpg" },
                    new Auto {AutoName="Toyota Camry VI (XV40) Рестайлинг 2010",
                    Description="Хорошее состояние. Автомобиль полностью обслужен и готов к дальнейшей эксплуатации. Оформим кредит и лизинг в течение часа на данный автомобиль прямо на месте. Возможно предоставление рассрочки. Возможна любая форма оплаты (наличный, безналичный расчет). Примем Ваш автомобиль в зачёт. Мы находимся на территории Автомобильного рынка Ждановичи.",
                    AutoCost =9000, AutoGroupId=2, Image="T3.jpg" }
                });
                await context.SaveChangesAsync();
            }

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            
        }
    }
}
