function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 54.44491204, lng: 18.55316081 },
        zoom: 15,
        panControl: false,
        disableDefaultUI: true,
        navigationControl: true,
        zoomControl: false,
        scaleControl: true
    });

    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(54.44491204, 18.55316081),
        map: map,
        animation: google.maps.Animation.DROP,
        title: "Pasta House",

    });

    marker.addListener('click', function () {
        win = window.open("https://www.google.com/maps/dir/?api=1&destination=54.44491204,18.55316081", '_blank');
        win.focus();
    });

    navigator.geolocation.getCurrentPosition(
        function (position) {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: position.coords.latitude, lng: position.coords.longitude },
                zoom: 10,
                panControl: false,
                disableDefaultUI: true,
                navigationControl: true,
                zoomControl: false,
                scaleControl: true
            });

            directionsDisplay = new google.maps.DirectionsRenderer();
            directionsDisplay.setMap(map);
            directionsDisplay.setPanel(document.getElementById('route'));
            var request = {
                origin: position.coords.latitude + ',' + position.coords.longitude,
                destination: 'Centrum dydaktyczno - konferencyjne Uniwersytetu Gdańskiego',
                travelMode: google.maps.DirectionsTravelMode.DRIVING
            };
            directionsService = new google.maps.DirectionsService();
            directionsService.route(request, function (result, status) {
                if (status === google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(result);
                }
            });
        },

        function (error) {
        },

        { enableHighAccuracy: true, timeout: 15000 }
    );
}

