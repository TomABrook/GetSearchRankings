

$(function() {

// Form Validation function
$("#SearchForm").submit(function() {
    
    var valid = true;

    // Grab current values to validate
    var searchTerms = $("#SearchTermsField").val();
    var url = $("#TargetURLField").val();
    var numResults = $("#NumResultsField").val();

    // Search terms can't be empty
    if (searchTerms == "") {
        $("#SearchTermsField").css("background-color", "RGB(255,200,200)");

        updateError("<p class='error' >*Please enter a search query</p>");

        valid = false;
    } else
     { $("#SearchTermsField").css("background-color", "white");}

    // Url can't be empty
    if (url == "") {
        $("#TargetURLField").css("background-color", "RGB(255,200,200)");

        updateError("<p class='error'>*Please enter a URL</p>");
        
        valid = false;
    } else
     { $("#TargetURLField").css("background-color", "white");}

    // Num results can't be empty and must be an int
    if (numResults == "") {
        $("#NumResultsField").css("background-color", "RGB(255,200,200)");
    
        updateError("<p class='error'>*Please specify how many search results to check</p>");

        valid = false;
    } else if (!isPositiveInteger(numResults)) {
        $("#NumResultsField").css("background-color", "RGB(255,200,200)");

        updateError("<p class='error'>*Number of results must be a positive integer value</p>");

        valid = false;
    } else
     { $("#NumResultsField").css("background-color", "white");}

    return valid;
});

// Used to test number input to make sure it is a positive int
function isPositiveInteger(s) {
  return /^\+?[1-9][\d]*$/.test(s);
}

// Used to insert or update the form error message
function updateError(message) {

    if ($(".error") == "undefined") {

        $("#SearchForm").append(message);

    } else {
        $(".error").html(message);
    }
}

});
