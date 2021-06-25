// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

let models = window["powerbi-client"].models;
let reportContainer = $("#report-container").get(0);

// Initialize iframe for embedding report
powerbi.bootstrap(reportContainer, { type: "report" });

let accessToken = 'H4sIAAAAAAAEACWWxw6s2BmE3-VusQRNxtIsyDlnduScoQmW393tmd2RTq1Kf31V__ljpc8wp8Wff__JGColycaOBOnywzviSbA5geBE8RiDvDj9sqGcNuH44h79rdLr99OfwRe9l5l8safqtp12IEWiz33F0j56EYGYzE-h6FcQ-_icMB5f4ajvnUFGt_xme0R0yCefj2MlqWXiAqxxvBOXle5Y2gpmFRdkNS35-lkYu_Wq9g22HY8NEpQGxvq3D_aid6RZWcG1Ce7oFoLHMizG-BJhenm_x76O_opYZYpTmxa2sAyn6vluSH1PUrHgGuHkFrJBzZJEwUKAtaSojrnV-JCLK_YVOg2iYFB-xkxVg2tWjpUEBEO0d8PvRKHMNkiM9sUaIX3ilNC9NQDgyzarOL6aZTUZdrJ6nqEaSzSc5G20BZWy4IE6xquN9-za2_eT2c7K2I7M-khmuvkgKt1E6PcZ6rMM8yQ11HuNBWaETOlLVWjuZMbiHhTBrjch9cdoRgSevOEXs-m-fAxS6OtYPsrs_kyKJ6gqKuIZ1hdqcM7ZAtoHh94BLzEBBHzH8tWl60QMbbzPOOVsEAOpewTM0IJk9m4VV6pjEkNASkWFpaD00yI_2UAXeabxEi4lfJw_H75WqxO1bnbdt6HdcS4tqa0dB_Wda1EfkEODxUjN-rbd1uXuH4DLaSIeLdxMbG_vNX3G8AwuzJDAsP5Q0QZp9n6uyubrOXjsRHy2mCQHak1uHYcsxBEZHzddVcxAMTQ1fcrUZkuelUCBuXnSFw2Kq6kE1ht5BubXMATn3OTohJZHimCRRSytNbFyVwqU5uiEp1tU9GzhDZDJ_ihfuItFpQS8zAiRxWoiA7BYkVQGV7E9JOygnWHfbG92X0g1Thh8sDud5fRwM8LxUfU_9rkkZ50u3qq0ng7UQhlXKALEmVbjEKQRWUukFqcBYFykiNlI61BoPY5w_B1Sp1sOEguH_uIPBFPcUXhLrMEQ8TUN-Vc2BP-iWnradmQ6-wSBixBbSPPDJK73YS5SjeczWksVAS6Sm4CoduwlN2zSgVMQXh1sKKbnYjm5zotqT-Sh3zLzWDSgHvNQlgH1RnaLm-rUfyHtM6Wn5PGT7NEbeQ2-sPkg8OrvGTSSStIjccuEvWhlfDYxMoPhYLgdCu_nkXWi8fR7aCbf2POY1pLDmqjcj5xY1odOCR2gMGcClKaUOUGAhmNNNY1z7EZNfecLSaUyf4RqbjbVg2a3WfAEpCz-PDm6wLP904GiJVy-eUYzIyi4xbhJbfOQdFYVO6xLto2BQUOx8m2MKSM_V0x69nfHKKStok0NIo6kI6jKZbnGeB7hVfWOiRt0nl8cThwK6CqSwq4b4TdiW9_yTXUQmmPEpMW00dlbqjxEvu5Rt2cCpXrKogEZ8V0ht9ozgJn8PTSlVRuJ3vqbF499YbgiQKR4bCDrCHAmHJdOeyA-bDbaYd-mPSuQgh6wp2q-GfWiK1ZpaveGpDHrZe7HYZT0weQFnk9AmZUltiIGrjV3Qad1d-_WyQRE0J1X0z_tmN5FEOhaGFsVfmwuC_a3fF1yceoBJDuVgSp39zCUiCJL0jv9vI5OUXIS4hIflacYLvw-GMzhonvA64IDqE3I2W7v7IwoTUEv3cO9tlCXVNIsnGZLoPFApIz1kIuEDMyFogUFXj4fVI508ofPde3IYUooKYoYXPgXE3NX4dnSeuv9rh42D2UmMApz_KRC25jfjij2KAGYwi_0IhaSYHVRckhBQJfv5Z2PhdIzl8pvXxav3Xma_iOGdwF8hDDpF-3eTwqD5e3hWqwKVmD1Mv751RQSLPWGfKP5TgL6RbEYdWqse2spc5GP4vf73TTwTr4Kiux85rHnghtlhcMhhsYqNOQBrCm6gCH226jYw7js4EgKqPRPgQrsktQ_aCRAtIEuztlY0C5CKy8mWBZ7yjr-8X1orwQs-96IyHfCyrNDvmaZLa5_l6pJJfhVSgG6iI99Y-89MB0saoofxBpylCKjlS-r8DscufPVyd91YEvu-QHTAAilwGIqc8rJqXTabcescwCz7vOTkoDYB6ZlBLdJ8XO2LYRwqxmc2NBUvNXJDVIHDFzkACksYG-zpjgFpNLeUJnN2RJZ4dcVG8BvRyeENfgPJD4b9fpWBMlFv4CKB05P8ID4r2SgRlNiX_cBGq4qIUWTTvbK9Hw9dEzZjvvU4qcJaHLE2u2OIgc3JP1YXm1vc7nRUBy5rooUKK-i9fUKA_DLsCnPVBZ0HXzCcticzRHSpxZmhS_JU1RCqC-ElcMMUIGIKygrbu2LGDiRU-nHZDRq-mKptdnsAOeG5UPK6O_M_DytBumAShSWF3wnfV4zyV5qiM7muA7dV7PqhwJlIitoBgwg5ccFJ3UBUkbNxp3va7hO5VY8cfXqAFtXup1tEyEaicULJHjtjX33uq4cX3y0aTk5wAkxh7Fuz3QUBtKDHhhS-q-__vzrD7s9yzGr5fObWT0Ci23QEzr6Uih6zyPreALrJMaC2or7GZ-BdYFRT80n6QioHVl_hGFbEvEuxMPxeyjV8euXvmKxWIndvUoq4ASf2ljXY61GUQwDdCVJMxKihge3F9cQEunERVzqJlA7b8xwHLetPTt-yGFAc4hfUZtFlbADmIQPEfIBQ2nMawOZ3dgOqXqdtHNHizDo5fxC0d6p4gfEaOWKqm8M4iLmIDXU9cy3IHqFEe2YNTT9vk90n9WWPgQiP4THr-oqGkGMZXGUW-zDtpbalurDRDRz9kZLwmryvqtjMxPcF9kJUTi0g9XRYGD2FgStb4V0JO9LSq99GtmrGT5Pk7lorYmdvA69_Y_Nz9KUmxz8XCYn1y4vGi1xK9J23cBNniquv1VuW0_pcW7lT6ZxeZnnhJUzpHvO8M1M2GEc2IdUl50LujnkxWjktAqZpzVvsDmGr2VdhYXNNtLIVygAhgKH7RC9uru58hi_StgZYnKA11scA4vx3mPLr4l3L-7ADFBXZW3sryEZvmZ9lWyvqjTsGGpcwMbyQNLrDGAyrf38W90y7TdezvG6haiNPOAYhLWUKzcvFz2J6xP1CQ9p2RNNM9whIDqqvyquYbH2ck4fAAQWMgiqX6JR_YX3N260SJdhf5vathIZV83Gr0OtYwQ8zG-7UA2na3vY6Se4vG5UhQfvIdoEgOB4032ofGBJafm4unfmHhse2417cWLZe_tpgAYg0slFHjYN-9iI8X-b__s_1wbt81oMAAA=.eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjpmYWxzZX19';
let embedUrl = 'https://app.powerbi.com/reportEmbed?reportId=f6bfd646-b718-44dc-a378-b73e6b528204&groupId=be8908da-da25-452e-b220-163f52476cdd&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly9XQUJJLVVTLU5PUlRILUNFTlRSQUwtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQiLCJlbWJlZEZlYXR1cmVzIjp7Im1vZGVybkVtYmVkIjp0cnVlLCJjZXJ0aWZpZWRUZWxlbWV0cnlFbWJlZCI6dHJ1ZX19'
let reportId = 'f6bfd646-b718-44dc-a378-b73e6b528204';



