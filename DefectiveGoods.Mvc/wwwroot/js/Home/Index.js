import HomeService from "./../api/HomeService.js"

$(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();

    let _$createDatepicker = $('#CreateModalDatepicker').datepicker({
        classes: 'z-i-9999 datepicker--dark',
    }).data('datepicker');

     let _$productsTable = $('#TableItems').DataTable({
         paging: true,
         ordering: true,
         order: [[1,'asc']],
         serverSide: true,
         ajax: async function (data, callback) {
             let filter = {
                 maxResultCount: data.length,
                 skipCount: data.start
             }

             let products = await HomeService.getProducts(filter);

             callback({
                 recordsTotal: products.totalCount,
                 recordsFiltered: products.totalCount,
                 data: products.items
             });

             //$.ajax({
             //    type: "POST",
             //    url: "/Home/GetProducts",
             //    data: filter,
             //    success: function (response) {
             //        callback({
             //            recordsTotal: response.totalCount,
             //            recordsFiltered: response.totalCount,
             //            data: response.items
             //        })
             //    }
             //})

         },

         buttons: [
             {
                 //class: 'buttonRefreshTable',
                 name: 'refresh',
                 text: '<i class="fas fa-redo-alt"></i>',
                 action: () => _$productsTable.draw(false)
             }
         ],

         columnDefs: [
             {
                 targets: 0,
                 data: "id"                 
             },
             {
                 targets: 1,
                 data: "code"
             },
             {
                 targets: 2,
                 data: "arrivalNumber"
             },
             {
                 targets: 3,
                 data: "name"
             },
             {
                 targets: 4,
                 data: "arrivalDate"
             },
             {
                 targets: 5,
                 data: "count"
             }             
         ]
     });
});
