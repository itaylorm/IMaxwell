Ext.define('iMaxwell.view.ContactList', {
    extend: 'Ext.grid.Panel',
    alias: 'widget.contactList',
    requires: [
        'iMaxwell.store.Contacts'
    ],
    frame: true,
    columns: [
        {
            header: 'ID',
            dataIndex: 'ContactId'
        },
        {
            header: 'First',
            dataIndex: 'FirstName'
        },
        {
            header: 'Middle',
            dataIndex: 'MiddleName'
        },
        {
            header: 'Last',
            dataIndex: 'LastName'
        }
    ],
    initComponent: function () {

        debugger;
        
        var me = this;
        var store = Ext.create('iMaxwell.store.Contacts');
        me.store = store;
        store.load();

        this.bbar = Ext.create('Ext.toolbar.Paging', {
            store: store,
            displayInfo: true,
            displayMsg: 'Contacts {0} - {1} of {2}',
            emptyMsg: 'No Contacts'
        });

        me.callParent(arguments);

    }
});