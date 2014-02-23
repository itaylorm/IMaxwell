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
            'grid': {
                render: this.onGridRender,
                init: this.onGridInit
            }
        });
    },

    onGridInit: function (grid) {
        console.log('Employee Grid initialized');
    },

    onGridRender: function (grid, eOpts) {
        console.log('Employee Grid rendered');
    }

});