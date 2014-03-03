describe('iMaxwell.view.tab.ContactDetail', function () {

    describe('Instantiation', function () {

        it('Instantiated without issue', function () {

            var contactDetail = Ext.create('iMaxwell.view.tab.ContactDetail');
            expect(contactDetail).toBeDefined();
            expect(contactDetail instanceof iMaxwell.view.tab.ContactDetail).toBeTruthy();

        });

    });

});