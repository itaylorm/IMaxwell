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
        'Employees'
    ],
    
    stores: [
    ]
    
});