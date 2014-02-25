Ext.define('iMaxwell.view.tab.Contacts', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.contacts',
    layout: 'fit',
    iconCls: 'contacts',
    title: 'Contacts',
    closable: true,
    requires: [
        'iMaxwell.view.grid.ContactGrid'
    ],
    items: [
        {
            xtype:'contactgrid'
        }
    ]
});