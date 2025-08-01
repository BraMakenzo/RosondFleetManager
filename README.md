# Rosond Fleet Manager

A complete ASP.NET MVC web application for managing vehicles, suppliers, clients, branches, drivers, and operational reports.

## Features

- Vehicle CRUD with optional driver creation
- Supplier, Branch, Client, and Driver management (CRUD)
- Summary Reports:
  - Vehicles per Supplier
  - Vehicles per Branch
  - Vehicles per Client
  - Vehicles per Manufacturer
- Entity Framework Code-First with Migrations
- Bootstrap-styled responsive UI
- Entity Relationship Diagram (ERD) included

## Technologies

- ASP.NET MVC 5
- C#
- Entity Framework 6 (Code-First)
- Microsoft SQL Server
- Bootstrap 3
- LINQ

## Project Structure

RosondFleetManager/
|
├── Controllers/           // MVC controllers (Vehicles, Drivers, Reports, etc.)
├── Models/                // Domain models and ViewModels
├── Views/                 // Razor Views (.cshtml)
│   └── Shared/            // _Layout.cshtml and shared UI
│   └── Reports/           // Report Index page
├── Migrations/            // EF Code-First migration files
├── App_Data/              // Local DB (if applicable)
├── Content/               // Bootstrap, custom CSS
├── Scripts/               // jQuery, validation, etc.
└── README.md              // This file

## Setup Instructions

1. Clone the repository

   git clone https://github.com/BraMakenzo/RosondFleetManager.git  
   cd RosondFleetManager

2. Open the project in Visual Studio (2019 or 2022)

3. Restore NuGet packages  
   Visual Studio should do this automatically on build. Otherwise use:

   Tools > NuGet Package Manager > Package Manager Console  
   PM> Update-Package -reinstall

4. Run database migrations  
   In Package Manager Console:

   PM> Update-Database

5. Start the application (F5)

# Entity Relationship Diagram

Available in the Documentation folder as:  
Vehicle_ERD_NoAsterisks.pdf

# Release Notes

See ReleaseNotes.txt for a full summary of completed features and decisions made.
##  Documentation

- [Vehicle_ERD.pdf](Documentation/Vehicle_ERD.pdf) – Entity Relationship Diagram (ERD)
- [Release_Notes_RosondFleetManager.txt](Documentation/Release_Notes_RosondFleetManager.txt) – Release Notes


# Author

Bra Makenzo  
GitHub: https://github.com/BraMakenzo
