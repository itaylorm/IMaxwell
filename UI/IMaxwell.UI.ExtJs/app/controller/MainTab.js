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

        var contacts = Ext.create('iMaxwell.view.tab.Contacts');
        panel.add(contacts);
        panel.setActiveTab(contacts);

        var employees = Ext.create('iMaxwell.view.tab.Employees');
        panel.add(employees);

    },
    onMainTabChanged: function(panel, newTab, oldTab, eOpts) {

        panel.setActiveTab(newTab);

    }

});