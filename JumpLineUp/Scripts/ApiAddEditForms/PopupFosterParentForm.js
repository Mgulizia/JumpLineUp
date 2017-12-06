//ADD FOSTER PARENT MODAL ----------------------------------------------------------------------------------------------------------------------
//Opens modal to insert a new Foster Parent to database, validates the data, and posts, returning the data.



    //Creates the modal form
    function FosterParentBootBoxContent() {

        var formContent =
        "<form id='' class='bootBoxForm' action='POST'>" +

            "<div class='row'>" +
            "<div class='col-md-6'>" +

            "<h4>Primary Foster Parent</h4>" +
            "<div class='form-group'>" +
            "<label for='modalFosterParentFirstName1'>First Name</label>" +
            "<input type='text' id='modalFosterParentFirstName1' class='form-control' value='' />" +
            "<span id='errmodalFosterParentFirstName1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentLastName1'>Last Name</label>" +
            "<input type='text' id='modalFosterParentLastName1' class='form-control' value='' />" +
            "<span id='errmodalFosterParentLastName1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentPhone1'>Phone</label>" +
            "<input type='text' id='modalFosterParentPhone1' class='form-control' value='' />" +
            "<span id='errmodalFosterParentPhone1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "</div>" +
            "<div class='col-md-6'>" +

            "<h4>Secondary Foster Parent</h4>" +
            "<div class='form-group'>" +
            "<label for='modalFosterParentFirstName2'>First Name</label>" +
            "<input type='text' id='modalFosterParentFirstName2' class='form-control' value='' />" +
            "<span id='errmodalFosterParentFirstName2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentLastName2'>Last Name</label>" +
            "<input type='text' id='modalFosterParentLastName2' class='form-control' value='' />" +
            "<span id='errmodalFosterParentLastName2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentPhone2'>Phone</label>" +
            "<input type='text' id='modalFosterParentPhone2' class='form-control' value='' />" +
            "<span id='errmodalFosterParentPhone2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "</div>" +
            "</div>" +

            "<hr/>" +

            "<div class='row'>" +
            "<div class='col-md-12'>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentStreet1'>Streed Address</label>" +
            "<input type='text' id='modalFosterParentStreet1' class='form-control' value='' />" +
            "<span id='errmodalFosterParentStreet1' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentStreet2'>Street Address Appendix</label>" +
            "<input type='text' id='modalFosterParentStreet2' class='form-control' value='' />" +
            "<span id='errmodalFosterParentStreet2' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentCity'>City</label>" +
            "<input type='text' id='modalFosterParentCity' class='form-control' value='' />" +
            "<span id='errmodalFosterParentCity' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentState'>State</label>" +
            "<input type='text' id='modalFosterParentState' class='form-control' value='' />" +
            "<span id='errmodalFosterParentState' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "<div class='form-group'>" +
            "<label for='modalFosterParentZip'>Zip Code</label>" +
            "<input type='text' id='modalFosterParentZip' class='form-control' value='' />" +
            "<span id='errmodalFosterParentZip' class='field-validation-error'>&nbsp;</span>" +
            "</div>" +

            "</div>" +
            "</div>" +

        "</form>";

        var object = $("<div/>").html(formContent).contents();

        return object;
    }
    
//Logic for the modal.  on click -> open, on submit -> validate, on validated -> post and return ID of new Foster Parent
    $(".btn-modal-fosterParent").on("click", function () {

        var fosterParentDto =
        {
            FirstName1: null,
            LastName1: null,
            Phone1: null,
            FirstName2: null,
            LastName2: null,
            Phone2: null,
            Street1: null,
            Street2: null,
            City: null,
            State: null,
            Zip: null,
            IsEnabled: true
        };

        bootbox.dialog({
            message: FosterParentBootBoxContent,
            title: "Add Foster Parents",
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                },
                submit: {
                    label: "Add Foster Parents",
                    className: "btn-primary",
                    callback: function (e) {
                        e.preventDefault();
                        var valid = true;

                        if ($("#modalFosterParentFirstName1").val().trim()) {
                            fosterParentDto.FirstName1 = $("#modalFosterParentFirstName1").val();
                            $("#errmodalFosterParentFirstName1").html("&nbsp;");
                        } else {
                            $("#errModalCfsFirstName").html("First name is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentLastName1").val().trim()) {
                            fosterParentDto.LastName1 = $("#modalFosterParentLastName1").val();
                            $("#errmodalFosterParentLastName1").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentLastName1").html("Last name is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentPhone1").val().trim()) {
                            fosterParentDto.Phone1 = $("#modalFosterParentPhone1").val();
                            $("#errmodalFosterParentPhone1").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentPhone1").html("Phone number is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentFirstName2").val().trim()) {
                            fosterParentDto.FirstName2 = $("#modalFosterParentFirstName2").val();
                            $("#errmodalFosterParentFirstName1").html("&nbsp;");
                        } else {
                            fosterParentDto.FirstName2 = "";
                        }

                        if ($("#modalFosterParentLastName2").val().trim()) {
                            fosterParentDto.LastName2 = $("#modalFosterParentLastName2").val();
                            $("#errmodalFosterParentLastName2").html("&nbsp;");
                        } else {
                            fosterParentDto.LastName2 = "";
                        }

                        if ($("#modalFosterParentPhone2").val().trim()) {
                            fosterParentDto.Phone2 = $("#modalFosterParentPhone2").val();
                            $("#errmodalFosterParentPhone2").html("&nbsp;");
                        } else {
                            fosterParentDto.Phone2 = "";
                        }

                        if ($("#modalFosterParentStreet1").val().trim()) {
                            fosterParentDto.Street1 = $("#modalFosterParentStreet1").val();
                            $("#errmodalFosterParentStreet1").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentStreet1").html("Street address is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentStreet2").val().trim()) {
                            fosterParentDto.Street2 = $("#modalFosterParentStreet2").val();
                            $("#errmodalFosterParentStreet2").html("&nbsp;");
                        } else {
                            fosterParentDto.Street2 = "";
                        }

                        if ($("#modalFosterParentCity").val().trim()) {
                            fosterParentDto.City = $("#modalFosterParentCity").val();
                            $("#errmodalFosterParentCity").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentCity").html("City is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentState").val().trim()) {
                            fosterParentDto.State = $("#modalFosterParentState").val();
                            $("#errmodalFosterParentState").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentState").html("State is required");
                            valid = false;
                        }

                        if ($("#modalFosterParentZip").val().trim()) {
                            fosterParentDto.Zip = $("#modalFosterParentZip").val();
                            $("#errmodalFosterParentZip").html("&nbsp;");
                        } else {
                            $("#errmodalFosterParentZip").html("Zip code is required");
                            valid = false;
                        }

                        if (valid) {
                            $.ajax({
                                url: "/api/FosterParents",
                                method: "post",
                                data: fosterParentDto
                            })
                                .done(function (result) {
                                    toastr.success(fosterParentDto.LastName1 + " Family has been added to Lineup.");
                                })
                                .fail(function () {
                                    toastr.error("Foster family was not created, Was there something missing? ");
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