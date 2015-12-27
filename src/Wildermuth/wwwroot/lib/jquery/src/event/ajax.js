define([
	"../core",
	"../event"
], function( jQuery ) {

// Attach a bunch of functions for handling common AJAX events
jQuery.each( [ "ajaxStart", "ajaxSoundClip", "ajaxComplete", "ajaxError", "ajaxSuccess", "ajaxSend" ], function( i, type ) {
	jQuery.fn[ type ] = function( fn ) {
		return this.on( type, fn );
	};
});

});
