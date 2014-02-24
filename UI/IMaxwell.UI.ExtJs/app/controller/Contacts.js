Ext.define('iMaxwell.controller.Contacts', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.Contacts'
    ],
    
    init: function() {

        this.control({
            'abstractgrid#contactGrid': {
                render: this.onGridRender
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

    }
    
});