$(document).ready(function () {

    //Init();


    $('td').on('click', 'img', function (e) {
        e.preventDefault();
        var elem = $(this)[0];

        var id = elem.id;  // получаем id клетки


        $.ajax({
            url: "api/game/move/" + id,
            contentType: "application/json",
            method: "POST",

            success: function (data) {
                Drow(data);
            },
            error: function (data) {
                alert("Ошибка при отправке запроса.");
            }
        });

    });

});

var Drow = function (data) {
    if (!data.success)
        return;

    //Заполняем данные полученные через API
    data.cells.forEach(function (value, i, arr) {
        var id = "#" + i;
        var item = $(id)[0];
        item.src = "/images/" + value + ".png";
    });

    //Проверка на победу
    if (data.isEnd === true) {
        var winner = "Ничья!";

        if (data.winner === 1)
            winner = "Победили 'Х'!";
        if (data.winner === 2)
            winner = "Победили 'О'!";
        $('#ScoreButton')[0].innerText = "Счет: " + data.scoreX + " - " + data.scoreO;
        $('.modal-body')[0].innerText = winner;
        $('#resultModal').modal();
    }

   
}

//Альтернативная функция заполнения поля из сессии
var Init = function() {
    $.ajax({
        url: "api/game/init/",
        contentType: "application/json",
        method: "POST",

        success: function (data) {
            data.success = true;
            Drow(data);
        },
        error: function (data) {
            alert("Ошибка при отправке запроса.");
        }
    });
}

