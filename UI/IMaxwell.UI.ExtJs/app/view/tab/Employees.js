Ext.define('iMaxwell.view.tab.Employees', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.employees',
    layout: 'fit',
    title: 'Employees',
    requires: [
        'Ext.toolbar.Paging',
        'Ext.grid.column.Date'
    ],
    initComponent: function() {

        this.callParent(arguments);

        this.configureGrid();

    },
    configureGrid: function () {

        var store = Ext.create('iMaxwell.store.Employees'),
            grid = Ext.create('Ext.grid.Panel', {
            itemId: 'employeeList',
            columns: [
                {
                    header: 'First',
                    dataIndex: 'FirstName'
                },
                {
                    header: 'Last',
                    dataIndex: 'LastName'
                },
                {
                    header: 'Rate',
                    dataIndex: 'Rate'
                },
                {
                    header: 'Salary',
                    dataIndex: 'SalariedFlag'
                },
                {
                    xtype:'datecolumn',
                    header: 'Birth',
                    dataIndex: 'BirthDate',
                    format: 'Y-m-d'
                },
                {
                    header: 'City',
                    dataIndex: 'City'
                },
                {
                    header: 'Zip',
                    dataIndex: 'PostalCode'
                }
            ],
            store: store,
            dockedItems: [
                {
                    xtype: 'pagingtoolbar',
                    store: store,
                    dock: 'bottom',
                    displayInfo: true,
                    displayMsg: 'Employees {0} - {1} of {2}',
                    emptyMsg: 'No Employees'
                }
            ]
        });

        this.items.add(grid);
    }
});