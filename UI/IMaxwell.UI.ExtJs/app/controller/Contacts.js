Ext.define('iMaxwell.controller.Contacts', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.Contacts'
    ],
    
    init: function() {

        this.control({
            'abstractgrid#contactGrid': {
                render: this.onGridRender
            }
        });
    },
    
    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Contact Grid rendered');

    }
    
});