let marker = null
let map = null

//function Map(latitude, longitude, nameBranch, size) {
//    if (!typeof (nameBranch) === "string") {
//        nameBranch = ""
//    }
//    if (map === null) {
//        map = L.map('map').setView([parseFloat(latitude), parseFloat(longitude)], size)
//    } else {
//        // перемещение к следующей позиции
//        map.flyTo([parseFloat(latitude), parseFloat(longitude)], size)
//    }

//    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//        attribution:
//            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
//    }).addTo(map)

//    // удаление предыдущего маркера
//    if (marker) {
//        map.removeLayer(marker)
//    }
//    marker = new L.Marker([parseFloat(latitude), parseFloat(longitude)], size).addTo(map).bindPopup(nameBranch).openPopup()
//}

function StartMap(checkedGeoEventListVm) {
    let count = checkedGeoEventListVm.geoEvents.length //id.length

    map = L.map('map').setView([parseFloat(56.4977100), parseFloat(84.9743700)], 11)

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution:
            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map)

    var markers = new L.MarkerClusterGroup();
    var markersList = [];

    function populate() {
        for (var i = 0; i < count; i++) {
            var m = new L.Marker([parseFloat(checkedGeoEventListVm.geoEvents[i].latitude), parseFloat(checkedGeoEventListVm.geoEvents[i].longitude)])
                .bindPopup(checkedGeoEventListVm.geoEvents[i].title).on("click", onMapClick);
            markersList.push(m);
            markers.addLayer(m);
        }
        return false;
    }
    
    populate();
    map.addLayer(markers);
    function onMapClick(e) {
        var z;
        for (var i = 0; i <= count; i++) {
            if (e.latlng.lat == checkedGeoEventListVm.geoEvents[i].latitude & e.latlng.lng == checkedGeoEventListVm.geoEvents[i].longitude) {
                z = i;
            }
        }

        var url = $("#RedirectTo").val();
        location.href = url + "?nameid=" + id[z];
    }
}


//function RedirectMap(latitude, longitude, size) {
//    let DbForMap = document.getElementById('NameBranchForRedirectMap');
//    var nameBranch = DbForMap.className;
//    if (!typeof (nameBranch) === "string") {
//        nameBranch = ""
//    }
//    if (map === null) {
//        map = L.map('map').setView([parseFloat(latitude), parseFloat(longitude)], size)
//    } else {
//        // перемещение к следующей позиции
//        map.flyTo([parseFloat(latitude), parseFloat(longitude)], size)
//    }

//    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//        attribution:
//            '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
//    }).addTo(map)

//    // удаление предыдущего маркера
//    if (marker) {
//        map.removeLayer(marker)
//    }
//    marker = new L.Marker([parseFloat(latitude), parseFloat(longitude)], size).addTo(map).bindPopup(nameBranch).openPopup()
//}

