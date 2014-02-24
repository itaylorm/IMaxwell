Ext.define('iMaxwell.view.grid.EmployeeGrid', {
    extend: 'iMaxwell.view.grid.AbstractGrid',    
    alias: 'widget.employeegrid',
    itemId:'employeeGrid',
    requires: [
        'iMaxwell.store.Employees',
        'Ext.toolbar.Paging',
        'Ext.grid.column.Date'
    ],

    initComponent: function () {

        var me = this,
            store = Ext.create('iMaxwell.store.Employees');

        me.store = store;

        me.columns = [
                {
                    header: 'First',
                    dataIndex: 'FirstName',
                    filter: { type: 'string'}
                },
                {
                    header: 'Last',
                    dataIndex: 'LastName',
                    filter: { type: 'string'}
                },
                {
                    header: 'Rate',
                    dataIndex: 'Rate',
                    filter: { type: 'numeric'}
                },
                {
                    header: 'Salary',
                    dataIndex: 'SalariedFlag',
                    filter: { type: 'numeric'}
                },
                {
                    xtype: 'datecolumn',
                    header: 'Birth',
                    dataIndex: 'BirthDate',
                    filter: { type: 'date'}
                },
                {
                    header: 'City',
                    dataIndex: 'City',
                    filter: { type: 'string'}
                },
                {
                    header: 'Zip',
                    dataIndex: 'PostalCode',
                    filter: { type:'string'}
                }
        ];

        me.dockedItems = [
            {
                xtype: 'pagingtoolbar',
                store: store,
                dock: 'bottom',
                displayInfo: true,
                displayMsg: 'Employees {0} - {1} of {2}',
                emptyMsg: 'No Employees'
            }
        ]

        me.callParent(arguments);

    }
});