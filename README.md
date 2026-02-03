# Vehicle Management System

A **full-stack vehicle management application** built with **.NET 8 Web API** and **Blazor WebAssembly** for managing vehicle inventory with CRUD (Create and Read only) operations and pagination.


---


## Technologies Used

### Backend
- .NET 8.0 Web API
- ASP.NET Core
- Swagger/OpenAPI for API documentation
- Minimal APIs architecture

### Frontend
- Blazor WebAssembly (standalone)
- Bootstrap 5
- C# for client-side logic

---

## Prerequisites

Before you begin, ensure you have the following installed:

- **Visual Studio 2022** (with ASP.NET and web development workload) or **VS Code**
- **.NET 8.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Git** - [Download here](https://git-scm.com/downloads)

Verify .NET installation:
```bash
dotnet --version
```

---

## Project Structure

```
VehicleApp/
├── VehicleAPI/              # Backend Web API project
│   ├── Controllers/         # API controllers
│   ├── Models/              # Data models
│   ├── Services/            # Business logic layer
│   ├── Repositories/        # Data access layer
│   ├── Program.cs           # API entry point
│   └── VehicleAPI.csproj
├── VehicleBlazor/           # Frontend Blazor WebAssembly project
│   ├── Pages/               # Blazor pages/components
│   ├── wwwroot/             # Static files
│   ├── Program.cs           # Blazor entry point
│   └── VehicleBlazor.csproj
├── VehicleManagement.sln    # Solution file
├── .gitignore
└── README.md
```

---

## Installation

### Clone the Repository

```bash
git clone https://github.com/ShahryarAlpha/VehicleApp.git
cd VehicleApp
```

### Visual Studio 2022

1. Open `VehicleManagement.sln` in Visual Studio 2022
2. Right-click on the solution → **Configure Startup Projects**
3. Select **Multiple startup projects**
4. Set both `VehicleAPI` and `VehicleBlazor` to **Start**
5. Ensure `VehicleAPI` is listed first (starts before Blazor)
6. Press `F5` or click **Start**

Two browser windows will open:
- **API Swagger**: https://localhost:7043/swagger
- **Blazor App**: https://localhost:7026

### Visual Studio Code

#### 1. Install Required Extensions

```bash
code --install-extension ms-dotnettools.csdevkit
code --install-extension ms-dotnettools.csharp
code --install-extension patcx.vscode-nuget-gallery
```

#### 2. Restore Dependencies

```bash
dotnet restore
```

#### 3. Run the Application

**Terminal 1 - Start API** (keep this running):
```bash
cd VehicleAPI
dotnet run
```

**Terminal 2 - Start Blazor App** (in a new terminal):
```bash
cd VehicleBlazor
dotnet run
```

#### 4. Access the Application

- **API Swagger**: https://localhost:7043/swagger
- **Blazor App**: https://localhost:7026

---

## API Documentation

### Base URL
```
https://localhost:7043/api
```

### Endpoints

#### Get Vehicles (Paginated)

```http
GET /api/vehicles?page=1&pageSize=10
```

**Query Parameters:**

| Parameter | Type | Required | Default | Description             |
|-----------|------|----------|---------|-------------------------|
| page      | int  | No       | 1       | Page number (min: 1)    |
| pageSize  | int  | No       | 10      | Items per page (max: 50)|

**Response:**
```json
{
  "items": [
    {
      "id": 1,
      "make": "Tesla",
      "model": "Model 3",
      "year": 2023
    }
  ],
  "totalCount": 100,
  "page": 1,
  "pageSize": 10
}
```

#### Add Vehicle

```http
POST /api/vehicles
Content-Type: application/json
```

**Request Body:**
```json
{
  "make": "Tesla",
  "model": "Model 3",
  "year": 2023
}
```

**Response:**
```json
{
  "id": 1,
  "make": "Tesla",
  "model": "Model 3",
  "year": 2023
}
```

---

## Usage

1. **Start the application** following the installation steps above
2. **Navigate** to the Blazor app at https://localhost:7026
3. **View vehicles** in the default table view
4. **Add new vehicles** using the form
5. **Navigate pages** using the pagination controls
6. **Explore API** at https://localhost:7043/swagger for testing endpoints

---

## Configuration

### Default Ports

| Project       | HTTPS Port | HTTP Port |
|---------------|------------|-----------|
| VehicleAPI    | 7043       | 5043      |
| VehicleBlazor | 7026       | 5026      |



### Key Assumptions

- **Storage**: In-memory storage using static list (data resets on restart)
- **No Persistence**: Suitable for development and testing only
- **CORS**: Configured to allow requests from Blazor app

---

## Troubleshooting


### Port Already in Use

If ports 7043 or 7026 are already in use:
1. Change ports in `launchSettings.json` files
2. Update CORS configuration in VehicleAPI
3. Update API base URL in VehicleBlazor

### API Not Accessible from Blazor

Ensure:
1. VehicleAPI is running before starting VehicleBlazor
2. CORS is properly configured in VehicleAPI
3. API base URL in Blazor matches the running API port

### Restore Failures

Try cleaning and restoring:
```bash
dotnet clean
dotnet restore
```

---
