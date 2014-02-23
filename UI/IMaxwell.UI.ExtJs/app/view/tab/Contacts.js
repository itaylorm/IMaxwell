Ext.define('iMaxwell.view.tab.Contacts', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.contacts',
    layout: 'fit',
    title: 'Contacts',
    initComponent: function() {

        this.callParent(arguments);

        this.configureGrid();

    },
    configureGrid: function() {

        var store = Ext.create('iMaxwell.store.Contacts'),
            grid = Ext.create('Ext.grid.Panel', {
                itemId: 'contactList',
                columns: [
                    {
                        header: 'First Name',
                        dataIndex: 'FirstName'
                    },
                    {
                        header: 'Middle Name',
                        dataIndex: 'MiddleName'
                    },
                    {
                        header: 'Last Name',
                        dataIndex: 'LastName'
                    }
                ],
                store: store,
                dockedItems: [
                    {
                        xtype: 'pagingtoolbar',
                        store: store,
                        dock: 'bottom',
                        displayInfo: true,
                        displayMsg: 'Contacts {0} - {1} of {2}',
                        emptyMsg: 'No Contacts'
                    }
                ]
            });

        this.items.add(grid);

    }
});