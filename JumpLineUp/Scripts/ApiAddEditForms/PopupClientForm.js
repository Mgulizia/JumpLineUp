//ADD CLIENT MODAL ----------------------------------------------------------------------------------------------------------------------
//Opens modal to insert a new client to database, validates the data, and posts, returning the data.

    //Dto object, will be sent to Db
    

    //Gets the restraints select ready


    //Creates the modal form
    function clientBootBoxForm() {

        var formContent =
            "<form id='' class='bootBoxForm' action='POST'>" +
            "<div class='row'>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalClientId'>Client Id</label>" +
            "<input type='text' id='modalClientId' class='form-control' value=''/>" +
            "<span id='errModalClientId' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalMcNumber'>Master Case Number</label>" +
            "<input type='text' id='modalMcNumber' class='form-control' value='' />" +
            "<span id='errModalMcNumber' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<hr/>" +
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientFirstName'>Client First Name</label>" +
            "<input type='text' id='modalClientFirstName' class='form-control' value='' />" +
            "<span id='errModalClientFirstName' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientLastName'>Client Last Name</label>" +
            "<input type='text' id='modalClientLastName' class='form-control' value='' />" +
            "<span id='errModalClientLastName' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientPhone'>Phone Number</label>" +
            "<input type='text' id='modalClientPhone' class='form-control' value='' />" +
            "<span id='errModalClientPhone' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<hr/>" +
            "<div class='row'>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalClientAddress1'>Client Street Address</label>" +
            "<input type='text' id='modalClientAddress1' class='form-control' value='' />" +
            "<span id='errModalClientAddress1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalClientAddress2'>Client Street Address Suffix</label>" +
            "<input type='text' id='modalClientAddress2' class='form-control' value='' />" +
            "<span id='errModalClientAddress2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientCity'>City</label>" +
            "<input type='text' id='modalClientCity' class='form-control' value='' />" +
            "<span id='errModalClientCity' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientState'>State</label>" +
            "<select id='modalClientState' class='form-control'>" +
            "<option value='CO'>Colorado</option>"+
            "<option value='IA'>Iowa</option>"+
            "<option value='KS'>Kansas</option>"+
            "<option value='MO'>Missouri</option>"+
            "<option value='NE' selected>Nebraska</option>"+
            "<option value='SD'>South Dakota</option>"+
            "<option value='WY'>Wyoming</option>"+
            "</select>" +
            "<span id='errModalClientState' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalClientZip'>Zip</label>" +
            "<input type='text' id='modalClientZip' class='form-control' value='' />" +
            "<span id='errModalClientZip' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</form>";

        var object = $("<div/>").html(formContent).contents();

        return object;
    }
    
//Logic for the modal.  on click -> open, on submit -> validate, on validated -> post and return ID of new youth
    $(".btn-modal-client").on("click", function () {

        var clientDto =
        {
                ClientId: null,
                MasterCaseNumber: null,
                FirstName: null,
                LastName: null,
                Phone: null,
                Street1: null,
                Street2: null,
                City: null,
                State: null,
                Zip: null,
                IsEnabled: true
        }

        bootbox.dialog({
            message: clientBootBoxForm,
            title: "Add a Guardian Client",
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                },
                submit: {
                    label: "Add Client",
                    className: "btn-primary",
                    callback: function (e) {
                        e.preventDefault();
                        var valid = true;

                        if ($("#modalClientId").val().trim() && !isNaN($("#modalClientId").val().trim())) {
                            clientDto.ClientId = $("#modalClientId").val();
                            $("#errModalClientId").html("&nbsp;");
                        } else {
                            $("#errModalClientId").html("Client Id is required, and needs to be a number");
                            valid = false;
                        }

                        if ($("#modalMcNumber").val().trim() && !isNaN($("#modalMcNumber").val().trim())) {
                            clientDto.MasterCaseNumber = $("#modalMcNumber").val();
                            $("#errModalMcNumber").html("&nbsp;");
                        } else {
                            $("#errModalMcNumber").html("MC number is required, and needs to be a number");
                            valid = false;
                        }

                        if ($("#modalClientFirstName").val().trim()) {
                            clientDto.FirstName = $("#modalClientFirstName").val();
                            $("#errModalClientFirstName").html("&nbsp;");
                        } else {
                            $("#errModalClientFirstName").html("Client first name is required");
                            valid = false;
                        }

                        if ($("#modalClientLastName").val().trim()) {
                            clientDto.LastName = $("#modalClientLastName").val();
                            $("#errModalClientLastName").html("&nbsp;");
                        } else {
                            $("#errModalClientLastName").html("Client last name is required");
                            valid = false;
                        }

                        if ($("#modalClientPhone").val().trim() && !isNaN($("#modalClientPhone").val().trim()) && $("#modalClientPhone").val().trim().length === 10) {
                            clientDto.Phone = $("#modalClientPhone").val();
                            $("#errModalClientPhone").html("&nbsp;");
                        } else {
                            $("#errModalClientPhone").html("Phone is required ex:1234567890");
                            valid = false;
                        }

                        if ($("#modalClientAddress1").val().trim()) {
                            clientDto.Street1 = $("#modalClientAddress1").val();
                            $("#modalClientAddress1").html("&nbsp;");
                        } else {
                            $("#errModalClientAddress1").html("Address is required");
                            valid = false;
                        }


                        if ($("#modalClientAddress2").val().trim()) {
                            clientDto.Street2 = $("#modalClientAddress2").val();
                        } else {
                            clientDto.Street2 = "";
                        }

                        if ($("#modalClientCity").val().trim()) {
                            clientDto.City = $("#modalClientCity").val();
                            $("#errModalClientCity").html("&nbsp;");
                        } else {
                            $("#errModalClientCity").html("City is required");
                            valid = false;
                        }

                        if ($("#modalClientState").val().trim()) {
                            clientDto.State = $("#modalClientState").val();
                        } else {
                            clientDto.State = "NE";
                        }

                        if ($("#modalClientZip").val().trim() && !isNaN($("#modalClientZip").val().trim()) && $("#modalClientZip").val().trim().length === 5) {
                            clientDto.Zip = $("#modalClientZip").val();
                            $("#errModalClientZip").html("&nbsp;");
                        } else {
                            $("#errModalClientZip").html("Zip is required ex:68000");
                            valid = false;
                        }



                        if (valid) {
                            $.ajax({
                                url: "/api/Clients",
                                method: "post",
                                data: clientDto
                            })
                                .done(function (result) {
                                    alert(result.id);
                                    toastr.success(clientDto.FirstName + " " + clientDto.LastName + " has been added to Lineup.");
                                })
                                .fail(function () {
                                    toastr.error("Client was not created, Was there something missing? ");
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