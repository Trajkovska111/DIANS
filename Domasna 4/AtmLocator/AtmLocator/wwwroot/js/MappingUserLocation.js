function mappingUserLocation(latitude, longitude) {
    //variable that contains the map
    var map;
    map = L.map('map', {
        layers: MQ.mapLayer(),
        center: [41.9981, 21.4254],
        zoom: 13
    });

    //adding a marker on the user's location on the map
    L.marker([latitude, longitude]).addTo(map);

}