$(document).ready(function () {
    populateSubServicesDropdown();
    $("#collapseExample").slideUp();
    $("#saveDesc").hide();
    $("#profileDescEdit").hide();
    $("#userNameEditdiv").hide();
    $("#avgRateperhEditr").hide();

    //When main category dropdown changes in add new service
    $("#majorcategory").change(function () {
        populateSubServicesDropdown();
    });

    $("#AddNewServiceBtn").click(function () {
        var id = $("#subcategory").val();
        $.ajax({
            type: "GET",
            url: "/profile/myProfile_addService",
            data: { serviceId: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;
                console.log(result);
                var boxhtml = '<div id="service1edit" class="col-md-3">';
                boxhtml += '<button value="' + result.ID + '" class="btn portfolio-box deleteServiceBtn" data-toggle="tooltip" data-placement="top" title="Remove Service">';
                boxhtml += '<i class="fa fa-4x ' + result.providedService.icon + ' bounceIn text-primary"></i>';
                boxhtml += '<div class="portfolio-box-caption">';
                boxhtml += '<div class="portfolio-box-caption-content">';
                boxhtml += '<div class="project-category text-faded">';
                                                        
                boxhtml += '</div><div class="project-name"><span class="fa fa-trash-o fa-1x"></span></div></div></div></button>';
                boxhtml += '<h5>' + result.providedService.Name + '</h5></div>';
                $("#serviceEditStart").after(boxhtml);

                var seroxhtml = '<div class="col-md-3"><i class="fa fa-4x ' + result.providedService.icon + ' bounceIn text-primary"></i>';
                seroxhtml += '<h3>' + result.providedService.Name + '</h3>';
                seroxhtml += '<p class="text-grey">' + result.providedService.Description + '</p></div>';
                $("#myservicesdiv").append(seroxhtml);
                $("#collapseExample").slideUp();
                
            },
            error: function (response) {
                debugger;
                console.log('eror' + response);
            }
        });
    });

    /*$("#AddNewServiceBtnsss").click(function () {
        var id = $("#subcategory").val();
        $.ajax({
            type: "GET",
            url: "/profile/myProfile_addService",
            data: { serviceId: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;
                
                $("#collapseExample").slideUp();

            },
            error: function (response) {
                debugger;
                console.log('eror' + response);
            }
        });
    });*/

    $(".deleteServiceBtn").click(function () {
        var id = $(this).val();
        var box = $(this).parent();
        console.log(box);
        
        $.ajax({
            type: "GET",
            url: "/profile/myProfile_deleteService",
            data: { serviceId: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;
                box[0].remove();
                $("#" + id).remove();
                $("#collapseExample").slideUp();

            },
            error: function (response) {
                debugger;
                console.log('eror' + response);
            }
        });
    });

    $("#addmorebtn").click(function () {
        $("#collapseExample").toggle();
    });

    $("#avgRateperhr").click(function () {
        $("#avgRateperhr").hide();
        var vals = parseInt($("#avgRateperhr").text());
        console.log(vals);
        $("#avgRateperhEditr").val(vals);
        $("#avgRateperhEditr").show();
    });

    $("#avgRateperhEditr").keypress(function (e) {
        if (e.which == 13) {
            updateRateperHr();
        }
    });

    $("#avgRateperhEditr").blur(function () {
        updateRateperHr();
    });

    function updateRateperHr() {
        var value = $("#avgRateperhEditr").val();
        console.log(value);
        if (value > 0){
            $.ajax({
                type: "GET",
                url: "/profile/myProfile_updateRate",
                data: { newRate: value },
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    debugger;
                    $("#avgRateperhEditr").hide();

                    $("#avgRateperhr").text(value);
                    $("#avgRateperhr").show();

                },
                error: function (response) {
                    debugger;
                    console.log('eror' + response);
                }
            });
            
            
        }
    }

    function populateSubServicesDropdown() {
        var id = $("#majorcategory").val();
        console.log(id);
        $.ajax({
            type: "GET",
            url: "/services/getSubServices",
            data: { serviceId: id },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;
                var data = result;
                //console.log(data[0].subServices[0].Name);
                $("#subcategory").empty();
                for (var i = 0; i < data[0].subServices.length; i++) {
                    var str = '<option value="' + data[0].subServices[i].ID + '">' + data[0].subServices[i].Name + '</option>';
                    $("#subcategory").append(str);
                }
            },
            error: function (response) {
                debugger;
                console.log('eror' + response);
            }
        });
    }

    /*document.getElementById("editDesc").onclick = function () {
        if (document.getElementById('editDesc').innerHTML == "Edit")
            writeData();
        else if (document.getElementById('editDesc').innerHTML == "Save")
            saveEdit();
    }*/

    

    $("#editDesc").click(function () {
        $("#editDesc").hide();
        $("#profileDesc").hide();
        $("#userNamediv").hide();

        var profiledesc = $("#profileDesc").text();
        $("#profileDescEdit").val(profiledesc);
        var uname = $("#userNameOld").text();
        $("#userNewName").val(uname);

        $("#saveDesc").show();
        $("#profileDescEdit").show();
        $("#userNameEditdiv").show();
    });

    $("#saveDesc").click(function () {
        $("#saveDesc").hide();
        $("#profileDescEdit").hide();
        $("#userNameEditdiv").hide();

        var newName = $("#userNewName").val();
        var newDesc = $("#profileDescEdit").val();
        
        $.ajax({
            type: "GET",
            url: "/profile/myProfile_updateNameAndDesc",
            data: { newName: newName, newDesc: newDesc },
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                debugger;
                $("#profileDesc").text(newDesc);
                $("#userNameOld").text(newName);

                $("#editDesc").show();
                $("#profileDesc").show();
                $("#userNamediv").show();
            },
            error: function (response) {
                debugger;
                console.log('eror' + response);
            }
        });

        
    });

    $("#changeDP").click(function () {
        //$("#collapseExample").toggle();
        console.log("change dp div");
        $("#newIMGinput").trigger('click');
    });

    $("#newIMGinput").change(function () {
        //$("#collapseExample").toggle();
        console.log("sadasds22222222222ad");
        if ($("#newIMGinput").val()) {
            console.log("sadasdsad");
            $("#newIMGsubmit").trigger('click');
        }
    });
});



window.onload = function () {
        //if (document.getElementById('editDesc')=="Edit")
        //    document.getElementById("editDesc").onclick = writeData;
        //else if (document.getElementById('editDesc')=="Save")
        //    document.getElementById("editDesc").onclick = saveEdit;

        
    }




