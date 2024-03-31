/// <reference path="jquery-3.2.1.js" />

$(document).ready(function () {

    $('#drpCategory').change(function () {

        var catid = $(this).val();

        if (catid!='') {

           /* $.ajax({
                url: '/FOAdmin/ManageFood/GetSubCatByCat/',
                type: 'post',
                data: { id: catid }, dataType: 'json',
                success: function (data) {
                    $('#drpSubCategory').empty().append("<option value=0>Select SubCategory</option>");
                    $.each(data, function (i) {
                        //i is looping varialbe here and it loops through data
                        $('#drpSubCategory').append("<option value='" + data[i].Value + "'>" + data[i].Text + "</option>");

                    });
                },
                error:function(xhr)
                {
                    $('#msg').text(xhr.error);
                    $('.panel-body').show();
                }
            });*/

            $.post('/FOAdmin/ManageFood/GetSubCatByCat/', { id: catid },
                function (data) {
                    $('#drpSubCategory').empty().append("<option value=0>Select SubCategory</option>");
                    $.each(data, function (i) {
                        //i is looping varialbe here and it loops through data
                        $('#drpSubCategory').append("<option value='" + data[i].Value + "'>" + data[i].Text + "</option>");
                    })
                },'json');
        }
        else
        {
            $('#msg').text('please select category');
            $('.panel-body').show();
            $('#drpSubCategory').empty().append("<option value=0>Select SubCategory</option>");
        }

    });

    //$('#drpSubCategory').change(function () {
    //    var sid = $(this).val();
    //    console.log(sid);
    //    $('#sid').val(sid);
    //    console.log($('#sid').val());
    //});

});