$(function()
{
    bindEvents();
});

function bindEvents()
{
    $('.goToMain').on("click", function(){
        location.href = "/";
    });

    $('.mainMenuTab').on('click', function () {
        var _location = $(this).attr("menuPath");
        location.href = _location;
    });
}