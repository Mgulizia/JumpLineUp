//ADD CFS WORKER MODAL ----------------------------------------------------------------------------------------------------------------------
//Opens modal to insert a new CFS Worker to database, validates the data, and posts, returning the data.

    //Dto object, will be sent to Db
    

    //Gets the restraints select ready


    //Creates the modal form
    function cfsBootBoxContent() {

        var formContent =
        "<form id='' class='bootBoxForm' action='POST'>" +

            "<div class='row'>" +
                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='modalCfsFirstName'>First Name</label>" +
                        "<input type='text' id='modalCfsFirstName' class='form-control' value='' />" +
                        "<span id='errModalCfsFirstName' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='modalCfsLastName'>Last Name</label>" +
                        "<input type='text' id='modalCfsLastName' class='form-control' value='' />" +
                        "<span id='errModalCfsLastName' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +
            "</div>" +

            "<div class='row'>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='modalCfsEmail'>CFS Worker Email</label>" +
                        "<input type='text' id='modalCfsEmail' class='form-control' value='' />" +
                        "<span id='errModalCfsEmail' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='modalCfsPhone'>CFS Worker Phone</label>" +
                        "<input type='text' id='modalCfsPhone' class='form-control' value='' />" +
                        "<span id='errModalCfsPhone' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

            "</div>" +

            "<div class='row'>" +

                "<div class='col-md-12'>" +
                    "<div class='form-group'>" +
                        "<label for='modalCfsOfficeLocation'>Cfs Office Location</label>" +
                        "<input type='text' id='modalCfsOfficeLocation' class='form-control' value='' />" +
                        "<span id='errModalCfsOfficeLocation' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

            "</div>" +

        "</form>";

        var object = $("<div/>").html(formContent).contents();

        return object;
    }
    
//Logic for the modal.  on click -> open, on submit -> validate, on validated -> post and return ID of new youth
    $(".btn-modal-cfs").on("click", function () {

        var cfsDto =
        {
            FirstName: null,
            LastName: null,
            Email: null,
            Phone: null,
            OfficeLocation: null,
            IsEnabled: true
            }

        bootbox.dialog({
            message: cfsBootBoxContent,
            title: "Add a State CFS Worker",
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                },
                submit: {
                    label: "Add CFS Worker",
                    className: "btn-primary",
                    callback: function (e) {
                        e.preventDefault();
                        var valid = true;

                        if ($("#modalCfsFirstName").val().trim()) {
                            cfsDto.FirstName = $("#modalCfsFirstName").val();
                            $("#errModalCfsFirstName").html("&nbsp;");
                        } else {
                            $("#errModalCfsFirstName").html("CFS first name is required");
                            valid = false;
                        }

                        if ($("#modalCfsLastName").val().trim()) {
                            cfsDto.LastName = $("#modalCfsLastName").val();
                            $("#errModalCfsLastName").html("&nbsp;");
                        } else {
                            $("#errModalCfsLastName").html("CFS last name is required");
                            valid = false;
                        }

                        if ($("#modalCfsEmail").val().trim()) {
                            cfsDto.Email = $("#modalCfsEmail").val();
                            $("#errModalCfsEmail").html("&nbsp;");
                        } else {
                            $("#errModalCfsEmail").html("CFS email address is required");
                            valid = false;
                        }

                        if ($("#modalCfsPhone").val().trim() && !isNaN($("#modalCfsPhone").val().trim()) && $("#modalCfsPhone").val().trim().length === 10) {
                            cfsDto.Phone = $("#modalCfsPhone").val();
                            $("#errModalCfsPhone").html("&nbsp;");
                        } else {
                            $("#errModalCfsPhone").html("Phone is required ex:1234567890");
                            valid = false;
                        }

                        if ($("#modalCfsOfficeLocation").val().trim()) {
                            cfsDto.OfficeLocation = $("#modalCfsOfficeLocation").val();
                            $("#errModalCfsOfficeLocation").html("&nbsp;");
                        } else {
                            $("#errModalCfsOfficeLocation").html("Office location is required");
                            valid = false;
                        }
                        

                        if (valid) {
                            $.ajax({
                                url: "/api/CfsWorkers",
                                method: "post",
                                data: cfsDto
                            })
                                .done(function (result) {
                                    toastr.success(cfsDto.FirstName + " " + cfsDto.LastName + " has been added to Lineup.");
                                })
                                .fail(function () {
                                    toastr.error("CFS Worker was not created, Was there something missing? ");
                                });
                        } else {
                            return false;
                        }


                    }
                }

            }
        });
    });
//END OF ADD YOUTH MODAL ------------------------------------------------------------------------------------------------------------------------