Ext.define('iMaxwell.controller.MainTab', {
    extend: 'Ext.app.Controller',
    requires: [
        'Ext.grid.Panel',
        'iMaxwell.view.grid.AbstractGrid'
    ],
    views: [
        'tab.MainTab'
    ],
    init: function () {
        
        this.control({
            'maintab': {
                render: this.onMainTabRendered,
                tabchange : this.onMainTabChanged
            }
        });
    },

    onMainTabRendered: function (panel, eOpts) {

        console.log('Tab Panel Rendered');

    },
    onMainTabChanged: function(panel, newTab, oldTab, eOpts) {

        panel.setActiveTab(newTab);

    }

});