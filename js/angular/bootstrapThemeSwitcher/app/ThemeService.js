testApp.factory('Theme',function(){
	var currentTheme = null;
	return{
		getCurrentTheme: function(){
			return currentTheme;
		},

		setCurrentTheme: function(theme){
			currentTheme = theme;
		}
	};
});
