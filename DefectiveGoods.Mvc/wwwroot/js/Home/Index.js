$(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();

    var _$createDatepicker = $('#CreateModalDatepicker').datepicker({
        classes: 'z-i-9999 datepicker--dark',
    }).data('datepicker');

     $('#TableItems').DataTable({
         paging: true,
         ordering: true,
         order: [[1,'asc']],
         serverSide: true,
         ajax: function (data, callback) {

         }
     });
});
