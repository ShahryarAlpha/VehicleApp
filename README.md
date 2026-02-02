# Vehicle Management

A **full-stack vehicle management application** built with **.NET 8 Web API** and **Blazor WebAssembly**.  

---

## Prerequisites

- **Visual Studio 2022** (with ASP.NET workload) or **VS Code**  
- **.NET 8.0 SDK** (required for building and running the project)  
- **Git** (for cloning the repository)  

---


## API Endpoints

- Base URL: 
```bash
https://localhost:7043/api
````
- Get Vehicles (Paginated)

```bash
GET /api/vehicles?page=1&pageSize=10
````


Query Parameters:

| Parameter | Required | Default | Description             |
| --------- | -------- | ------- | ----------------------- |
| page      | No       | 1       | Page number             |
| pageSize  | No       | 10      | Items per page (max 50) |



- Add Vehicle

```bash
POST /api/vehicles
Content-Type: application/json
{
  "make": "Tesla",
  "model": "Model 3",
  "year": 2023
}
````
---
## Key Assumptions

#### Storage

- In-Memory Storage - Data stored in server storage using static list
- No Persistence - Data resets when API restarts

#### Technology

- Framework: .NET 8.0
- UI Framework: Bootstrap 5
- Blazor Mode: WebAssembly (standalone)

#### Default Ports

| Project       | HTTPS Port |
| ------------- | ---------- |
| VehicleApi    | 7043       |
| VehicleBlazor | 7026       |


---

## Project Setup


### 1. **Install .NET 8.0 SDK**

#### Windows

- Download the sdk from:  
[https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- Run the installer
- Follow the installation wizard

#### macOS
```bash
brew install --cask dotnet-sdk
```

Verify the installation:
```bash
dotnet --version
```
### 2. Setup on Visual Studio 2022
- Open VehicleManagement.sln in Visual Studio 2022
- Right-click Solution → Configure Startup Projects
- Select Multiple startup projects
- Set both VehicleApi and VehicleBlazor to Start
- Ensure VehicleApi is listed first
- Two browser windows will open:
-	  API: https://localhost:7043/swagger
	  Blazor: https://localhost:7026

### 3. Setup on Visual Studio Code

#### **3.1 Install VS Code Extensions (Required)**

**Option 1: Install via VS Code UI**

	Open VS Code → Extensions and install the following:

	- C# Dev Kit (by Microsoft)
	- C# (by Microsoft)
	- NuGet Gallery (by pcislo)

**Option 2: Install via Command Line**
```bash
code --install-extension ms-dotnettools.csdevkit
code --install-extension ms-dotnettools.csharp
code --install-extension patcx.vscode-nuget-gallery
```

### 4. Get the Project from Git

4.1  Clone the repository and open it in VS Code:

	git clone https://github.com/ShahryarAlpha/VehicleApp.git
	cd VehicleManagement
	code .

4.2  Restore NuGet Packages

	Open the VS Code terminal and run:
	cd VehicleManagement
	dotnet restore

4.3 Run Both Projects Manually

**Terminal 1 – Run API**

	cd VehicleApi
	dotnet run
	⚠️ Keep this terminal running

**Terminal 2 – Run Blazor App**

	cd VehicleBlazor
	dotnet run

4.4. Open in Browser

1. API Swagger:
	```https://localhost:7043/swagger```
2. Blazor App:
	```https://localhost:7026```

---
##