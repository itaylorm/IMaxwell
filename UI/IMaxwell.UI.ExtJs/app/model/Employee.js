Ext.define('iMaxwell.model.Employee', {
    extend: 'iMaxwell.model.Contact',
    fields: [
        'EmployeeId',
        'Gender',
        'MaritalStatus',
        'SalariedFlag',
        'SickLeaveHours',
        'VacationHours',
        'Title',
        'BirthDate',
        'ModifiedDate',
        'City',
        'PostalCode',
        'Rate'
    ]
});