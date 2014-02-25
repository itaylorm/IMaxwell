Ext.define('iMaxwell.view.grid.ContactGrid', {
    extend: 'iMaxwell.view.grid.AbstractGrid',
    alias: 'widget.contactgrid',
    itemId: 'contactGrid',
    requires: [
        'iMaxwell.store.Contacts'
    ],
    initComponent: function () {


        var me = this,
            store = Ext.create('iMaxwell.store.Contacts');

        me.store = store;

        me.columns = [
            {
                header: 'First Name',
                dataIndex: 'FirstName',
                filter: { type: 'string'}
            },
            {
                header: 'Middle Name',
                dataIndex: 'MiddleName',
                filter: { type: 'string'}
            },
            {
                header: 'Last Name',
                dataIndex: 'LastName',
                filter: { type: 'string'}
            }
        ];

        me.dockedItems = [
            {
                xtype: 'pagingtoolbar',
                store: store,
                dock: 'bottom',
                displayInfo: true,
                displayMsg: 'Contacts {0} - {1} of {2}',
                emptyMsg: 'No Contacts',
                features: [
                    {
                        ftype: 'filters',
                        encode: true,
                        local:false
                    }
                ]
            }
        ];

        me.callParent(arguments);

    }
})