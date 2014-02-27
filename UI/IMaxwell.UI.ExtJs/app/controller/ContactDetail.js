Ext.define('iMaxwell.controller.ContactDetail', {
    extend: 'Ext.app.Controller',
    requires: [
        'iMaxwell.store.ContactDetail',
        'iMaxwell.model.Contact'
    ],
    views: [
        'tab.ContactDetail'
    ],
    init: function () {

        this.control({
            'contactdetail': {
                render: this.onRenderData
            }
        })

    },
    onRenderData: function(view, eOpts) {

        console.log('Contact rendered');

        this.refreshData(view);

    },
    refreshData: function (view) {

        var contactId = view.getContactId();

        var form = view.getForm();

        var store = Ext.create('iMaxwell.store.ContactDetail');

        store.load({
            params: {
                id: contactId
            },
            callback: function (records, operation, success) {

                if (success)
                {
                    view.setTitle("Contact " + contactId);
                    form.loadRecord(records[0]);
                }

                else
                    view.setTitle("Contact " + contactId + " (Unavailable)");
            }
        });

    }
})