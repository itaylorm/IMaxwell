Ext.define('iMaxwell.controller.Main', {
    extend: 'Ext.app.Controller',
    views: [
        'Viewport'
    ],
    
    init: function() {

        this.control({
            'viewport > panel': {
                render: this.onPanelRendered
            }
        });
    },
    
    onPanelRendered: function() {
        console.log('Panel Rendered');
    }
    
});