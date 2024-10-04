/*ارسال فرم از طریق جی کوئری*/
function submitFormByJQuery(formSelector) {
    $(formSelector).submit();
}
function readGrid(gridId) {
    $('#' + gridId).data('kendoGrid').dataSource.read();
}

function readTreeList(treelistId) {
    $('#' + treelistId).data('kendoTreeList').dataSource.read();    
}

var notification = null;
function runAlert(type,message) {
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