var test = require('./testModule');
var test2 = require('./testModule2.js');
console.log("require tests");

var x = new test.test();
x.SaySomething("something");

test.testObject.SaySomething("something 2");
test2();
