Ext.define('iMaxwell.view.Viewport', {
    extend: 'Ext.container.Viewport',
    alias: 'widget.main',
    layout: {
        type: 'border'
    },
    items: [
        {
            xtype: 'appheader',
            region: 'north'
        },
        {
            xtype: 'mainmenu',
            collapsible:false,
            region: 'west'
        },
        {
            xtype: 'maintab',
            region: 'center'
        }
    ]
});