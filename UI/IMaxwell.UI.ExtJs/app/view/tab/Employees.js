Ext.define('iMaxwell.view.tab.Employees', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.employees',
    layout: 'fit',
    items: [
        {
            xtype: 'employeelist'
        }
    ]
});