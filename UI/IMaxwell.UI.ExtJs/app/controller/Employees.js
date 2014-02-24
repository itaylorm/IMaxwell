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
            },
            'abstractgrid#employeeGrid #clearFilter': {
                click: this.onButtonClickClearFilter
            }
        });
    },

    onGridRender: function (grid, eOpts) {

        grid.getStore().load();

        console.log('Employee Grid rendered');

    },
    onButtonClickClearFilter: function (button, e, options) {

        button.up('abstractgrid#employeeGrid').filters.clearFilters();

    }
});