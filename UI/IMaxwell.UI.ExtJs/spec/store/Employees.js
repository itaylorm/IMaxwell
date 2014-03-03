describe('iMaxwell.store.Employees', function () {

    describe('Instantiation', function () {

        it('Instantiates without issue', function () {

            var employees = Ext.create('iMaxwell.store.Employees');
            expect(employees).toBeDefined();
            expect(employees).toBeTruthy();

        });

    });

});