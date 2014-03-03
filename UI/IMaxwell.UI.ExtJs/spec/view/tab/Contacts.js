describe('iMaxwell.view.tab.Contacts', function () {

    describe('Instantiation', function () {

        it('Instantiates without issue', function () {

            var contacts = Ext.create('iMaxwell.view.tab.Contacts');
            expect(contacts).toBeDefined();
            expect(contacts instanceof iMaxwell.view.tab.Contacts).toBeTruthy();

        });
    });

});