// Create a config object with type of the object, Embed details and Token Type
let reportLoadConfig = {
    type: "report",
    tokenType: models.TokenType.Embed,
    accessToken: accessToken,

    // Use other embed report config based on the requirement. We have used the first one for demo purpose
    embedUrl: embedUrl,
    id: reportId,

    // Enable this setting to remove gray shoulders from embedded report
    // settings: {
    //     background: models.BackgroundType.Transparent
    // }
};

// Use the token expiry to regenerate Embed token for seamless end user experience
// Refer https://aka.ms/RefreshEmbedToken
//tokenExpiry = embedData.expiry;

// Embed Power BI report when Access token and Embed URL are available
let report = powerbi.embed(reportContainer, reportLoadConfig);

// Clear any other loaded handler events
report.off("loaded");

// Triggers when a report schema is successfully loaded
report.on("loaded", function () {
    console.log("Report load successful");
});

// Clear any other rendered handler events
report.off("rendered");

// Triggers when a report is successfully embedded in UI
report.on("rendered", function () {
    window.reportRendered = true;
    let element = document.createElement('div');
    element.style.cssText = 'height: 5px;opacity:0.3;background:#000;';
    element.id = "rendered";
    document.body.append(element);
    console.log("Report render successful");
});

// Clear any other error handler events
report.off("error");

