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
        //document.getElementById('sendButton').addEventListener('click', function (event) {
        //    connection.invoke('SendMessage', nameUser.value, messageUser.value);
        //    event.preventDefault();
        //});
    })
    .catch(error => {
        console.error(error.message);
    });


function loadUser(idSender) {
    getUser(idSender);
    getMessages(idSender)
}

function getMessages(idSender) {
    var url = `/api/messages/${myId}/${idSender}`;
    console.log('Request to ' + url);

    $.ajax({
        method: 'GET',
        url: url,
        data: null,
        complete: function (data) {
            //deserializa o JSON
            var messageOBJ = JSON.parse(data.responseText);

            if (messageOBJ.success) {

                console.log(messageOBJ);

                //limpa a caixa das mensagens
                var messages = document.querySelector('.messages');
                messages.innerHTML = "";

                for (var i = 0; i < messageOBJ.data.messages.length; i++) {
                    if (messageOBJ.data.messages[i].fkIdSender != myId) {

                        messages.innerHTML += `
                            <div class="box-message-left">
                                <div class="contact-indicator"></div>

                                <div class="box-contact-message">
                                    <p>${ messageOBJ.data.messages[i].text}</p>
                                    <h6 class="hour-message">${ messageOBJ.data.messages[i].sendDate.substring(0, 13)}</h6>
                                </div>
                            </div>
                        `;
                    }
                    else {
                        messages.innerHTML += `
                            <div class="box-message-right">
                                <div class="my-indicator"></div>
                                
                                <div class="box-my-message">
                                    <p>${ messageOBJ.data.messages[i].text}</p>
                                    <h6 class="hour-message">${ messageOBJ.data.messages[i].sendDate.substring(0, 13)}</h6>
                                </div>                                
                            </div>
                        `;
                    }
                }
            }
            else {
                alert(messageOBJ.message);
            }
        }
    });
}

function getUser(id) {

    var url = `/api/user/${id}`;
    console.log('Request to ' + url);


    $.ajax({
        method: 'GET',
        url: url,
        dataType: 'application/json',
        data: null,
        complete: function (data) {

            //deserializa o JSON
            var userOBJ = JSON.parse(data.responseText);

            console.log(userOBJ);

            if (userOBJ.success) {
                //remove o background inicial e chama o chat
                document.querySelector('.bg-home').style.display = "none";

                document.querySelector('#conversation-header').style.display = "block";
                document.querySelector('.conversation-chat').style.display = "block";



                //seta o nome do usuario no header
                document.querySelector('.name-header').innerHTML = userOBJ.data.name + '<br>' + '<span class="hash-indicator">' + userOBJ.data.hash + '</span>';
            }
            else {
                alert(userOBJ.message);
            }
        }
    });
}