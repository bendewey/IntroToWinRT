(function () {
    'use strict';

    var listRenderer;
    var headerRenderer;
    var itemRenderer;
    var pageLayout;

    // Custom event raised after the fragment is appended to the DOM.
    WinJS.Application.addEventListener('fragmentappended', function handler(e) {
        if (e.location === '/html/landingPage.html') { fragmentLoad(e.fragment, e.state); }
    });

    function updateForLayout(lv, layout) {
        pageLayout = layout;
        if (pageLayout === Windows.UI.ViewManagement.ApplicationLayoutState.snapped) {
            WinJS.UI.setOptions(lv, {
                dataSource: pageData.groups,
                itemRenderer: listRenderer,
                groupDataSource: null,
                groupRenderer: null,
                oniteminvoked: itemInvoked
            });

            lv.layout = new WinJS.UI.ListLayout();
        } else {
            var groupDataSource = new WinJS.UI.GroupDataSource(
                    new WinJS.UI.ListDataSource(pageData.groups), function (item) {
                        return {
                            key: item.data.group.key,
                            data: {
                                title: item.data.group.title,
                                click: function () {
                                    WinJS.Navigation.navigate('/html/collectionPage.html', { group: item.data.group });
                                }
                            }
                        };
                    });

            WinJS.UI.setOptions(lv, {
                dataSource: pageData.items,
                itemRenderer: itemRenderer,
                groupDataSource: groupDataSource,
                groupRenderer: headerRenderer,
                oniteminvoked: itemInvoked
            });
            lv.layout = new WinJS.UI.GridLayout({ groupHeaderPosition: 'top' });
        }
        lv.refresh();
    }

    function layoutChanged(e) {
        var list = document.querySelector('.landingList');
        if (list) {
            var lv = WinJS.UI.getControl(list);
            updateForLayout(lv, e.layout);
        }
    }

    function fragmentLoad(elements, options) {
        try {
            var appLayout = Windows.UI.ViewManagement.ApplicationLayout.getForCurrentView();
            if (appLayout) {
                appLayout.addEventListener('layoutchanged', layoutChanged);
            }
        } catch (e) { }

        WinJS.UI.processAll(elements)
            .then(function () {
                itemRenderer = elements.querySelector('.itemTemplate');
                headerRenderer = elements.querySelector('.headerTemplate');
                listRenderer = elements.querySelector('.listTemplate');
                var lv = WinJS.UI.getControl(elements.querySelector('.landingList'));
                updateForLayout(lv, Windows.UI.ViewManagement.ApplicationLayout.value);
            });
    }

    function itemInvoked(e) {
        if (pageLayout === Windows.UI.ViewManagement.ApplicationLayoutState.snapped) {
            var group = pageData.groups[e.detail.itemIndex];
            WinJS.Navigation.navigate('/html/collectionPage.html', { group: group });
        } else {
            var item = pageData.items[e.detail.itemIndex];
            WinJS.Navigation.navigate('/html/detailPage.html', { item: item });
        }
    }

    // The getGroups() and getItems() functions contain sample data.
    // TODO: Replace with custom data.
    function getGroups() {
        var groups = [];

        groups.push({
            key: "InProgress",
            title: 'In Progress Orders',
            backgroundColor: 'rgba(209, 211, 212, 1)',
            label: 'In Progress Orders'
        });

        groups.push({
            key: "PreviousOrders",
            title: 'Previous Orders',
            backgroundColor: 'rgba(147, 149, 152, 1)',
            label: 'Previous Orders'
        });

        return groups;
    }

    function getItems() {
        var items = [];

        var vm = new PizzaHouse.ViewModels.OrdersViewModel();
        var g = 0;
        for (var i=0; i < vm.inProgressOrders.length; i++) {
            var item = vm.inProgressOrders[i];
            
            items.push({
                group: pageData.groups[g],
                key: item.id,
                status: item.status,
                date: item.dateText,
                customerName: item.customerName,
                customerAddress: item.customerAddress,
                customerPhone: item.customerPhone,
                orderItems: item.orderItems
            });
        }

        g = 1;
        for (var i = 0; i < vm.previousOrders.length; i++) {
            var item = vm.previousOrders[i];

            items.push({
                group: pageData.groups[g],
                key: item.id,
                status: item.status,
                date: item.dateText,
                customerName: item.customerName,
                customerAddress: item.customerAddress,
                customerPhone: item.customerPhone,
                orderItems: item.orderItems
            });
        }

        return items;
    }

    var pageData = {};
    pageData.groups = getGroups();
    pageData.items = getItems();

    WinJS.Namespace.define('landingPage', {
        fragmentLoad: fragmentLoad,
        itemInvoked: itemInvoked
    });
})();
