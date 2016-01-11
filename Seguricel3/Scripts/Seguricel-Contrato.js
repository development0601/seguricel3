var gmarkers = [];
var icons = {
    seguricel: {
        icon: '../../Imagenes/Seguricel_googleMark.png',
        scaledSize: new google.maps.Size(100, 100), // scaled size
        origin: new google.maps.Point(0, 0), // origin
        anchor: new google.maps.Point(0, 0) // anchor
    }
}

function drawPoints(nearData) {
    for (i = 0; i < gmarkers.length; i++) {
        gmarkers[i].setmMap(null);
    }
    var latlng = new google.maps.LatLng($("#Latitud").val(), $("#Longitud").val());
    var mapOptions = {
        zoom: 14,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    var marker = new google.maps.Marker({
        position: latlng,
        map: map
    });
    gmarkers.push(marker);

    setAdyacentPoints(nearData);
    setMapListener();
}

function setMapListener() {
    google.maps.event.addListener(map, 'click', function (e) {
        $("#Longitud").val(e.latLng.lng());
        $("#Latitud").val(e.latLng.lat());
        var marker = new google.maps.Marker({
            position: e.latLng,
            map: map
        });
        for (var i = 0; i < gmarkers.length; i++) {
            gmarkers[i].setMap(null);
        }
        gmarkers = [];

        gmarkers.push(marker);
        setAdyacentPoints(nearData);
    });
}

function setAdyacentPoints(nearData) {
    for (i = 0; i < nearData.length; i++) {
        if (nearData[i].length > 0) {
            resData = nearData[i].split(";");
            var Nombre = resData[0];
            var Distancia = resData[3];

            var latlng = new google.maps.LatLng(resData[1], resData[2]);

            var marker = new google.maps.Marker({
                position: latlng,
                icon: icons["seguricel"].icon,
                title: Nombre,
                map: map
            });
            gmarkers.push(marker);
        }
    }
}

function GetCoordenadas() {
    var gmarkers = [];

    $.ajax({
        type: 'POST',
        url: '@Url.Action("GetCoordenadas", "GoogleMap")',
        dataType: 'json',
        data: {
            name: $("#Nombre").val()
        },
        success: function (data) {
            if (data.length > 0) {
                var result = data.split(" ");
                $("#Latitud").val(result[0]);
                $("#Longitud").val(result[1]);
                var latlng = new google.maps.LatLng(result[0], result[1]);

                var mapOptions = {
                    zoom: 12,
                    center: latlng,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

                var marker = new google.maps.Marker({
                    position: latlng,
                    map: map
                });

                for (i = 0; i < gmarkers.length; i++) {
                    gmarkers[i].setmMap(null);
                }

                gmarkers.push(marker);
            }
            else {
                for (i = 0; i < gmarkers.length; i++) {
                    gmarkers[i].setmMap(null);
                }

            }

            return false;
        },
        error: function (ex) {
            alert('Falló la extracción geográfica. ' + ex.status + ' ' + ex.statusText);
        }
    });
    return false;
}

function clearMarkers() {
    for (i = 0; i < gmarkers.length; i++) {
        gmarkers[i].setmMap(null);
    }
}