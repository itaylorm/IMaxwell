Ext.define('iMaxwell.store.Employees', {
    extend: 'Ext.data.Store',
    requires: [
        'iMaxwell.model.Employee'
    ],
    model: 'iMaxwell.model.Employee',
    pageSize: 25,
    proxy: {
        type: 'ajax',
        url: '/humanresources/api/employee',
        reader: {
            type: 'json',
            root: 'Employees',
            TotalProperty: 'Total' 
        }
    }
});