#!/usr/bin/node
console.log('Hello');

var express = require('express');
var app = express();

app.get('/express/',function(req,res){
	res.send("Hello world");
}).listen(8080);

