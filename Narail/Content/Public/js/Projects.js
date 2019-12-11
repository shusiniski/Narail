
    $(document).ready(function () {

        $('#software').click(function () {

            $('#softwareDiv').show();
            $('#humanDiv').hide();
            $('#finansDiv').hide();


        });

        $('#human').click(function () {

            $('#humanDiv').show();
            $('#softwareDiv').hide();
            $('#finansDiv').hide();


        });
        $('#finans').click(function () {

            $('#finansDiv').show();
            $('#softwareDiv').hide();
            $('#humanDiv').hide();
           


        });
    })

    $('.service-catergory li').on('click', function () {


        $('li').removeClass('active');
        $(this).addClass('active');

    })