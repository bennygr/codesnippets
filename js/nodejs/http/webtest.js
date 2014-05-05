#!/usr/bin/node
//---------------------------------------------------
var http = require('http');
var port = 8080;
var server = http.createServer(
	function(req,res)
	{
		var exec = require('child_process').exec;
		exec('date',
		     function(err,stdout,stderr)
		     {
			var response = "Server time: ";
			response += stdout;
			response += "<br><br>"

			var fs = require('fs');
			response += "<pre>";
			var issue = fs.readFileSync('/etc/issue');
			response += issue;
			response += "</pre>";

			res.writeHead(200,{'Content-Type': 'text/html'} );
			res.end(response);
		     });
	}).listen(port);
console.log("server started on port " + port);
//---------------------------------------------------
