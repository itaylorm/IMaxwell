Ext.Loader.setConfig({
    enabled: true,
    paths: {
        'Ext.ux': 'ux'
    }
});

Ext.define('iMaxwell.Application', {
    name: 'iMaxwell',
    extend: 'Ext.app.Application',

    views: [
        'Header',
        'tab.MainTab',
        'menu.MainMenu'
    ],
    
    controllers: [
        'Main',
        'MainMenu',
        'MainTab',
        'Contacts',
        'ContactDetail',
        'Employees'
    ],
    
    stores: [
    ]
    
});