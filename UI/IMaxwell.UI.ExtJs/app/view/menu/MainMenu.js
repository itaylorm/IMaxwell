Ext.define('iMaxwell.view.menu.MainMenu', {
    extend: 'Ext.panel.Panel',
    requires: [
        'Ext.layout.container.Accordion'
    ],
    alias: 'widget.mainmenu',
    width: 300,
    layout: {
        type: 'accordion'
    },
    collapsible: false,
    title: 'Main Menu'
})