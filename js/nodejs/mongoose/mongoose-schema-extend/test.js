var mongoose = require('mongoose'),
	extend = require('mongoose-schema-extend');
mongoose.connect('mongodb://localhost/test');

var db = mongoose.connection;
db.once('open',function callback(){
	console.log("connected :)");

	//Vehicle
	var VehicleSchema = mongoose.Schema({
		VehicleName : String
	},{collection: 'vehicles', discriminatorKey : '_type'});
	VehicleSchema.methods.Move = function(){
		console.log(this.VehicleName + " moves somehow");
	};

	//Car
	CarSchema = VehicleSchema.extend({
		Ps: Number
	});
	CarSchema.methods.Move = function(){
		console.log(this.VehicleName + 
					" drives down the road with " + 
					this.Ps +
					" PS");
	};

	//Bus
	BusSchema = VehicleSchema.extend({
		Route : String
	});
	BusSchema.methods.Move = function(){
		console.log(this.VehicleName + 
				    " slowly drives it's route: " + this.Route);
	};


	var Vehicle = mongoose.model('vehicle',VehicleSchema);
	var Car = mongoose.model('car',CarSchema);
	var Bus = mongoose.model('bus',BusSchema);

	var car = new Car({
		VehicleName: "Honda CRX",
		Ps:200
	});
	var bus = new Bus({
		VehicleName: "Old yellow Schoolbus",
		Route: 66
	});

	car.save(function(err){
		bus.save(function(err){
			Vehicle.find({},function(err,vehicles){
				if(err)
				console.log(err);
				else {
					console.log("found " + vehicles.length + " vehicles");
					vehicles.forEach(function(vehicle){
						vehicle.Move()
					});
				}
			});
		});
	})

});
