$(document).ready(function () {
    $("#regLogContainer").css('width', ($(window).width() / 2) + 'px')
                        .css('height', ($(window).height() - $('h1').height()) + 'px')
                        .css('margin-left',($(window).width() / 2 - $("#regLogContainer").width() / 2) + 'px');
    $('h1').css('width', $("#regLogContainer").width() + 'px')
        .css('margin-left', $("#regLogContainer").css('margin-left'));
    $('.field-validation-error').attr('style', function (i, style) {
        return style.replace(/max-width[^;]+;?/g, '');
    });
    $('textarea').css('width', $("#regLogContainer").width() - 5 + 'px');
    $('#inputForm').css('top', $(window).height() - $('#inputForm').height() - $('h1').height() + 'px');
    $('#chatusers').css('height', $(window).height() - $('#inputForm').height() - $('h1').height() + 'px');
    $('#chatroom').css('height', $('#chatusers').css('height'));
    console.log($('#inputForm').css('top'));
    
})