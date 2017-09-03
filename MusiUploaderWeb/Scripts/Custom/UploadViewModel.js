function UploadViewModel(uploadUrl, dropBoxID, defaultFileImg, supportedExtensions, dataHeaderObj) {
    var self = this;

    self.uploadUrl = uploadUrl;
    self.dropBoxID = dropBoxID;
    self.defaultFileImg = defaultFileImg;
    self.supportedExtensions = supportedExtensions;
    self.dataHeaderObj = dataHeaderObj;

    //nadopuniti s modelom koji ima album
    self.EAN = ko.observable("");
    self.title = ko.observable("");
    self.updateIndicator = ko.observable("");
    self.mainArtist = ko.observable("");
    self.label = ko.observable("");
    self.genre = ko.observable("");
    self.subGenre = ko.observable("");
    self.approximateReleaseDate = ko.observable("");
    self.pLineText = ko.observable("");
    self.pLineReleaseYear = ko.observable("");
    self.cLineText = ko.observable("");
    self.cLineReleaseYear = ko.observable("");
    self.messageID = ko.observable("");
    self.senderPartyID = ko.observable("");
    self.senderPartyName = ko.observable("");
    self.recipientPartyID = ko.observable("");
    self.recipientPartyName = ko.observable("");
    self.dateTimeCreated = ko.observable("");

    self.showResults = ko.observable(false);
    self.showFileSelect = ko.observable(false);
    self.showSubmit = ko.observable(true);

    self.uploadAlbum = function () {
        var albumModel = ko.mapping.toJS(self);
        ko.utils.postJson("/Upload/UploadForm", { model: albumModel });
    }

    self.fileObj = function (fileName, fileSize, uploadPercentage, messages, showMessages) {
        selfFileObj = this;

        this.fileName = fileName;
        this.fileSize = fileSize;
        this.imgSrc = ko.observable("");

        //nadopuniti s modelom koji imaju pjesme
        this.guid = ko.observable("");
        this.ordinal = ko.observable("");
        this.ISRC = ko.observable("");
        this.title = ko.observable("");
        this.genre = ko.observable("");
        this.subGenre = ko.observable("");
        this.pLineText = ko.observable("");
        this.pLineReleaseDate = ko.observable("");
        this.pLineReleaseYear = ko.observable("");
        this.resourceReleaseDate = ko.observable("");
        this.cLineText = ko.observable("");
        this.cLineReleaseYear = ko.observable("");
        this.durationMin = ko.observable("");
        this.durationSec = ko.observable("");
        this.mainArtist = ko.observable("");
        this.producer = ko.observable("");
        this.audioCode = ko.observable("");
        this.numberOfChannels = ko.observable("");
        this.samplingRate = ko.observable("");
        this.bitsPerSample = ko.observable("");
        this.contributor = ko.observable("");
        this.contributorRole = ko.observable("");

        this.uploadPercentage = ko.observable(uploadPercentage);
        this.messages = ko.observable(messages);
        this.showMessages = ko.observable(showMessages);

        this.deleteFile = function () {
            var guid = ko.mapping.toJS(selfFileObj.guid);
            var fileName = ko.mapping.toJS(selfFileObj.fileName);
            $.ajax({
                url: "/Upload/DeleteTrack",
                data: {
                    guid: guid,
                    fileName: fileName
                },
                success: function (data) {
                    if (data != null) {
                        self.removeTrack(data);
                    }
                }
            });
        }
    }
    self.fileList = ko.observableArray([]);
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
        self.fileList.removeAll();

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
        self.fileList.remove(function (file) {
            return file.guid = guidToRemove;
        });
    }

    self.handleFiles = function (files) {
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var fileName = file.name;
            var extension = self.getExtension(fileName);

            var fileSize = file.size / 1024;
            fileSize = Math.round(fileSize * Math.pow(10, 2)) / Math.pow(10, 2);

            var fileModel = new self.fileObj(fileName, fileSize + "Kb", "0%", "", false);
            self.fileList.push(fileModel);

            if ($.inArray(extension, self.supportedExtensions) > -1) {
                self.HandleFilePreview(fileModel);
                this.UploadFile(file, fileModel);
            } else {
                var message = "File type not valid for file: " + file.name + ".";
                fileModel.messages(message);
                fileModel.showMessages(true);
            }
        }
    }
    self.HandleFilePreview = function (fileModel) {
        fileModel.imgSrc(self.defaultFileImg);
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
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        console.log(xhr);
                        fileModel.messages(xhr.responseText);
                        fileModel.showMessages(true);
                        fileModel.guid(xhr.responseText);
                    }
                }
            };

            xhr.open("POST", self.uploadUrl, true);

            // Set appropriate headers        
            xhr.setRequestHeader("Content-Type", "multipart/form-data");
            xhr.setRequestHeader("X-File-Name", file.name);
            xhr.setRequestHeader("X-File-Size", file.size);
            xhr.setRequestHeader("X-File-Type", file.type);
            if (self.dataHeaderObj != null && self.dataHeaderObj != "") {
                xhr.setRequestHeader("X-File-Data", self.dataHeaderObj);
            }

            // Send the file                        
            xhr.send(file);
    }

    //Load View Model
    self.init();
}
