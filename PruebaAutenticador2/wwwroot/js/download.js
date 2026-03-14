// Función para descargar un archivo desde el navegador
window.downloadFile = (fileName, contentType, bytes) => {
    const blob = new Blob([new Uint8Array(bytes)], { type: contentType });
    const url = URL.createObjectURL(blob);

    // Crear un enlace temporal para iniciar la descarga
    const a = document.createElement("a");
    a.href = url;
    a.download = fileName;
    a.click();

    URL.revokeObjectURL(url);
};
