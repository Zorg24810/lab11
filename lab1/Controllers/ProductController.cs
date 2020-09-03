using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using WebLabsV05.Entities;

namespace lab1.Controllers
{
    public class ProductController : Controller
    {
        public List<Auto> _autos;
        List<AutoGroup> _autoGroups;

        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }
        
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var autosFiltered = _autos.Where(d => !group.HasValue || d.AutoGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _autoGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Auto>.GetModel(autosFiltered, pageNo, _pageSize));
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _autoGroups = new List<AutoGroup>
            {
            new AutoGroup {AutoGroupId=1, GroupName="VW"},
            new AutoGroup {AutoGroupId=2, GroupName="Toyota"},
            new AutoGroup {AutoGroupId=3, GroupName="Skoda"},
            new AutoGroup {AutoGroupId=4, GroupName="Mazda"},
            new AutoGroup {AutoGroupId=5, GroupName="Ford"},
            new AutoGroup {AutoGroupId=6, GroupName="BMW"}
            };
            _autos = new List<Auto>
            {
            new Auto {AutoId = 1, AutoName="Volkswagen Polo IV 2005",
            Description="Авто в хорошем состоянии, есть пару нюансов. Новая резина, два комплекта колёс зима и лето. Авто каждый день на ходу. Вопросы по телефону. Минимальный торг.",
            AutoCost =3650, AutoGroupId=1, Image="VW1.jpg" },
            new Auto { AutoId = 2, AutoName="Volkswagen Polo V Рестайлинг 2016",
            Description="Отличное состояние, сервисная книга, пробег оригинал, богатая комплектация. Торг.",
            AutoCost =7850, AutoGroupId=1, Image="VW2.jpg" },
            new Auto { AutoId = 3, AutoName="Volkswagen Passat B5 1998",
            Description="Passat B5 1998 г.в. отличный и приемистый двигатель ADR 20v (125 л.с.) без турбины. По подвеске и двигателю нареканий нет. МКПП. Светлый салон, элктростеклоподьемники всех дверей, полностью рабочий климат-контроль, штатная хорошая акустика, бортовой компьютер. На дисках 16 радиуса с хорошей резиной. Днище целое. За машиной следил и делал для себя. За время владения много чего сделал, но не дошли руки до кузова, поэтому присутствуют небольшие нюансы, свойственные годам авто. 35 тыс. назад менялся ремень ГРМ с помпой, 20 тыс. назад гидронатяжитель цепи, звезда с цепью, сальники распредвалов, свечи, прокладка клапанной крышки, 10 тыс. назад менялся радиатор. 500 км назад была замена масла с фильтром. Техосмотр проходит сама без проблем. Вкладывать денег в машину не нужно, сел и поехал. Продавать не планировал и к продаже не готовил. Только с переоформлением. Торг уместен у капота.",
            AutoCost =3650, AutoGroupId=1, Image="VW3.jpg" },
            new Auto { AutoId = 4, AutoName="Toyota Camry VIII (XV70) 2018",
            Description="Машина в хорошем состоянии. На гарантии . Была куплена и обслуживается у официального дилера Toyota в Минске. Один владелец. Комплектация Классик. Цвет белый  6-ступенчатая АКП. Салон кожа. Мультимедийная система с 7-дюймовым цветным дисплеем. Комплект зимней резины. Заявленный расход топлива: город/загород/смешанный 11,5/6,4/8,3 (л/100км).",
            AutoCost =23976, AutoGroupId=2, Image="T1.jpg" },
            new Auto { AutoId = 5, AutoName="Toyota RAV 4 II (XA20) 2002",
            Description="Отличное состояние. Один владелец в РБ. Автомобиль полностью обслужен и готов к дальнейшей эксплуатации. Оформим кредит и лизинг в течение часа на данный автомобиль прямо на месте. Возможна любая форма оплаты (наличный, безналичный расчет). Примем Ваш автомобиль в зачёт. Мы находимся на территории Автомобильного рынка Ждановичи.",
            AutoCost =6300, AutoGroupId=2, Image="T2.jpg" },
            new Auto { AutoId = 5, AutoName="Toyota Camry VI (XV40) Рестайлинг 2010",
            Description="Хорошее состояние. Автомобиль полностью обслужен и готов к дальнейшей эксплуатации. Оформим кредит и лизинг в течение часа на данный автомобиль прямо на месте. Возможно предоставление рассрочки. Возможна любая форма оплаты (наличный, безналичный расчет). Примем Ваш автомобиль в зачёт. Мы находимся на территории Автомобильного рынка Ждановичи.",
            AutoCost =9000, AutoGroupId=2, Image="T3.jpg" }
            };
        }



    }
}