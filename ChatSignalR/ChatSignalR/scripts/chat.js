$(document).ready(function() {
  $(function () {
    var chat = $.connection.chatHub;
    var name = $('#txtUserName').val();
     
    chat.client.addMessage = function (name, message, time) {
        $('#chatroom').append('<p><b>' + htmlEncode(name)
            + '</b>: ' + time + '</p>');
        $('#chatroom').append('<p><b>' + htmlEncode(message) + '</b><p>');
    };
      chat.client.onConnected = function(id, userName, allUsers) {
          $('#hdId').val(id);
          $('#username').val(userName);
          $('#header').html('<h3>Hi, ' + userName + '</h3>');

          for (i = 0; i < allUsers.length; i++) {

              AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
          };
      };

    chat.client.onNewUserConnected = function (id, name) {
        AddUser(id, name);
    }

    chat.client.onUserDisconnected = function (id, userName) {
        $('#' + id).remove();
    }

    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            chat.server.send($('#username').val(), $('#message').val());
            $('#message').val('');
        });
        $("#btnLogin").on("click", function () {
            if (name.length > 0) {
                chat.server.connect(name);
                console.log("!!");
            }
        });
        $("#btnLogin").trigger("click");
    });
});
    function htmlEncode(value) {
        var encodedValue = $('<div />').text(value).html();
        return encodedValue;
    }
    function AddUser(id, name) {
        var userId = $('#hdId').val();
        if (userId !== id) {
            $("#chatusers").append('<p id="' + id + '"><b>' + name + '</b></p>');
        }
    }
})


