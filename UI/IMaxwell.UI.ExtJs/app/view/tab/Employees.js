Ext.define('iMaxwell.view.tab.Employees', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.employees',
    layout: 'fit',
    iconCls: 'employees',
    title: 'Employees',
    closable: true,
    requires: [
        'iMaxwell.view.grid.EmployeeGrid'
    ],
    items: [
        {
            xtype: 'employeegrid'
        }
    ]
});