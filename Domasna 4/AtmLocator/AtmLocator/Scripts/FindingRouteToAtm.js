function findingRouteToAtm( destinationLatitude, destinationLongitude) {
    var map, direction;
    //variable that contains the map
    map = L.map('map', {
        layers: MQ.mapLayer(),
        center: [41.9981, 21.4254],
        zoom: 15
    });
    //object from mapquest, that will be used for finding the route from the user location to the selected atm
    direction = MQ.routing.directions();
    //layer that draws the route on the map
    map.addLayer(MQ.routing.routeLayer({
        directions: direction,
        fitBounds: true
    }));
    //getting the user's location
    navigator.geolocation.getCurrentPosition(position => {
        direction.route({
            locations: [
                //position.coords.latitude = user's latitude; position.coords.longitude = user's longitude
                { latLng: { lat: position.coords.latitude, lng: position.coords.longitude } },
                {
                    latLng: { lat: destinationLatitude, lng: destinationLongitude } }
                    ],
                });       
            });
}