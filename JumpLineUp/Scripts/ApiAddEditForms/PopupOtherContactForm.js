//ADD CLIENT MODAL ----------------------------------------------------------------------------------------------------------------------
//Opens modal to insert a new client to database, validates the data, and posts, returning the data.

    //Dto object, will be sent to Db
    

    //Gets the restraints select ready


    //Creates the modal form
    function otherContactBootBoxForm() {

        var formContent =
            "<form id='' class='bootBoxForm' action='POST'>" +
            
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactFirstName'>Contact First Name</label>" +
            "<input type='text' id='modalOtherContactFirstName' class='form-control' value='' />" +
            "<span id='errModalOtherContactFirstName' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactLastName'>Contact Last Name</label>" +
            "<input type='text' id='modalOtherContactLastName' class='form-control' value='' />" +
            "<span id='errModalOtherContactLastName' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactPhone'>Phone Number</label>" +
            "<input type='text' id='modalOtherContactPhone' class='form-control' value='' />" +
            "<span id='errModalOtherContactPhone' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<hr/>" +
            "<div class='row'>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactAddress1'>Contact Street Address</label>" +
            "<input type='text' id='modalOtherContactAddress1' class='form-control' value='' />" +
            "<span id='errModalOtherContactAddress1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-6'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactAddress2'>Contact Street Address Suffix</label>" +
            "<input type='text' id='modalOtherContactAddress2' class='form-control' value='' />" +
            "<span id='errModalOtherContactAddress2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "<div class='row'>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactCity'>City</label>" +
            "<input type='text' id='modalOtherContactCity' class='form-control' value='' />" +
            "<span id='errModalOtherContactCity' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactState'>State</label>" +
            "<select id='modalOtherContactState' class='form-control'>" +
            "<option value='CO'>Colorado</option>"+
            "<option value='IA'>Iowa</option>"+
            "<option value='KS'>Kansas</option>"+
            "<option value='MO'>Missouri</option>"+
            "<option value='NE' selected>Nebraska</option>"+
            "<option value='SD'>South Dakota</option>"+
            "<option value='WY'>Wyoming</option>"+
            "</select>" +
            "<span id='errModalOtherContacttState' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "<div class='col-md-4'>" +
            "<div class='form-group'>" +
            "<label for='modalOtherContactZip'>Zip</label>" +
            "<input type='text' id='modalOtherContactZip' class='form-control' value='' />" +
            "<span id='errModalOtherContactZip' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</form>";

        var object = $("<div/>").html(formContent).contents();

        return object;
    }
    
//Logic for the modal.  on click -> open, on submit -> validate, on validated -> post and return ID of new youth
    $(".btn-modal-otherContact").on("click", function () {

        var otherContactDto =
        {
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
            message: otherContactBootBoxForm,
            title: "Add Other Contact",
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                },
                submit: {
                    label: "Add Other Contact",
                    className: "btn-primary",
                    callback: function (e) {
                        e.preventDefault();
                        var valid = true;

                        if ($("#modalOtherContactFirstName").val().trim()) {
                            otherContactDto.FirstName = $("#modalOtherContactFirstName").val();
                            $("#errModalOtherContactFirstName").html("&nbsp;");
                        } else {
                            $("#errModalOtherContactFirstName").html("Contact first name is required");
                            valid = false;
                        }

                        if ($("#modalOtherContactLastName").val().trim()) {
                            otherContactDto.LastName = $("#modalOtherContactLastName").val();
                            $("#errModalOtherContactLastName").html("&nbsp;");
                        } else {
                            $("#errModalOtherContactLastName").html("Contact last name is required");
                            valid = false;
                        }

                        if ($("#modalOtherContactPhone").val().trim() && !isNaN($("#modalOtherContactPhone").val().trim()) && $("#modalOtherContactPhone").val().trim().length === 10) {
                            otherContactDto.Phone = $("#modalOtherContactPhone").val();
                            $("#errModalOtherContactPhone").html("&nbsp;");
                        } else {
                            $("#errModalOtherContactPhone").html("Phone is required ex:1234567890");
                            valid = false;
                        }

                        if ($("#modalOtherContactAddress1").val().trim()) {
                            otherContactDto.Street1 = $("#modalOtherContactAddress1").val();
                            $("#modalOtherContactAddress1").html("&nbsp;");
                        } else {
                            otherContactDto.Street1 = "";
                        }


                        if ($("#modalOtherContactAddress2").val().trim()) {
                            otherContactDto.Street2 = $("#modalOtherContactAddress2").val();
                        } else {
                            otherContactDto.Street2 = "";
                        }

                        if ($("#modalOtherContactCity").val().trim()) {
                            otherContactDto.City = $("#modalOtherContactCity").val();
                            $("#errModalOtherContactCity").html("&nbsp;");
                        } else {
                            otherContactDto.City = "";
                        }

                        if ($("#modalOtherContactState").val().trim()) {
                            otherContactDto.State = $("#modalOtherContactState").val();
                        } else {
                            otherContactDto.State = "NE";
                        }

                        if ($("#modalOtherContactZip").val().trim() && !isNaN($("#modalOtherContactZip").val().trim()) && $("#modalOtherContactZip").val().trim().length === 5) {
                            otherContactDto.Zip = $("#modalOtherContactZip").val();
                            $("#errModalOtherContactZip").html("&nbsp;");
                        } else {
                            otherContactDto.Zip = "";
                        }



                        if (valid) {
                            $.ajax({
                                url: "/api/OtherContacts",
                                method: "post",
                                data: otherContactDto
                            })
                                .done(function (result) {
                                    toastr.success(otherContactDto.FirstName + " " + otherContactDto.LastName + " has been added to Lineup.");
                                })
                                .fail(function () {
                                    toastr.error("Other Contact was not created, Was there something missing? ");
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