Ext.define('iMaxwell.view.Header', {
    extend: 'Ext.toolbar.Toolbar',
    alias: 'widget.appheader',
    height: 30,
    ui: 'footer',
    style: 'border-bottom: 4px solid #4c72a4;',
    items: [
        {
            xtype: 'label',
            text: 'iMaxwell Corporation'
        }
    ]
});