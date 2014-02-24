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
                render: this.onMainTabRendered
            }
        });
    },

    onMainTabRendered: function (panel, eOpts) {

        console.log('Tab Panel Rendered');

        var contacts = Ext.create('iMaxwell.view.tab.Contacts');
        panel.add(contacts);

        var employees = Ext.create('iMaxwell.view.tab.Employees');
        panel.add(employees);


    }
});