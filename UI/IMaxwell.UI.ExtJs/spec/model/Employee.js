describe('iMaxwell.model.Employee', function () {

    describe('Instantiation', function () {

        it('Instantiates without an issue', function () {

            var employeeModel = Ext.create('iMaxwell.model.Employee');
            expect(employeeModel).toBeDefined();
            expect(employeeModel instanceof iMaxwell.model.Employee).toBeTruthy();

        });

    });
});