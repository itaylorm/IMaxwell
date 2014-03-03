describe('iMaxwell.view.tab.MainTab', function () {

    describe('Instantiation', function () {

        it('Instantiated without issue', function () {

            var mainTab = Ext.create('iMaxwell.view.tab.MainTab');
            expect(mainTab).toBeDefined();
            expect(mainTab instanceof iMaxwell.view.tab.MainTab).toBeTruthy();
        });

    });
});