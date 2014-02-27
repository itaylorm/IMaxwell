Ext.define('iMaxwell.store.ContactDetail', {
    extend: 'Ext.data.Store',
    model: 'iMaxwell.model.Contact',
    requires: [
        'iMaxwell.model.Contact'
    ],
    proxy: {
        type: 'ajax',
        url: '/Person/Api/Contact',
        limitParam: undefined,
        pageParam: undefined,
        startParam: undefined,
        reader: {
            type: 'json',
            root: ''
        }
    }
});