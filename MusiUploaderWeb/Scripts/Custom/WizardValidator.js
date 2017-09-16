$(document).ready(function () {
    var $validator = $("#commentForm").validate({
        rules: {
            title: {
                required: true
            },
            language: {
                required: true
            },
            version: {
                required: true
            },
            artistRole: {
                required: true
            },
            artistName: {
                required: true
            },
            mainGenre: {
                required: true
            },
            subGenre: {
                required: true
            },
            trackName: {
                required: true
            },
            ISRC: {
                required: true
            },
            copyRightYear: {
                required: true
            },
            copyRightHolder: {
                required: true
            },
            trackArtist: {
                required: true
            },
            publisherName: {
                required: true
            },
            contributorRole: {
                required: true
            },
            contributorName: {
                required: true
            },
            publisher: {
                required: true
            },
            labelName: {
                required: true
            },
            catalogueNumber: {
                required: true
            },
            barcode: {
                required: true
            },
            copyRightRecording: {
                required: true
            },
            originalRelease: {
                required: true
            },
            digitalReleaseDate: {
                required: true
            },
            copyrightArtworkYear: {
                required: true
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
            var $valid = $("#commentForm").valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            }
        }
    });
});