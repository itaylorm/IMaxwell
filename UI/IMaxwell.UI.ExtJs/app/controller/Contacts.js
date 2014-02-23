Ext.define('iMaxwell.controller.Contacts', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.Contacts',
        'ContactList'
    ],
    models: [
        'Contact'
    ],
    stores: [
        'Contacts'
    ],
    
    init: function() {

        this.control({
            'grid#contactList': {
                render: this.onGridRender
            }
        });
    },
    
    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Contact Grid rendered');

    }
    
});