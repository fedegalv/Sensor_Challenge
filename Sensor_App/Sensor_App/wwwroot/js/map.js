var content = document.getElementById('popup-content');
var center = ol.proj.transform([100.26, 9.93], 'EPSG:4326', 'EPSG:3857'); //initial position of map
var view = new ol.View({
    center: center,
    zoom: 2
});

var OSMBaseLayer = new ol.layer.Tile({
    source: new ol.source.OSM()
});

straitSource = new ol.source.Vector({ wrapX: true });
var straitsLayer = new ol.layer.Vector({
    source: straitSource
});

map = new ol.Map({
    layers: [OSMBaseLayer, straitsLayer],
    target: 'map',
    view: view,
    controls: [new ol.control.FullScreen(), new ol.control.Zoom()]
});

// Popup showing the position the user clicked
var container = document.getElementById('popup');
var popup = new ol.Overlay({
    element: container,
    autoPan: true,
    autoPanAnimation: {
        duration: 250
    }
});
map.addOverlay(popup);

map.on('click', function (evt) {
    var feature = map.forEachFeatureAtPixel(evt.pixel, function (feat, layer) {
        return feat;
    }
    );

    if (feature && feature.get('type') == 'Point') {
        var coordinate = evt.coordinate;

        content.innerHTML = feature.get('desc');
        popup.setPosition(coordinate);
    }
    else {
        popup.setPosition(undefined);

    }
});

//GENERATE NUMERO RANDOM
const getRandomNumber = function (min, max) {
    return Math.random() * (max - min) + min;
}


var generateRandomPoints = function () {

    straitSource.clear();
  
    var coordenadas = [];
    for (var i = 0; i < 3; i++) {
        var obj = {
            "Lon": getRandomNumber(-180, 181),
            "Lat": getRandomNumber(-90, 91)
        };

        coordenadas.push(obj)
    }
    addPointGeom(coordenadas);
}


function addPointGeom(data) {

    data.forEach(function (item) {
        var longitude = item.Lon,
            latitude = item.Lat,
            iconFeature = new ol.Feature({
                geometry: new ol.geom.Point(ol.proj.transform([longitude, latitude], 'EPSG:4326',
                    'EPSG:3857')),
                type: 'Point',
                desc: '<pre> <b>Waypoint Details </b> ' + '<br>' + 'Latitude : ' + latitude + '<br>Longitude: ' + longitude + '</pre>'
            }),
            iconStyle = new ol.style.Style({
                image: new ol.style.Circle({
                    radius: 5,
                    stroke: new ol.style.Stroke({
                        color: 'blue'
                    }),
                    fill: new ol.style.Fill({
                        color: [57, 228, 193, 0.84]
                    }),
                })
            });

        iconFeature.setStyle(iconStyle);

        straitSource.addFeature(iconFeature);
    });
}