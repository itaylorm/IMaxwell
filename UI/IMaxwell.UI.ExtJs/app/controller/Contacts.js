Ext.define('iMaxwell.controller.Contacts', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.Contacts',
        'iMaxwell.view.tab.ContactDetail'
    ],
    refs: [
        {
            ref: 'MainTab',
            selector: 'maintab'
        }
    ],
    init: function() {

        this.control({
            'abstractgrid#contactGrid': {
                render: this.onGridRender,
                cellclick: this.onCellClick
            },
            'abstractgrid#contactGrid #clearFilter': {
                click: this.onButtonClickClearFilter
            }
        });
    },
    
    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Contact Grid rendered');

    },
    onButtonClickClearFilter: function (button, e, options) {

        button.up('abstractgrid#contactGrid').filters.clearFilters();

    },
    onCellClick: function (cell, td, cellIndex, record, tr, rowIndex, e, eOpts) {

        console.log('Cell Clicked');
        
        var me = this,
            mainTab = me.getMainTab();

        var id = record.data.Id;

        var contactDetail = Ext.create('iMaxwell.view.tab.ContactDetail', {contactId: id});

        mainTab.add(contactDetail);
        mainTab.setActiveTab(contactDetail);

    }
    
});