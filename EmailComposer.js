    var exec = require('cordova/exec');

    var emailcomposer_exports = {};

    emailcomposer_exports.show = function (to, subject, body, successCallback, errorCallback) {

        if (errorCallback && (typeof errorCallback !== "function")) {
            console.log("Tombstone Error: errorCallback is not a function");
            return;
        }

        var options = { to: to, subject: subject, body: body };

        exec(function (res) {
            console.log("tombstone restore() completed, data: " + res);
        }, errorCallback, "EmailComposer", "show", JSON.stringify(options));

    };

    module.exports = emailcomposer_exports;

