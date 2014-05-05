#!/usr/bin/node
var ffi = require('ffi');

var libhello = ffi.Library('./libhello', {
	    'add': [ 'int', ['int','int' ] ],
	    'hello': [ 'void', [] ],
	    'getstring': [ 'string', [] ],
	    'getstdstring': [ 'string', [] ],
	    'dosomething' : ['void', ['pointer']],
	    'registerclb' : ['void',['pointer']],
	    'unregisterclb' : ['void',['pointer']],
	    'dosomething2' : ['void', []],
		"inc": [ "void", [] ],
	}); 

var x = libhello.add(116.0,1.0);
console.log(x);

var string = libhello.getstring();
console.log(string);

var stdstring = libhello.getstdstring();
console.log(stdstring);	

var clb1 = ffi.Callback("void",["string"], function(s){
	console.log("I am the 1. callback and you gave me %s",s);
});

var clb2 = ffi.Callback("void",["string"],function(s) {
	console.log("Hello! I am the 2nd callback and i got the value %s",s);
});

libhello.dosomething(clb1);
libhello.registerclb(clb1);
libhello.registerclb(clb2);
libhello.dosomething2();
libhello.unregisterclb(clb1);
libhello.unregisterclb(clb2);
libhello.dosomething2();

libhello.inc();
libhello.inc();
libhello.inc();
libhello.inc();
libhello.inc();
