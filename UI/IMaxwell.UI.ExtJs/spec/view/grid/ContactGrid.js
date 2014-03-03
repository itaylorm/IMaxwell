describe('iMaxwell.view.grid.ContactGrid', function () {

    describe('Instantiation', function () {

        it('Instantiates without issue', function () {

            var contactGrid = Ext.create('iMaxwell.view.grid.ContactGrid');
            expect(contactGrid).toBeDefined();
            expect(contactGrid instanceof iMaxwell.view.grid.ContactGrid).toBeTruthy();

        });

    });

});