

var map = L.map('map').setView([19.047123, -70.600644], 8);
let mapLink =
    '<a href="http://openstreetmap.org">OpenStreetMap</a>';
L.tileLayer(
    'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; ' + mapLink + ' Contributors',
    maxZoom: 18,
}).addTo(map);

export function MostrarMapa(infoVehiculoMapJson) {
    let arrayVehiculos = JSON.parse(infoVehiculoMapJson);
    let markers = [];
    arrayVehiculos.forEach(element => {
        markers.push([element.Latitud, element.Longitud,
            `
            <div class="text-center">
              <img src="${element.Foto}" width="170px" height="100"/>
            </div>
            <br/>Marca: ${element.Marca}
            <br/>Modelo: ${element.Modelo}
            <br/>Color: ${element.Color}
            <br/>Año: ${element.Anio}
            <br/>Latitud: ${element.Latitud}
            <br/>Longitud: ${element.Longitud}
            <br/>3 proximas citas: <br/> ${element.Citas}
            `,
        ]);
    });

    for (let i = 0; i < markers.length; i++) {
        let marker = new L.marker([markers[i][0], markers[i][1]])
            .bindPopup(markers[i][2])
            .addTo(map);
    }

}


