var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();


connection.on("ReceiveMessage", function (messageSend) {

    if (messageSend.fkIdReceiver == thisUserOBJ.id) {
        var messageFormatted = messageSend.text.replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;");

        var dateFormatted = FormatDate(messageSend.sendDate);

        var messagesList = document.querySelector('.messages');

        messagesList.innerHTML += `
                            <div class="box-message-left">
                                <div class="contact-indicator"></div>

                                <div class="box-contact-message">
                                    <p>${ messageFormatted }</p>
                                    <h6 class="hour-message">${ dateFormatted }</h6>
                                </div>
                            </div>
                        `;

        messagesList.scrollTop = messagesList.scrollHeight;
    }
});



var thisUserOBJ;
var thisUserMessage = document.getElementById('user-message');
var thisReceiverId;

connection.start()
    .then(function () {
        document.getElementById('send-button').addEventListener('click', function (event) {

            if (thisUserMessage.value != "") {

                var now = new Date();
                var day = now.getDate().toString().padStart(2, '0');
                var month = (now.getMonth() + 1).toString().padStart(2, '0');
                var year = now.getFullYear();
                var hour = now.getHours() + ":" + now.getMinutes();

                var dateFormatted = (day + "/" + month + "/" + year + " " + hour).toString();


                var message = thisUserMessage.value;
                thisUserMessage.value = "";

                var messagesList = document.querySelector('.messages');
                messagesList.innerHTML += `
                            <div class="box-message-right">
                                <div class="my-indicator"></div>
                                
                                <div class="box-my-message">
                                    <p>${ message }</p>
                                    <h6 class="hour-message">
                                        ${ dateFormatted}
                                    </h6>
                                </div>                                
                            </div>
                        `;

                messagesList.scrollTop = messagesList.scrollHeight;

                connection.invoke('SendMessage', thisUserOBJ, message, thisReceiverId);
                event.preventDefault();
            }
        });
    })
    .catch(error => {
        console.error(error.message);
    });


function loadUser(idSender) {
    getUser(idSender);
    getMessages(idSender)
}

function getMessages(idSender) {
    var url = `/api/messages/${thisUserOBJ.id}/${idSender}`;
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
                var messagesList = document.querySelector('.messages');
                messagesList.innerHTML = "";

                for (var i = 0; i < messageOBJ.data.messages.length; i++) {

                    var dateFormatted = FormatDate(messageOBJ.data.messages[i].sendDate);

                    if (messageOBJ.data.messages[i].fkIdSender != thisUserOBJ.id) {

                        messagesList.innerHTML += `
                            <div class="box-message-left">
                                <div class="contact-indicator"></div>

                                <div class="box-contact-message">
                                    <p>${ messageOBJ.data.messages[i].text}</p>
                                    <h6 class="hour-message">${ dateFormatted }</h6>
                                </div>
                            </div>
                        `;
                    }
                    else {
                        messagesList.innerHTML += `
                            <div class="box-message-right">
                                <div class="my-indicator"></div>
                                
                                <div class="box-my-message">
                                    <p>${ messageOBJ.data.messages[i].text}</p>
                                    <h6 class="hour-message">
                                        ${ dateFormatted }
                                    </h6>
                                </div>                                
                            </div>
                        `;
                    }

                    messagesList.scrollTop = messagesList.scrollHeight;
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

                thisReceiverId = Number(userOBJ.data.id);
            }
            else {
                alert(userOBJ.message);
            }
        }
    });
}


function FormatDate(dateString) {
    //formatação de data dd/mm/yyyy hh:mm
    dateString = dateString
        .replace(/-/g, '/')
        .replace('T', ' ')
        .substring(0, 16);

    // 2020/07/08 12:30
    // 08/07/2020 12:30
    var dateFormatted = dateString[8] + dateString[9] + dateString[7] + dateString[5] + dateString[6] + dateString[4] +
        dateString[0] + dateString[1] + dateString[2] + dateString[3] + dateString.substring(10, 16);

    return dateFormatted;
}


function SearchUser() {
    var termSearched = document.getElementById('search-input').value;
    var names = document.getElementsByClassName('username');
    var contactsBox = document.getElementsByClassName('contact-item');

    console.log(names);

    if (termSearched != "") {
        for (var i = 0; i < contactsBox.length; i++) {
            //verifica se existe algum nome na lista
            var nameAux = names[i].innerText.toLowerCase()
                .replace(/<span class=\"hash-indicator\">/g, '')
                .replace(/span>/g, '');

            console.log(nameAux);

            if (nameAux.includes(termSearched.toLowerCase())) {
                contactsBox[i].style.display = 'block';
            }
            else {
                contactsBox[i].style.display = 'none';
            }
        }
    }
    else {
        for (var i = 0; i < contactsBox.length; i++) {
            contactsBox[i].style.display = 'block';
        }
    }
}