Ext.define('iMaxwell.controller.MainTab', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.MainTab'
    ],
    init: function () {
        
        this.control({
            'maintab': {
                render: this.onMainTabRendered
            }
        });
    },

    onMainTabRendered: function (panel, eOpts) {
        console.log('Tab Panel Rendered');

        var contacts = Ext.create('iMaxwell.view.tab.Contacts');

        panel.items.add(contacts);

    }
});