// Handle embed errors
report.on("error", function (event) {
    let errorMsg = event.detail;
    console.error(errorMsg);
    return;
});

//AJAX request to get the report details from the API and pass it to the UI
// $.ajax({
//     type: "GET",
//     url: "/getEmbedToken",
//     dataType: "json",
//     success: function (embedData) {

//         // Create a config object with type of the object, Embed details and Token Type
//         let reportLoadConfig = {
//             type: "report",
//             tokenType: models.TokenType.Embed,
//             accessToken: embedData.accessToken,

//             // Use other embed report config based on the requirement. We have used the first one for demo purpose
//             embedUrl: embedData.embedUrl[0].embedUrl,

//             // Enable this setting to remove gray shoulders from embedded report
//             // settings: {
//             //     background: models.BackgroundType.Transparent
//             // }
//         };

//         // Use the token expiry to regenerate Embed token for seamless end user experience
//         // Refer https://aka.ms/RefreshEmbedToken
//         tokenExpiry = embedData.expiry;

//         // Embed Power BI report when Access token and Embed URL are available
//         let report = powerbi.embed(reportContainer, reportLoadConfig);

//         // Clear any other loaded handler events
//         report.off("loaded");

//         // Triggers when a report schema is successfully loaded
//         report.on("loaded", function () {
//             console.log("Report load successful");
//         });

//         // Clear any other rendered handler events
//         report.off("rendered");

//         // Triggers when a report is successfully embedded in UI
//         report.on("rendered", function () {
//             console.log("Report render successful");
//         });

//         // Clear any other error handler events
//         report.off("error");

//         // Handle embed errors
//         report.on("error", function (event) {
//             let errorMsg = event.detail;
//             console.error(errorMsg);
//             return;
//         });
//     },

//     error: function (err) {

//         // Show error container
//         let errorContainer = $(".error-container");
//         $(".embed-container").hide();
//         errorContainer.show();

//         // Get the error message from err object
//         let errMsg = JSON.parse(err.responseText)['error'];

//         // Split the message with \r\n delimiter to get the errors from the error message
//         let errorLines = errMsg.split("\r\n");

//         // Create error header
//         let errHeader = document.createElement("p");
//         let strong = document.createElement("strong");
//         let node = document.createTextNode("Error Details:");

//         // Get the error container
//         let errContainer = errorContainer.get(0);

//         // Add the error header in the container
//         strong.appendChild(node);
//         errHeader.appendChild(strong);
//         errContainer.appendChild(errHeader);

//         // Create <p> as per the length of the array and append them to the container
//         errorLines.forEach(element => {
//             let errorContent = document.createElement("p");
//             let node = document.createTextNode(element);
//             errorContent.appendChild(node);
//             errContainer.appendChild(errorContent);
//         });
//     }
// });