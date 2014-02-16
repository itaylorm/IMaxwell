Ext.define('iMaxwell.store.Contacts', {
    extend: 'Ext.data.Store',
    requires: [
        'iMaxwell.model.Contact'
    ],
    model: 'iMaxwell.model.Contact',
    pageSize: 25,
    proxy: {
        type: 'ajax',
        url: '/Person/api/Contact',
        reader: {
            type: 'json',
            root: 'Contacts',
            totalProperty: 'Total'
        },
    }
});