Ext.define('iMaxwell.view.tab.ContactDetail', {
    extend: 'Ext.form.Panel',
    alias: 'widget.contactdetail',
    closable: true,
    requires: [
        'Ext.form.field.Text'
    ],
    config: {
        contactId: null
    },
    constructor: function (config) {

        var me = this;

        config = config || {};

        me.initConfig(config);

        me.callParent([config]);

    },
    initComponent: function () {

        var me = this;

        me.items = [
            {
                name: 'FirstName',
                xtype: 'textfield',
                fieldLabel: 'First Name'
            },
            {
                name: 'MiddleName',
                xtype: 'textfield',
                fieldLabel: 'Middle Name'
            },
            {
                name: 'LastName',
                xtype: 'textfield',
                fieldLabel: 'Last Name'
            }
        ];

        me.callParent(arguments);

    }
});