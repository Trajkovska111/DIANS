function mappingUserLocation() {
    //variable that contains the map
    var map;
    map = L.map('map', {
        layers: MQ.mapLayer(),
        center: [41.9981, 21.4254],
        zoom: 13
    });

    //getting the user's location
    navigator.geolocation.getCurrentPosition(position => {
        const userLatitude = position.coords.latitude;
        const userLongitude = position.coords.longitude;
        //adding a marker on the user's location on the map
        L.marker([userLatitude, userLongitude]).addTo(map);
    });
}