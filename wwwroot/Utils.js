export function mensajeError(text) {
    Swal.fire({
        icon: 'error',
        title: text,
        confirmButtonText: "Aceptar"
    })
}

export function addValidation(stylo, nameClass, typeValidation) {
    let tiposVehiculosNombre = document.getElementById(nameClass);
    tiposVehiculosNombre.classList.remove(typeValidation == "valid" ? "invalid" : "valid");
    tiposVehiculosNombre.classList.add("modified")
    tiposVehiculosNombre.classList.add(typeValidation)
    tiposVehiculosNombre.style.outline = "none";
    tiposVehiculosNombre.style.borderRadius = "5px !important";
    tiposVehiculosNombre.style.border = stylo;
}


export function LoandingButton(isLoanding, idbutton, textButtton) {
    const boton = document.getElementById(idbutton);
    if (isLoanding) {
        boton.disabled = true;
        boton.innerHTML = `
    <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
    Cargando...
    `
    } else {
        boton.disabled = false;
        boton.innerHTML = textButtton;
    }
}

export async function ClearInput() {
    let listClass = document.querySelectorAll(".modified.valid");
    listClass.forEach(clas => {
        clas.classList.remove("modified");
        clas.classList.remove("valid");
    })
}



function Mostrar() {
    Swal.fire({
        showConfirmButton: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        width: 900,
        html:
            `<div id="map" class="map map-home" style="margin:12px 0 12px 0; width: 800px; height:400px;"></div>
            <span>Latitud: </span><span id="lat-model"></span>
            <span>Longitud: </span><span id="lot-model"></span></br>
            <button class="btn btn-primary mt-2" id="Guardar-coordenadas" disabled  onclick="Swal.close()">Guardar</button>`,
        focusConfirm: false,
    })
}

export function ShowMap() {
    Mostrar();
    let latitud = document.getElementById("Latitud");
    let longitud = document.getElementById("Longitud");
    let latmodel = document.getElementById("lat-model");
    let lotmodel = document.getElementById("lot-model");
    let btnGuardarcoordenadas = document.getElementById("Guardar-coordenadas");

    let map = L.map('map').setView([19.047123, -70.600644], 8);
    let mapLink =
        '<a href="http://openstreetmap.org">OpenStreetMap</a>';
    L.tileLayer(
        'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; ' + mapLink + ' Contributors',
        maxZoom: 18,
    }).addTo(map);

    map.on('click', function (ev) {
        var latlng = map.mouseEventToLatLng(ev.originalEvent);
        var event = new Event('change');
        latitud.value = latlng.lat;
        longitud.value = latlng.lng
        latmodel.innerText = latlng.lat;
        lotmodel.innerText = latlng.lng;
        btnGuardarcoordenadas.disabled = false;
        latitud.dispatchEvent(event);
        longitud.dispatchEvent(event);
    });
}

export function CambiarTitulo(title) {
    document.title = title;
}

function print() {

}

export function CambiarPageHeading(value) {
    document.querySelector(".heading").innerText = value;
}

export function SuccessMessage(message) {
    Swal.fire({
        icon: 'success',
        title: message,
        confirmButtonText: "Aceptar"
    })
}