describe('iMaxwell.view.grid.AbstractGrid', function () {

    describe('Instantiation', function () {

        it('Instantiates without an issue', function () {

            var abstractGrid = Ext.create('iMaxwell.view.grid.AbstractGrid');

            expect(abstractGrid).toBeDefined();
            expect(abstractGrid instanceof iMaxwell.view.grid.AbstractGrid).toBeTruthy();

        });

    });

});