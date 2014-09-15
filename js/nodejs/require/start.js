var test = require('./testModule.js');
console.log("require tests");

var x = new test.test();
x.SaySomething("something");

test.testObject.SaySomething("something 2");
