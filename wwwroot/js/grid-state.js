document.addEventListener("DOMContentLoaded", function () {
    const pageKey = "CityGrid";
    const gridDiv = document.querySelector("#gridContainer");
    gridDiv.style.height = "400px";
    gridDiv.style.width = "100%";

    const gridOptions = {
        columnDefs: [
            { field: "Name", headerName: "City", filter: true },
            { field: "State", filter: true },
            { field: "Country", filter: true },
            { field: "Population", filter: "agNumberColumnFilter" }
        ],
        rowData: [],
        defaultColDef: { sortable: true, resizable: true, filter: true },
        rowSelection: "multiple",
        onGridReady: params => {
            params.api.setServerSideDatasource({ getRows: loadData });
            loadState(params.api);
        },
        onFilterChanged: () => saveState(),
        onSortChanged: () => saveState(),
        onColumnMoved: () => saveState(),
        onColumnResized: () => saveState(),
        onColumnVisible: () => saveState()
    };

    let gridApi;
    agGrid.createGrid(gridDiv, gridOptions);
    gridApi = gridOptions.api;  // Set after creation

    async function loadData(params) {
        const res = await fetch("/api/cities");
        const data = await res.json();
        params.success({ rowData: data, rowCount: data.length });
    }

    async function loadState(api) {
        const res = await fetch(`/api/UserGridState/get?pageKey=${pageKey}`);
        const data = await res.json();
        if (data.stateJson) {
            const state = JSON.parse(data.stateJson);
            api.setFilterModel(state.filterModel || {});
            api.setSortModel(state.sortModel || []);
            // For columns, use api.setColumnDefs(state.columnDefs || gridOptions.columnDefs);
            if (state.columnDefs) api.setColumnDefs(state.columnDefs);
        }
    }

    async function saveState() {
        const api = gridOptions.api;
        const state = {
            filterModel: api.getFilterModel(),
            sortModel: api.getSortModel(),
            columnDefs: api.getColumnDefs()  // Get current column defs
        };
        await fetch(`/api/UserGridState/save`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ pageKey: pageKey, stateJson: JSON.stringify(state) })
        });
    }
});