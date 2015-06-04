$(document).ready(function () {
    populateSubServicesDropdown();
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

    $("#AddNewServiceBtn").click(function () {
        
    });

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
});



window.onload = function () {
        //if (document.getElementById('editDesc')=="Edit")
        //    document.getElementById("editDesc").onclick = writeData;
        //else if (document.getElementById('editDesc')=="Save")
        //    document.getElementById("editDesc").onclick = saveEdit;

        document.getElementById("editDesc").onclick = function () {
            if (document.getElementById('editDesc').innerHTML == "Edit")
                writeData();
            else if (document.getElementById('editDesc').innerHTML == "Save")
                saveEdit();
        }
    }




function writeData() {
    var butt = document.getElementById('editDesc');
    butt.innerHTML="Save";
        
    var obj = document.getElementById("profileDesc");
        
    while (obj.nodeType != 1) {
        obj = obj.parentNode;
    }
    if (obj.tagName == 'TEXTAREA' || obj.tagName == 'A') return;
    while (obj.nodeName != 'P' && obj.nodeName != 'HTML') {
        obj = obj.parentNode;
    }
    if (obj.nodeName == 'HTML') return;
    var x = obj.innerHTML;
    var y = document.createElement('TEXTAREA');
    y.style.height = "100px";
    y.style.width = "80%";
    var z = obj.parentNode;
    z.insertBefore(y, obj);
    z.insertBefore(butt, obj);
    z.removeChild(obj);
    y.value = x;
    y.focus();
    editing = true;


    //document.getElementById("profileDesc").innerHTML = "Changed Paragraph Content";
    //return false;
}

function saveEdit() {
    window.location.reload();

    //var area = document.getElementsByTagName('TEXTAREA')[0];
    //var y = document.createElement('P');
    //y.className = "whitetext";
    //y.id = "profileDesc";
    //document.getElementById('editDesc').innerHTML = "Edit";
    //var name = document.getElementById('FullName');
    //var z = area.parentNode;
    //y.innerHTML = area.value;
    //z.insertBefore(y, area);
    
    //z.removeChild(area);
    ////z.removeChild(document.getElementsByID('editDesc')[0]);
    //editing = false;
}