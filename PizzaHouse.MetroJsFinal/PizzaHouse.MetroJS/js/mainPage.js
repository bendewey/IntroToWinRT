(function () {
    'use strict';

    
    // Custom event raised after the fragment is appended to the DOM.
    WinJS.Application.addEventListener('fragmentappended', function handler(e) {
        if (e.location === '/html/mainPage.html') { fragmentLoad(e.fragment, e.state); }
    });

    function fragmentLoad(elements, options) {
        try {
            var appLayout = Windows.UI.ViewManagement.ApplicationLayout.getForCurrentView();
            if (appLayout) {
                appLayout.addEventListener('layoutchanged', layoutChanged);
            }
        } catch (e) { }

        var notImplementedButtons = ["placeAnOrder","menus","locations"];
        for (var b in notImplementedButtons) {
            elements.querySelector("#" + notImplementedButtons[b]).onclick = function () {
                WinJS.Navigation.navigate('/html/notImplemented.html');
            }
        }

        var track = elements.querySelector("#trackOrder");
        track.onclick = function () {
            WinJS.Navigation.navigate('/html/landingPage.html');
        }
    }


    WinJS.Namespace.define('mainPage', {
        fragmentLoad: fragmentLoad
    });
})();
