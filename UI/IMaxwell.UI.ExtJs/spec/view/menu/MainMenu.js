describe('iMaxwell.view.menu.MainMenu', function () {

    describe('Instantiation', function () {

        it('Instantiates without issue', function () {

            var mainMenu = Ext.create('iMaxwell.view.menu.MainMenu');
            expect(mainMenu).toBeDefined();
            expect(mainMenu instanceof iMaxwell.view.menu.MainMenu).toBeTruthy();

        });

    });

});