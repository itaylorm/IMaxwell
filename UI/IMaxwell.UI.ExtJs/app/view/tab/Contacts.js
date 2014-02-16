Ext.define('iMaxwell.view.tab.Contacts', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.contacts',
    layout: 'fit',
    items: [
        {
            xtype: 'contactList'
        }
    ]
});