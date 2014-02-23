Ext.define('iMaxwell.controller.Employees', {
    extend: 'Ext.app.Controller',
    views: [
        'tab.Employees',
        'EmployeeList'
    ],
    models: [
        'Employee'
    ],
    stores: [
        'Employees'
    ],

    init: function () {

        this.control({
            'grid#employeeList': {
                render: this.onGridRender
            }
        });
    },

    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Employee Grid rendered');

    }

});