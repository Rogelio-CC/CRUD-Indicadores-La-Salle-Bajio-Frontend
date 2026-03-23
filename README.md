# Sistema de Gestión de Indicadores Académicos

CRUD Indicadores La Salle Bajío – Frontend

Este proyecto implementa el **frontend del sistema de gestión de indicadores académicos**, desarrollado en **.NET con Razor Pages**. Proporciona una interfaz para interactuar con la API del sistema, permitiendo la gestión de entidades mediante formularios, tablas y visualización de información.

El frontend está estructurado mediante **Pages, Services y DTOs**, y se comunica con la API a través de peticiones HTTP. Está preparado para ejecución local, en contenedores Docker y despliegue automatizado mediante **GitHub Actions**.

# Características

### Interfaz de gestión

Permite la interacción con el sistema mediante:

* Formularios para creación y edición de entidades
* Tablas para visualización de registros
* Navegación entre módulos del sistema
* Selección de relaciones mediante combobox

### Consumo de API

* Integración mediante **Services (HttpClient)**
* Uso de **DTOs** para estructurar datos
* Manejo de operaciones CRUD desde la interfaz

### Visualización de datos

* Representación de información mediante componentes visuales
* Soporte para gráficas dinámicas de indicadores

### Arquitectura desacoplada

* Separación entre frontend y backend
* Comunicación vía HTTP/HTTPS

### Preparado para contenedores

* Aplicación dockerizable
* Compatible con despliegue en la nube

---

# Tecnologías utilizadas

* **.NET / Razor Pages**
* **C#**
* **HttpClient**
* **DTOs**
* **Docker**
* **GitHub Actions**

---

# Arquitectura del proyecto

```
Frontend/
├── Pages/
├── Services/
├── DTOs/
├── wwwroot/
├── Program.cs
├── appsettings.json
```

### Descripción

* **Pages/**: Vistas Razor y lógica de presentación
* **Services/**: Comunicación con la API
* **DTOs/**: Modelos de datos para requests/responses
* **wwwroot/**: Recursos estáticos (JS, CSS, gráficos)
* **Program.cs**: Configuración de la aplicación

---

# Prerrequisitos

* .NET SDK
* Docker Desktop
* API backend en ejecución

---

# Configuración y ejecución

## Configurar URL de la API

En `appsettings.json`:

```json
"ApiSettings": {
  "BaseUrl": "https://localhost:7295"
}
```

---

## Ejecutar la aplicación

```bash
dotnet run
```

---

# Variables de entorno

```
ApiSettings__BaseUrl=https://localhost:7295
ASPNETCORE_ENVIRONMENT=Development
```

---

# Ejecución con Docker

```bash
docker build -t kpi-frontend .
docker run -p 5001:80 kpi-frontend
```

---

# Consumo de la API

El frontend realiza peticiones HTTP a la API mediante Services:

Flujo:

```
Pages (UI)
   ↓
Services (HttpClient)
   ↓
API
```

### Operaciones principales

* Obtener datos → GET
* Crear registros → POST
* Actualizar → PUT
* Eliminar → DELETE

Las relaciones entre entidades se gestionan mediante selección en la interfaz, evitando interacción directa con identificadores.

---

# CI/CD con GitHub Actions

El proyecto permite automatizar despliegue mediante:

1. Push al repositorio
2. Build del proyecto
3. Construcción de imagen Docker
4. Publicación en registry
5. Despliegue en entorno destino

---

# Notas

* El frontend depende de la API para la lógica de negocio
* No maneja persistencia directa
* Diseñado para integrarse con backend .NET en arquitectura desacoplada
* Extensible para mejoras visuales, reportes y optimización de experiencia de usuario
