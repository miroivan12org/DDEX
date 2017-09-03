function UploadViewModel(uploadUrl, dropBoxID, defaultFileImg, supportedExtensions, dataHeaderObj) {
    var self = this;

    self.uploadUrl = uploadUrl;
    self.dropBoxID = dropBoxID;
    self.defaultFileImg = defaultFileImg;
    self.supportedExtensions = supportedExtensions;
    self.dataHeaderObj = dataHeaderObj;
    //nadopuniti s modelom koji ima album


    self.showResults = ko.observable(false);
    self.showFileSelect = ko.observable(false);
    self.showSubmit = ko.observable(true);

    self.fileObj = function (fileName, fileSize, uploadPercentage, messages, showMessages) {
        this.fileName = fileName;
        this.fileSize = fileSize;
        this.imgSrc = ko.observable("");
        //nadopuniti s modelom koji imaju pjesme
        this.guid = ko.observable("");
        this.

        this.uploadPercentage = ko.observable(uploadPercentage);
        this.messages = ko.observable(messages);
        this.showMessages = ko.observable(showMessages);
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
                    var percentageUploaded = parseInt(100 - (e.loaded / e.total * 100));
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
