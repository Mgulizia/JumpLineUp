//ADD YOUTH MODAL ----------------------------------------------------------------------------------------------------------------------
//Opens modal to insert a new youth to database, validates the data, and posts, returning the data.

    //Dto object, will be sent to Db
    

    //Gets the restraints select ready


    //Creates the modal form
    function youthBootBoxContent() {

        var formContent =
        "<form id='' class='bootBoxForm' action='POST'>" +

            "<div class='row'>" +
                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='youthFirstName'>First Name</label>" +
                        "<input type='text' id='youthFirstName' class='form-control' value='' />" +
                        "<span id='errYouthFirstName' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='youthLastName'>Last Name</label>" +
                        "<input type='text' id='youthLastName' class='form-control' value='' />" +
                        "<span id='errYouthLastName' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +
            "</div>" +

            "<div class='row'>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='youthBirthDate'>Birth Date</label>" +
                        "<input type='text' id='youthBirthDate' class='form-control datepicker' value='' />" +
                        "<span id='errYouthBirthDate' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

                "<div class='col-md-6'>" +
                    "<div class='form-group'>" +
                        "<label for='restraintTypes'>Restraint Types Needed</label>" +
                        "<select class='form-control' id='restraintTypes'>" +
                        "</select>" +
                        "<span id='errRestraintTypes' class='field-validation-error'>&nbsp;</span>" +
                    "</div>" +
                "</div>" +

            "</div>" +

            "<div class='row'>" +

                "<div class='col-md-12'>" +
                    "<div class='form-group' style ='width: 100%;' >" +
                        "<label for='youthComment'>Optional Details about Youth</label>" +
                        "<textarea id='youthComment' rows='6' class='form-control'  style ='max-width: 100%;' /><br/>" +
                    "</div>" +
                "</div>" +

            "</div>" +

        "</form>";

        $.ajax({
            url: "/api/Restraints",
            type: "get",
            dataType: 'json',
            success: function (json) {
                $("#restraintTypes option").remove();
                $("#restraintTypes").append($('<option>').text("--- Select a car restraint type ---").attr('value', ''));
                $.each(json,
                    function (i, value) {
                        $("#restraintTypes").append($('<option>').text(value.value).attr('value', value.id));
                    });
            }
        });

        //Adds the datepicker to the birthdate
        var object = $("<div/>").html(formContent).contents();


        var minYear = new Date();
        minYear.setFullYear(minYear.getFullYear() - 19);
        var maxYear = new Date();

        object.find(".datepicker").datepicker({
            format: 'mm-dd-yyyy',
            autoclose: true,
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            yearRange: minYear.getFullYear() + ":" + maxYear.getFullYear()
        }).on('changeDate',
            function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });

        

        $(".datepicker").datepicker({
            showButtonPanel: true,
            changeMonth: true,
            changeYear: true,
            showOtherMonths: true,
            selectOtherMonths: true
        });

        return object;
    }

    function processForm() {




    }
    
//Logic for the modal.  on click -> open, on submit -> validate, on validated -> post and return ID of new youth
    $(".btn-modal-youth").on("click", function () {

        var youthDto =
        {
            FirstName: null,
            LastName: null,
            BirthDate: null,
            YouthComment: null,
            RestraintTypeId: 0,
            IsEnabled: true
            }

        bootbox.dialog({
            message: youthBootBoxContent,
            title: "Add a Youth",
            buttons: {
                cancel: {
                    label: "Cancel",
                    className: "btn-default"
                },
                submit: {
                    label: "Add Youth",
                    className: "btn-primary",
                    callback: function (e) {
                        e.preventDefault();
                        var valid = true;

                        if ($("#youthFirstName").val().trim()) {
                            youthDto.FirstName = $("#youthFirstName").val();
                            $("#errYouthFirstName").html("&nbsp;");
                        } else {
                            $("#errYouthFirstName").html("Youth's first name is required");
                            valid = false;
                        }

                        if ($("#youthLastName").val().trim()) {
                            youthDto.LastName = $("#youthLastName").val();
                            $("#errYouthLastName").html("&nbsp;");
                        } else {
                            $("#errYouthLastName").html("Youth's last name is required");
                            valid = false;
                        }

                        if ($("#youthBirthDate").val().trim()) {
                            youthDto.BirthDate = $("#youthBirthDate").val();
                            $("#errYouthBirthDate").html("&nbsp;");
                        } else {
                            $("#errYouthBirthDate").html("Youth's Birthdate is required");
                            valid = false;
                        }

                        youthDto.YouthComment = $("#youthComment").val();

                        if ($("#restraintTypes").val() !== "") {
                            youthDto.RestraintTypeId = $("#restraintTypes").val();
                            $("#errRestraintTypes").html("&nbsp;");
                        } else {
                            $("#errRestraintTypes").html("You must select a restraint type.");
                            valid = false;
                        }

                        if (valid) {
                            $.ajax({
                                url: "/api/Youths",
                                method: "post",
                                data: youthDto
                            })
                                .done(function (result) {
                                    alert(result.id);
                                    toastr.success(youthDto.FirstName + " " + youthDto.LastName + " has been added to Lineup.");
                                })
                                .fail(function () {
                                    toastr.error("Youth was not created, Was there something missing? ");
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