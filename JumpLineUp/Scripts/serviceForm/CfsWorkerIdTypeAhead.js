$(document).ready(function() {

    

    var cfsWorker = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('firstName', 'lastName'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/cfsworkers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#CfsWorkerId').typeahead({
            minLength: 3,
            highlight: true
        },
        {
            name: 'cfsWorkerId',
            display: "cfsWorker as cfsWorker.firstName + ' ' + cfsWorker.lastName",
            source: cfsWorker,
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
        function (e, cfsWorker) {
            vm.cfsWorker.id = cfsWorker.id;
            document.getElementById("selected-cfsWorker").innerHTML = cfsWorker.firstName + " " + cfsWorker.lastName;

            //$("#clients").append("<li class ='list-group-item'>" + client.firstName + " " + client.lastName + "</li>");
        });


});