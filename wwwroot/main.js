const productStore = DevExpress.data.AspNet.createStore({
    key: 'id',
    loadUrl: '/home/data',
})

new DevExpress.ui.dxDataGrid(document.getElementById('grid'), {
    dataSource: [],
    editing: {
        mode: 'row',
        allowAdding: true,
    },
    columns: [{
        dataField: 'ProductId',
        caption: 'Product',
        dataType: 'string',
        editCellTemplate: (_, info) => {
            const el = document.createElement('div');
            new DevExpress.ui.dxDropDownBox(el, {
                dataSource: productStore,
                value: info.value,
                valueExpr: 'id',
                contentTemplate: (e) => {
                    const grid = document.createElement('div');
                    new DevExpress.ui.dxDataGrid(grid, {
                        dataSource: productStore,
                        remoteOperations: true,
                        columns: ['name'],
                        selection: {mode: 'single'},
                        selectedRowKeys: [info.value],
                        focusedRowEnabled: true,
                        focusedRowKey: info.value,
                        height: '100%',
                        scrolling: {mode: 'infinite'},
                        onSelectionChanged: (args) => {
                            e.component.option('value', args.selectedRowKeys[0]);
                            info.setValue(args.selectedRowKeys[0]);
                            if (args.selectedRowKeys.length > 0) {
                                e.component.close();
                            }
                        }
                    });

                    return grid;
                }
            });

            return el;
        },
    }]
})