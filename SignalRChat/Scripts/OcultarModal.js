


function ocultarModal() {

    if ($("#MiddleRight").hasClass("hidePanel")) {
        $("#MiddleRight").removeClass("hidePanel");
        $("#MiddleRight").addClass("showPanel");
        //Responsive
        if (screen.width >= 970) {
            $("#MiddleLeft").removeClass("widthNormal");
            $("#MiddleLeft").removeClass("width540");
            $("#MiddleLeft").removeClass("width810");
            $("#MiddleLeft").removeClass("widthMovil");
            $("#MiddleLeft").addClass("width970");
        }
        if (screen.width < 970 && screen.width >= 810) {
            $("#MiddleLeft").removeClass("widthNormal");
            $("#MiddleLeft").removeClass("width970");
            $("#MiddleLeft").removeClass("width540");
            $("#MiddleLeft").removeClass("widthMovil");
            $("#MiddleLeft").addClass("width810");

        }
        if (screen.width < 810 && screen.width >= 540) {
            $("#MiddleLeft").removeClass("widthNormal");
            $("#MiddleLeft").removeClass("width970");
            $("#MiddleLeft").removeClass("width810");
            $("#MiddleLeft").removeClass("widthMovil");
            $("#MiddleLeft").addClass("width540");

        }
        if (screen.width <= 540) {
            $("#MiddleLeft").removeClass("widthNormal");
            $("#MiddleLeft").removeClass("width970");
            $("#MiddleLeft").removeClass("width810");
            $("#MiddleLeft").removeClass("width540");
            $("#MiddleLeft").addClass("widthMovil");

        }

    }
    else {
        $("#MiddleRight").addClass("hidePanel");
        $("#MiddleRight").removeClass("showPanel");
        //Responsive
        $("#MiddleLeft").addClass("widthNormal");
        $("#MiddleLeft").removeClass("width970");
        $("#MiddleLeft").removeClass("width810");
        $("#MiddleLeft").removeClass("width540");
        $("#MiddleLeft").removeClass("widthMovil");
    }
}