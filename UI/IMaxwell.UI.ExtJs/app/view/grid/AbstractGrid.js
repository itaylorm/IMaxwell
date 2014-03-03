Ext.define('iMaxwell.view.grid.AbstractGrid', {
    extend: 'Ext.ux.LiveSearchGridPanel',
    alias: 'widget.abstractgrid',
    requires: [
        'Ext.grid.plugin.CellEditing',
        'Ext.ux.grid.FiltersFeature',
        'Ext.grid.column.Action',
        'Ext.grid.column.Date'
    ],
    columnLines: true,
    viewConfig: {
        stripeRows: true
    },

    initComponent: function () {
        var me = this;

        me.selModel = {
            selType: 'cellmodel'
        };

        me.plugins = [
            Ext.create('Ext.grid.plugin.CellEditing', {
                clicksToEdit: 1,
                pluginId: 'cellplugin'
            })
        ];

        me.features = [
            Ext.create('Ext.ux.grid.FiltersFeature', {
                local: true
            })
        ];
        
        me.dockedItems = Ext.Array.merge(me.dockedItems,
            [{
                xtype: 'toolbar',
                dock: 'top',
                itemId: 'topToolbar',
                items: [
                     {
                         xtype: 'button',
                         itemId: 'add',
                         text: 'Add',
                         iconCls: 'add'
                     },
                     {
                         xtype: 'tbseparator'
                     },
                     {
                         xtype: 'button',
                         itemId: 'save',
                         text: 'Save Changes',
                         iconCls: 'save_all'
                     },
                     {
                         xtype: 'button',
                         itemId: 'cancel',
                         text: 'Cancel Changes',
                         iconCls: 'cancel'
                     },
                     {
                         xtype: 'tbseparator'
                     },
                     {
                         xtype: 'button',
                         itemId: 'clearFilter',
                         text: 'Clear Filters',
                         iconCls: 'clear_filter'
                     }
                ]
            }]
        );

        if (me.columns == undefined)
        {
            me.columns = [
                {
                    text:'test'
                }
            ];
        }

        me.columns = Ext.Array.merge(me.columns,
            [{
                xtype: 'datecolumn',
                text: 'Modified',
                width: 120,
                dataIndex: 'ModifiedDate',
                filter: {type: 'date'}
            },
            {
                xtype: 'actioncolumn',
                width: 30,
                sortable: false,
                menuDisabled: true,
                items: [
                    {
                        handler: function (view, rowIndex, colIndex, item, e) {
                            this.fireEvent('itemclick', this, 'delete', view, rowIndex, colIndex, item, e);
                        },
                        iconCls: 'delete',
                        tooltip: 'Delete'
                    }
                ]
            }]
        );

        me.callParent(arguments);
    }
});