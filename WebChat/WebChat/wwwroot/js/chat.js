var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();


var nameUser = document.getElementById('userInput');
var messageUser = document.getElementById('messageInput');


connection.on("ReceiveMessage", function (user, message) {

    var msg = message.replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;");

    var liElement = document.createElement('li');

    liElement.innerHTML = '<strong>' + user + '</strong>:&nbsp;&nbsp;' + msg;

    document.getElementById('messagesList').appendChild(liElement);
});


connection.start()
    .then(function () {
        document.getElementById('sendButton').addEventListener('click', function (event) {
            connection.invoke('SendMessage', nameUser.value, messageUser.value);
            event.preventDefault();
        });
    })
    .catch(error => {
        console.error(error.message);
    });