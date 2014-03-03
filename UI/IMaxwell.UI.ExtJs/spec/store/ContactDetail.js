describe('iMaxwell.store.ContactDetail', function () {

    describe('Instantiation', function() {

        it('Instantiates without issue', function () {

            var contactDetail = Ext.create('iMaxwell.store.ContactDetail');
            expect(contactDetail).toBeDefined();
            expect(contactDetail).toBeTruthy();
        });

    });

});