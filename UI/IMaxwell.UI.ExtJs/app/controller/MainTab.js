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

        //panel.suspendLayouts();

        var contacts = Ext.create('iMaxwell.view.tab.Contacts');
        panel.items.add(contacts);

        //console.log(panel.items.length);

        //var test = Ext.create('Ext.panel.Panel');
        //panel.items.add(test);

        //var employees = Ext.create('iMaxwell.view.tab.Employees');
        //panel.items.add(employees);

        //panel.resumeLayouts();

    }
});