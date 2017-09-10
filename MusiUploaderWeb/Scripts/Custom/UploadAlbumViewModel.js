function UploadAlbumViewModel(uploadUrl, dropBoxID, defaultFileImg, supportedExtensions, dataHeaderObj) {
    var self = this;

    self.Artist = function (role, artistName) {
        this.roles = ko.observable();
        this.artistName = ko.observable();
        this.selectedRole = ko.observable();
        this.canBeDeleted = ko.observable();

        this.removeArtist = function () {
            self.artists.remove(this);
        }
    }

    self.trackModel = function (fileName, fileSize, uploadPercentage, messages, showMessages) {
        selfTrackModel = this;

        this.fileName = fileName;
        this.fileSize = fileSize;
        this.imgSrc = ko.observable("");

        //nadopuniti s modelom koji imaju pjesme
        this.trackID = ko.observable("");
        this.trackName = ko.observable("");
        this.ISRC = ko.observable("");
        this.version = ko.observable("");
        this.copyRightYears = ko.observable();
        this.selectedCopyRightYear = ko.observable();
        this.copyRightHolder = ko.observable("");
        this.trackArtist = ko.observable("");
        this.artists = ko.observableArray([]);
        this.publishers = ko.observable();
        this.selectedPublisher = ko.observable();
        this.contributors = ko.observableArray([]);
        this.coverVersion = ko.observable(true);
        this.explicitContent = ko.observable(true);
        this.liveVersion = ko.observable(true);
        this.medley = ko.observable(true);

        this.uploadPercentage = ko.observable(uploadPercentage);
        this.messages = ko.observable(messages);
        this.showMessages = ko.observable(showMessages);

        this.Contributor = function (role, contributorName, publisher) {
            this.roles = ko.observable();
            this.contributorName = ko.observable();
            this.publishers = ko.observable();
            this.selectedPublisher = ko.observable();
            this.selectedRole = ko.observable();
            this.canBeDeleted = ko.observable();

            this.removeContributor = function () {
                selfTrackModel.contributors.remove(this);
            }
        }

        this.addNewContributor = function () {
            var newContributors = ko.mapping.toJS(this.contributors)[0];
            var newContributor = new selfTrackModel.Contributor();
            newContributor.roles(newContributors.roles);

            this.contributors.push(newContributor);
        }

        this.Artist = function (role, artistName) {
            this.roles = ko.observable();
            this.artistName = ko.observable();
            this.selectedRole = ko.observable();
            this.canBeDeleted = ko.observable();

            this.removeArtist = function () {
                selfTrackModel.artists.remove(this);
            }
        }

        this.addNewArtist = function () {
            var newArtists = ko.mapping.toJS(this.artists)[0];
            var newArtist = new selfTrackModel.Artist();
            newArtist.roles(newArtists.roles);
            newArtist.canBeDeleted(true);

            this.artists.push(newArtist);
        }

        this.deleteFile = function () {
            var ID = ko.mapping.toJS(selfTrackModel.trackID);
            var fileName = ko.mapping.toJS(selfTrackModel.fileName);
            $.ajax({
                url: "/Upload/DeleteTrack",
                data: {
                    ID: ID,
                    fileName: fileName
                },
                success: function (data) {
                    if (data !== null) {
                        self.removeTrack(data);
                    }
                }
            });
        }
    }

    self.uploadUrl = uploadUrl;
    self.dropBoxID = dropBoxID;
    self.defaultFileImg = defaultFileImg;
    self.supportedExtensions = supportedExtensions;
    self.dataHeaderObj = dataHeaderObj;

    //basic details
    self.languages = ko.observable();
    self.selectedLanguage = ko.observable();
    self.title = ko.observable("");
    self.version = ko.observable("");
    self.artists = ko.observableArray([]);
    self.mainGenres = ko.observable();
    self.selectedMainGenre = ko.observable();
    self.subGenres = ko.observable();
    self.selectedSubGenre = ko.observable();

    //track model
    self.trackList = ko.observableArray([]);

    //release detail
    self.labelName = ko.observable("");
    self.catalogueNumber = ko.observable("");
    self.barcode = ko.observable("");
    self.copyRightYears = ko.observable();
    self.selectedCopyRightYear = ko.observable();
    self.copyRightRecording = ko.observable();
    self.originalRelease = ko.observable();
    self.digitalReleaseDate = ko.observable();

    //cover info
    self.coverID = ko.observable();
    self.artistName = ko.observable("");
    self.copyrightArtworkYear = ko.observable("");

    self.showResults = ko.observable(false);
    self.showFileSelect = ko.observable(false);
    self.showSubmit = ko.observable(true);

    self.uploadAlbum = function () {
        var albumModel = ko.mapping.toJS(self);
        ko.utils.postJson("/Upload/UploadForm", { model: albumModel });
    }
    
    self.init = function () {
        // Check if FileAPI and XmlHttpRequest.upload are supported, so that we can hide the old style input method
        if (window.File && window.FileReader && window.FileList && window.Blob && new XMLHttpRequest().upload) {
            self.showFileSelect(false);
            self.showSubmit(false);

            var dropbox = document.getElementById(self.dropBoxID);
            // init event handlers
            dropbox.addEventListener("dragenter", self.dragEnter, false);
            dropbox.addEventListener("dragexit", self.dragExit, false);
            dropbox.addEventListener("dragleave", self.dragExit, false);
            dropbox.addEventListener("dragover", self.dragOver, false);
            dropbox.addEventListener("drop", self.drop, false);
        }
        var artist = new self.Artist();
        artist.canBeDeleted(false);
        $.get('/upload/GetRoles/').done(artist.roles);
        self.artists.push(artist);

        $.get('/upload/GetYears/').done(self.copyRightYears);
        $.get('/upload/GetGenres').done(self.mainGenres);
        $.get('/upload/GetGenres').done(self.subGenres);
        $.get('/upload/GetLanguages/').done(self.languages);
    }

    self.dragEnter = function (e) {
        e.stopPropagation();
        e.preventDefault();
    }

    self.dragExit = function (e) {
        e.stopPropagation();
        e.preventDefault();

        $("#" + self.dropBoxID).removeClass("dropzone-active");
    }

    self.dragOver = function (e) {
        e.stopPropagation();
        e.preventDefault();

        $("#" + self.dropBoxID).addClass("dropzone-active");
    }

    self.drop = function (e) {
        e.stopPropagation();
        e.preventDefault();

        $("#" + self.dropBoxID).removeClass("dropzone-active");

        var files = e.dataTransfer.files;
        var count = files.length;
        self.trackList.removeAll();

        if (count > 0) {
            self.showResults(true);
            self.handleFiles(files);
        } else {
            self.showResults(false);
        }
    }

    self.getExtension = function (fileName) {
        var regex = /(?:\.([^.]+))?$/;

        var extension = regex.exec(fileName)[1];
        return extension;
    }

    self.removeTrack = function (guidToRemove) {
        self.trackList.remove(function (file) {
            return file.guid = guidToRemove;
        });
    }

    self.onFileSelect = function (vm, evt) {
        var f = evt.target.files;
        var numberOfFiles = f.length;
        if (numberOfFiles > 0) {
            self.handleFiles(evt.target.files);
        }
    }

    self.handleFiles = function (files) {
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var fileName = file.name;
            var extension = self.getExtension(fileName);

            var fileSize = file.size / 1024;
            fileSize = Math.round(fileSize * Math.pow(10, 2)) / Math.pow(10, 2);

            if ($.inArray(extension, self.supportedExtensions) > -1) {
                var fileModel = new self.trackModel(fileName, fileSize + "Kb", "0%", "", false);

                var artist = new selfTrackModel.Artist();
                artist.canBeDeleted(false);
                $.get('/upload/GetRoles/').done(artist.roles);
                fileModel.artists.push(artist);

                var contributor = new selfTrackModel.Contributor();
                contributor.canBeDeleted(false);
                $.get('/upload/GetPublishers/').done(contributor.publishers);
                $.get('/upload/GetRolesForContributors/').done(contributor.roles);
                fileModel.contributors.push(contributor);

                $.get('/upload/GetPublishers/').done(fileModel.publishers);
                $.get('/upload/GetYears/').done(fileModel.copyRightYears);
                self.trackList.push(fileModel);
                self.HandleFilePreview(fileModel);
                this.UploadFile(file, fileModel);
            } else {
                var message = "File type not valid for file: " + file.name + ".";
                alert(message);
            }
        }
    }
    self.HandleFilePreview = function (fileModel) {
        fileModel.imgSrc(self.defaultFileImg);
    }

    self.addNewArtist = function () {
        var newArtists = ko.mapping.toJS(self.artists)[0];
        var newArtist = new self.Artist();
        newArtist.roles(newArtists.roles);
        newArtist.canBeDeleted(true);

        self.artists.push(newArtist);
    }

    self.UploadFile = function (file, fileModel) {
        fileModel.uploadPercentage("0%");

        var xhr = new XMLHttpRequest();
        xhr.upload.addEventListener("progress", function (e) {
            if (e.lengthComputable) {
                var percentageUploaded = Math.ceil((e.loaded / e.total * 100));
                fileModel.uploadPercentage(percentageUploaded + "%");
            }
        }, false);

        // File uploaded
        xhr.addEventListener("load", function () {
            fileModel.uploadPercentage("100%");
        }, false);

        // file received/failed
        xhr.onreadystatechange = function (e) {
            if (xhr.readyState === 4) {
                if (xhr.status === 200) {
                    console.log(xhr);
                    fileModel.messages(xhr.responseText);
                    fileModel.showMessages(true);
                    fileModel.trackID(xhr.responseText);
                }
            }
        };

        xhr.open("POST", self.uploadUrl, true);

        // Set appropriate headers        
        xhr.setRequestHeader("Content-Type", "multipart/form-data");
        xhr.setRequestHeader("X-File-Name", file.name);
        xhr.setRequestHeader("X-File-Size", file.size);
        xhr.setRequestHeader("X-File-Type", file.type);
        if (self.dataHeaderObj !== null && self.dataHeaderObj !== "") {
            xhr.setRequestHeader("X-File-Data", self.dataHeaderObj);
        }

        // Send the file                        
        xhr.send(file);
    }

    //Load View Model
    self.init();
}
