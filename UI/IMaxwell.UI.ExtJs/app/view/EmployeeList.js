Ext.define('iMaxwell.view.EmployeeList', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.employeelist',
    requires: [
        'iMaxwell.store.Employees'
    ],
    itemId: 'employeeList',
    frame: true,
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
            header: 'Birth',
            dataIndex: 'BirthDate'
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
    initComponent: function() {

        var me = this;
        var store = Ext.create('iMaxwell.store.Employees');
        me.store = store;

        this.bbar = Ext.create('Ext.toolbar.Paging', {
            store: store,
            displayInfo: true,
            displayMsg: 'Employees {0} - {1} of {2}',
            emptyMsg: 'No Employees'
        });

        me.callParent(arguments);

    }
});