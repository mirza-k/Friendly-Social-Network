"use strict"

//import { signalR } from "./signalr/dist/browser/signalr"

var connection = new signalR.HubConnectionBuilder().withUrl('/chathub').build();

connection.start()
    .then(function () { alert("Uspjesno"); })
    .catch(function () { alert("Neuspjesno") });


var sendButton = document.getElementById("sendmessage");
sendButton.addEventListener("click", function () {
    var message = document.getElementById("message").value;
    console.log(message);
    connection.send("SendMessage", "Mirza", message);
})

connection.on("RecieveMessage", function (name, message) {
    var div = document.createElement("div");
    var p1 = document.createElement("p");
    var p2 = document.createElement("p");
    p1.innerHTML = name.toUpperCase();
    p2.innerHTML = message;
    div.appendChild(p1);
    div.appendChild(p2);
    document.getElementById("messages").appendChild(div);
})

function SendMessage(username) {
    var message = document.getElementById("message").value;
    connection.send("SendMessage", username, message);
}