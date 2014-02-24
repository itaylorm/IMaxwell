Ext.define('iMaxwell.controller.Employees', {
    extend: 'Ext.app.Controller',
    requires: [
        'iMaxwell.store.Employees'
    ],
    views: [
        'tab.Employees'
    ],

    init: function () {

        this.control({
            'abstractgrid#employeeGrid': {
                render: this.onGridRender
            }
        });
    },

    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Employee Grid rendered');

    }

});