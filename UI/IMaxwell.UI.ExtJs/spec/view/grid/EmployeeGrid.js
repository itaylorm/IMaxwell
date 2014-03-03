describe('iMaxwell.view.grid.EmployeeGrid', function () {

    describe('Instantiation', function () {

        it('Instantiates without issue', function () {

            var employeeGrid = Ext.create('iMaxwell.view.grid.EmployeeGrid');
            expect(employeeGrid).toBeDefined();
            expect(employeeGrid instanceof iMaxwell.view.grid.EmployeeGrid).toBeTruthy();
        });

    });

});