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
    var area = document.getElementsByTagName('TEXTAREA')[0];
    var y = document.createElement('P');
    y.className = "whitetext";
    document.getElementById('editDesc').innerHTML = "Edit";
    var z = area.parentNode;
    y.innerHTML = area.value;
    z.insertBefore(y, area);
    z.removeChild(area);
    //z.removeChild(document.getElementsByID('editDesc')[0]);
    editing = false;
}