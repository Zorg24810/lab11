$(document).ready(function () {
    // подписать кнопки пейджера на событие click
    $(".page-link").click(function (e) {
        e.preventDefault();
        // получить адрес
        var uri = this.attributes["href"].value;
        // отправить асинхронный запрос и поместить ответ
        // в контейнер с id="list"
        $("#list").load(uri);
        // снять выделение с кнопки
        $(".active").removeClass("active disabled");
        // выделить текущую кнопку
        $(this).parent().addClass("active");
        // изменить адрес в адресной строке браузераhistory.pushState(null, null, uri);
    });
});