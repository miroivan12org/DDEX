$(document).ready(function () {
    var $validator = $("#commentForm").validate({
        rules: {
            title: {
                required: true,
                email: true,
                minlength: 3
            },
            namefield: {
                required: true,
                minlength: 3
            },
            urlfield: {
                required: true,
                minlength: 3,
                url: true
            }
        }
    });

    $("#wizard").bootstrapWizard({
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length;
            var $current = index + 1;
            var $percent = ($current / $total) * 100;
            $('#wizard .progress-bar').css({ width: $percent + '%' });
        },
        onTabClick: function (tab, navigation, index) {
            return false;
        },
        //'nextSelector': 'button-next',
        //'previousSelector': 'button-previous',
        onNext: function (tab, navigation, index) {
            //validacija napravi funckiju koja će okidati validate forme
            var $valid = $("#commentForm").valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        }
    });
});