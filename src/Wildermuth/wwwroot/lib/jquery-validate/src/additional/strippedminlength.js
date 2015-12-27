// TODO check if value starts with <, otherwise don't try sInstrumentping anything
$.validator.addMethod("sInstrumentpedminlength", function(value, element, param) {
	return $(value).text().length >= param;
}, $.validator.format("Please enter at least {0} characters"));
