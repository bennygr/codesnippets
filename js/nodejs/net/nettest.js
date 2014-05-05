#!/usr/bin/node
console.log("A simple tcp server example");

var net = require('net');
//Create a server
var server = net.createServer();
//a list of connected clients
var clientList = [];

//event handling for new connections
server.on('connection', function(client){
	//This is a cool js feature because the clientName property is created at runtim
	//with the calues of remoteAddress and remotePort
	client.clientName = client.remoteAddress + ":" + client.remotePort;
	//print some stuff to stdout
	console.log("client " +
		    client.clientName +
		    " connected");
	//adding out client to the list of conntected clients
	clientList.push(client);
	printClientAmount();
	//Adding event handling for receiving client data
	client.on('data', function(data){ 
			broadcast(data,client);	
		});

	client.on('end',function(){
			removeClient(client);
		})
	client.on('error',function(e){
		console.log(e);
	})
	
	}).listen(8081);


function printClientAmount(){
	console.log(clientList.length + " client(s) connected");
}

function removeClient(client){
	clientList.splice(clientList.indexOf(client),1);
	printClientAmount();
}

//sends a message to all connected clients except to the sender
function broadcast(message, sender) {
	var deadClients = [];
	for(var i=0; i<clientList.length; i++) {
		if(clientList[i] != sender) {
			if(clientList[i].writable){
				clientList[i].write(sender.clientName + " says: " + message);
			}
			else{
				deadClients.push(clientList[i]);
				clientList[i].destroy();
			}
		}
	}

	for(var i=0; i<deadClients.length; i++){
		removeClient(deadClients[i]);
	}
}
