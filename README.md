# IRON_OCR
Repositorio que contiene la biblioteca de IRON OCR

-- Requerimientos
* Instalación de paquetes IRON OCR
Install-Package IronOcr
* Instalación de paquetes de lenguaje Español
Install-Package IronOcr.Languages.Spanish

-- Utilización
Se añade la dependencia que es el archivo IRON_OCR.dll al proyecto dónde se desee.

-- Comandos
OCR_IRON.IRON_OCR nuevo = new OCR_IRON.IRON_OCR();  // Creación de una nueva instancia de la librería
Console.WriteLine(nuevo.LeerImagen(nombre_imagen)); // nombre_imagen: representa la ruta exacta de la imagen que se desee escanear y esto devuelve los datos importantes del cheque.
