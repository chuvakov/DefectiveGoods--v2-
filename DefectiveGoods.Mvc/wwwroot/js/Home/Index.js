import HomeService from "./../api/HomeService.js"

$(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();

    let _$createDatepicker = $('#CreateModalDatepicker').datepicker({
        classes: 'z-i-9999 datepicker--dark',
    }).data('datepicker');

    var language = {
        emptyTable: 'Нет данных для отображения',
        info: '_START_-_END_ из _TOTAL_ элементов',
        infoEmpty: 'Нет записей',
        infoFiltered: '(отфильтровано из _MAX_записей)',
        infoPostFix: '',
        infoThousands: ',',
        lengthMenu: 'Показано _MENU_ записей',
        loadingRecords: 'Загрузка...',
        processing: '<i class="fas fa-refresh fa-spin"></i>',
        search: 'Искать' + ':',
        zeroRecords: 'Нет записей, удовлетворяющих поиску',
        paginate: {
            first: '<i class="fas fa-angle-double-left"></i>',
            last: '<i class="fas fa-angle-double-right"></i>',  
            next: '<i class="fas fa-chevron-right"></i>',
            previous: '<i class="fas fa-chevron-left"></i>'
        },
        aria: {
            sortAscending: ": " + 'для сортировки столбцов по возрастанию',
            sortDescending: ": " + 'для сортировки столбцов по убыванию'
        }
    };

     let _$productsTable = $('#TableItems').DataTable({
         paging: true,
         ordering: true,
         order: [[1,'asc']],
         serverSide: true,
         searching: false,
         processing: true,
         autoWidth: false,
         responsive: true,
         language: language,
         "initComplete": function (oSettings) {
             $('[data-toggle="tooltip"]').tooltip();

             let $selectItemsLength = $('[name="TableItems_length"]');
             $selectItemsLength.addClass("select-input");
             $selectItemsLength.wrap("<div class='select' style='width:80px;'></div>");
             $selectItemsLength.css("width", "80px");
             $selectItemsLength.css('background-color', '#152935');
             $selectItemsLength.removeClass('form-select form-select-sm');
             $selectItemsLength.after('<span class="select__arrow"></span>');
         },
         dom: [
             "<'row'<'col-md-12'f>>",
             "<'row'<'col-md-12't>>",
             "<'row mt-2 table__footer'",
             "<'col-lg-1 col-xs-12'<'float-left text-center data-tables-refresh'B>>",
             "<'col-lg-3 col-xs-12'<'float-left text-center'i>>",
             "<'col-lg-3 col-xs-12'<'text-center'l>>",
             "<'col-lg-5 col-xs-12'<'float-right'p>>",
             ">"
         ].join(''),
         ajax: async function (data, callback) {
             let filter = {
                 maxResultCount: data.length,
                 skipCount: data.start
             }
             if (data.order) {
                 let sorting = [];
                 data.order.forEach(e => {
                     let column = data.columns[e.column];

                     if (column.orderable) {
                         sorting.push(`${(column.name && column.name != '' ? column.name : column.data)} ${e.dir}`);
                     }
                 });

                 if (sorting.length > 0) {
                     filter.sorting = sorting.join();
                 }
             }

             let products = await HomeService.getProducts(filter);

             callback({
                 recordsTotal: products.totalCount,
                 recordsFiltered: products.totalCount,
                 data: products.items
             });
         },
         buttons: [
             {
                 className: 'btn-sm btn--circle',
                 name: 'refresh',
                 text: '<i class="fas fa-redo-alt"></i>',
                 action: () => _$productsTable.draw(false),
                 attr: {
                     "data-toggle": "tooltip",
                     title: "Обновить данные таблицы",
                     "data-placement": "top"
                 }
             }
         ],
         responsive: {
             details: {
                 type: "column"
             }
         },
         columnDefs: [
             {
                 targets: 0,
                 className: "control",
                 defaultContent: ""
             },
             {
                 targets: 1,
                 data: "id"
             },
             {
                 targets: 2,
                 data: "code"
             },
             {
                 targets: 3,
                 data: "arrivalNumber"
             },
             {
                 targets: 4,
                 data: "name"
             },
             {
                 targets: 5,
                 data: "arrivalDate"
             },
             {
                 targets: 6,
                 data: "count"
             },
             {
                 targets: 7,
                 data: "categoryNames",
                 render: data => {
                     return data.join(",");
                 }
             }
         ]
     });
});
