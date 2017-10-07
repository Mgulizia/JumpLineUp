$(document).ready(function() {

    

    var clients = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('masterCaseNumber', 'firstName', 'lastName'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/clients?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#ClientIds').typeahead({
            minLength: 3,
            highlight: true
        },
        {
            name: 'clientId',
            display: "client as client.firstName + ' ' + client.lastName",
            source: clients,
            templates: {
                empty: [
                    '<div>',
                    'none found',
                    '</div>'
                ].join('\n'),
                suggestion: function(data) {
                    return '<div><strong>' + data.firstName + ' ' + data.lastName + '</strong></div>';
                }
            }
        }).on("typeahead:select",
        function(e, client) {
            vm.clientId = client.id;
            document.getElementById("selected-client").innerHTML = client.firstName + " " + client.lastName;

            //$("#clients").append("<li class ='list-group-item'>" + client.firstName + " " + client.lastName + "</li>");
        });


});