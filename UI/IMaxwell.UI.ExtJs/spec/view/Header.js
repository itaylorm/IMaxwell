describe('iMaxwell.view.Header', function () {

    describe('Instantiation', function () {

        it('Instantiates without an issue', function () {

            var headerView = Ext.create('iMaxwell.view.Header');
            expect(headerView).toBeDefined();
            expect(headerView instanceof iMaxwell.view.Header).toBeTruthy();
        });

    });
});