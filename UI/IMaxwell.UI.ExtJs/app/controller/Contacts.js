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
            'grid': {
                render: this.onGridRender,
                init: this.onGridInit
            }
        });
    },
    
    onGridInit: function(grid) {
        console.log('Grid initialized');
    },
    
    onGridRender: function(grid, eOpts) {
        console.log('Grid rendered');
        //grid.store = this.getContacts();
        //grid.store = this.getStore();
        debugger;
    }
    
});