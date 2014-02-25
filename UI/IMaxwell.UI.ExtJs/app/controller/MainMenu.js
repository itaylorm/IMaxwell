Ext.define('iMaxwell.controller.MainMenu', {
    extend: 'Ext.app.Controller',
    requires: [
        'Ext.layout.container.Accordion'
    ],
    refs: [
        {
            ref: 'mainTab',
            selector: 'maintab'
        }
    ],
    views: [
        'menu.MainMenu',
        'menu.Item'
    ],
    init: function () {
        var me = this;
        
        me.control({
            'mainmenu': {
                render: me.onMainMenuRendered
            },
            'mainmenuitem': {
                select: this.onTreeSelect,
                itemclick: this.onItemClick
            }
        });
        
        
    },

    onMainMenuRendered: function (panel, eOpts) {
        console.log('Menu Panel Rendered');
        
        var treePanel = Ext.create('iMaxwell.view.menu.Item');
        treePanel.title = "Data Choices";

        var employeeMenu = Ext.create('iMaxwell.view.menu.Item');
        employeeMenu.text = 'Employees',
        employeeMenu.leaf = true;
        employeeMenu.id = 'employeesMenu';

        treePanel.getRootNode().appendChild(employeeMenu);

        var employeeMenu = Ext.create('iMaxwell.view.menu.Item');
        employeeMenu.text = 'Contacts',
        employeeMenu.leaf = true;
        employeeMenu.id = 'contactsMenu';

        treePanel.getRootNode().appendChild(employeeMenu);

        panel.add(treePanel);

    },

    onTreeSelect: function (rowModel, record, index, eOpts) {
        console.log('Menu Selected');

        var mainTab = this.getMainTab();

        var newTab = mainTab.items.findBy(
            function (tab) {
                return tab.title == record.get('text');
            });

        var id = record.get('id');

        if (!newTab && id == 'employeesMenu') {

            newTab = Ext.create('iMaxwell.view.tab.Employees');
            mainTab.add(newTab);
        }
        else if (!newTab && id == 'contactsMenu') {
            newTab = Ext.create('iMaxwell.view.tab.Contacts');
            mainTab.add(newTab);
        }

        mainTab.setActiveTab(newTab);

    },

    onItemClick: function (view, record, item, index, event, eOpts) {
    
        this.onTreeSelect(view, record, index, eOpts);
    }

});