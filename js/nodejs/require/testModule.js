var test = function(){
	this.SaySomething = function(something){
		console.log(something);
	}
};

var testObject = new test();

module.exports.test = test;
module.exports.testObject = testObject;
