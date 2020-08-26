$(function () {
    debugger;
    $("#grid").jqGrid
        ({
            url: '/PageOfChampionship/GetValues',
            datatype: 'json',
            mtype: 'Get',
            //table header name   
            colNames: ['Id', 'Amount Of Rounds', 'Date', 'Winner', 'Loser', 'Referee Points'],
            //colModel takes the data from controller and binds to grid   
            colModel: [
                {
                    key: true,
                    hidden: true,
                    name: 'Id',
                    index: 'Id',
                    editable: true
                }, {
                    key: false,
                    name: 'AmountOfRounds',
                    index: 'AmountOfRounds',
                    width: 120,
                    editable: true,
                    search: false
                }, {
                    key: false,
                    name: 'Date',
                    index: 'Date',
                    editable: true,
                    formatter: 'date',
                    formatoptions: {
                        newformat: 'd/m/Y'
                    },
                    width: 80,
                    search: false
                }, {
                    key: false,
                    name: 'Winner',
                    index: 'Winner',
                    editable: true,
                    width: 200,
                    searchoptions: { sopt: ['eq'] }
                }, {
                    key: false,
                    name: 'Loser',
                    index: 'Loser',
                    editable: true,
                    width: 200,
                    searchoptions: { sopt: ['eq'] }
                }, {
                    key: false,
                    name: 'RefereePoints',
                    index: 'RefereePoints',
                    editable: true,
                    width: 110,
                    search: false
                }
            ],
            pager: jQuery('#pager'),
            rowNum: 10,
            rowList: [10, 20, 30, 40],
            height: '100%',
            viewrecords: true,
            loadonce: true,
            caption: 'Battles',
            emptyrecords: 'No records to display',
            jsonReader:
            {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            multiselect: false
            //pager-you have to choose here what icons should appear at the bottom  
            //like edit,create,delete icons  
        }).navGrid('#pager',
            {
                edit: true,
                add: true,
                del: true,
                search: true,
                searchtext: "Search",
                refresh: true,
                refreshtext: "Refresh"
            }, {
            // edit options  
            zIndex: 100,
                url: '/PageOfChampionship/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        }, {
            // add options  
            zIndex: 100,
                url: "/PageOfChampionship/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        }, {
            // delete options  
            zIndex: 100,
                url: "/PageOfChampionship/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this task?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});  
