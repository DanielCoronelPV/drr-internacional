
window.initLeafletMap = () => {
    const map = L.map('map').setView([-26.4026199, -54.5881233], 15);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    L.marker([-26.4026199, -54.5881233]).addTo(map)
        .bindPopup('Nuestra Ubicación')
        .openPopup();
};
