
//---> [modal]
//---> [ajax]
//---> [form]


//-----------------------------[modal]
var size_old;
function showModal(title, html, size = undefined) {

    $(".modal-dialog").removeClass(size_old);
    if (size == undefined) {
        size = 'md';
    }

    size = 'modal-' + size;
    size_old = size;

    $(".modal-dialog").addClass(size);

    $("#commonModal .modal-title").html(title);
    $("#commonModalBody").html(html);

    var myModal = new bootstrap.Modal(document.getElementById("commonModal"), {});
    myModal.show();
    size = undefined;

}
function closeModal() {
    $('#commonModal').modal('hide')
}

//-----------------------------[ajax]
$.ajaxSetup({
    beforeSend: function (xhr) {
        $("#ajax-loading").removeClass("d-none");
    },
    complete: function (xhr) {
        $("#ajax-loading").addClass("d-none");
    }
});

//-----------------------------[form]
function submitFormByJQuery(selector) {
    $(selector).submit();
}

//-----------------------------[notify]
function notify(message, type, position) {
    switch (position) {
        case "top-left":
            position = 1;
            break;
        case "top-center":
            position = 2;
            break;
        case "top-right":
            position = 3;
            break;
        case "mid-left":
            position = 4;
            break;
        case "mid-right":
            position = 5;
            break;
        case "bottom-left":
            position = 6;
            break;
        case "bottom-center":
            position = 7;
            break;
        case "bottom-right":
            position = 8;
            break;
        default:
    }
    $.notify({

        // where to append the toast notification
        wrapper: 'body',

        // toast message
        message: message,

        // success, info, error, warn
        type: type,

        // 1: top-left, 2: top-center, 3: top-right
        // 4: mid-left, 5: mid-right
        // 6: bottom-left, 7: bottom-center, 8: bottom-right
        position: position,

        // or 'rtl'
        dir: 'rtl',

        // enable/disable auto close
        autoClose: true,

        // timeout in milliseconds
        duration: 2000

    });
}



function readGrid(gridId) {
    $('#' + gridId).data('kendoGrid').dataSource.read();
}

function readTreeList(treelistId) {
    $('#' + treelistId).data('kendoTreeList').dataSource.read();
}

var notification = null;
function runAlert(type, message) {
    if (notification != null || notification != undefined) {
        notification.remove();
    }
    notification = Lobibox.notify(type, {
        size: 'mini',
        position: 'bottom center',
        width: 220,
        //delay: true,
        delay: 5000,  //In milliseconds
        icon: false,
        //sound: false,
        //img: '...', //path to image
        showClass: 'fadeInDown',
        hideClass: 'fadeUpDown',
        //size: 'large',
        //title: 'Custom title',
        msg: message
    });
}

function sidebar_c(html, sidebarId) {
    $(".sidebar-c-body").html(html);
    $("#" + sidebarId).toggleClass("sidebar-c-expand");
}

function is_sidebar_c_expand(itemId) {

    var element = $("#" + itemId)
    var result = $(element).hasClass('sidebar-c-expand');

    if (result) {
        return true;
    }

    return false;
}


// In your Javascript (external .js resource or <script> tag)
$(document).ready(function () {
    $('.js-example-basic-single').select2({
        minimumResultsForSearch: -1
    });
});



//select2
$(document).ready(function () {
    $('.js-example-basic-single2').select2({
        minimumResultsForSearch: -1
    });
});
$(document).ready(function () {
    $('.single2-withseach').select2({
    });
});



$('input').iCheck({
    checkboxClass: 'icheckbox_minimal',
    radioClass: 'iradio_minimal'
});

$(".btn-submit-form-jquery").click(function () {
    alert(1);
    $(".submit-form-jquery").submit();
})
