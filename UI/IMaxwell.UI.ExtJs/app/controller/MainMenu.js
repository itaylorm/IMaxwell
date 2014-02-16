﻿Ext.define('iMaxwell.controller.MainMenu', {
    extend: 'Ext.app.Controller',
    views: [
        'menu.MainMenu'
    ],
    refs: [
        {
            ref: 'mainMenuView',
            selector: 'mainmenu'
        }
    ],
    init: function () {
        var me = this;
        
        me.control({
            'mainmenu': {
                render: me.onMainMenuRendered
            }
        });
        
        
    },

    onMainMenuRendered: function (panel, eOpts) {
        console.log('Menu Panel Rendered');
        
    }
});