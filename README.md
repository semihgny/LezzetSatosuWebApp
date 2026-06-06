# LezzetSatosuWebApp

A full-featured cafe/restaurant web application ("Lezzet Şatosu" - Flavor Castle) built with the latest **ASP.NET Core 9 MVC**. It provides a complete content management system with an integrated frontend for customers and an admin panel for restaurant managers.

## Features

- **Menu Management (`menus`)**: Display and manage cafe/restaurant menus dynamically.
- **Reservations (`rezervasyon`)**: Built-in system for customers to make table reservations.
- **Blog System (`blog`)**: A fully functional blog to post news and updates about the cafe.
- **Image Gallery (`Galeri`)**: Showcase the restaurant's atmosphere and dishes.
- **Contact & Inquiries (`iletisim`, `Contact`)**: Integrated contact forms backed by an `IEmailSender` service for email notifications.
- **Admin Area**: Manage all dynamic content (menus, categories, blogs, galleries, and reservations) via a dedicated admin interface.
- **Toast Notifications**: Interactive and beautiful UI pop-up notifications powered by `NToastNotify` (Toastr).

## Technologies Used

- **Framework**: .NET 9.0 (ASP.NET Core MVC)
- **Language**: C# 13 (Implicit with .NET 9)
- **ORM**: Entity Framework Core 9
- **Database**: Microsoft SQL Server
- **Identity & Security**: 
  - ASP.NET Core Identity (`IdentityUser`, `IdentityRole`) for user management and authentication.
  - Custom `ApplicationUser` model extending Identity.
- **Frontend Utilities**:
  - FontAwesome & Ionicons for rich typography and iconography.
  - Custom responsive HTML/CSS/JS themes tailored for cafes.
  - `NToastNotify` for Toastr alerts.
- **Docker Support**: Configured for `win-x64` Nano Server containers (`mcr.microsoft.com/dotnet/aspnet:9.0-nanoserver-1809`).

## Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/semihgny/LezzetSatosuWebApp.git
   cd LezzetSatosuWebApp/cafeSite2
   ```

2. **Database Configuration:**
   The project includes a full database backup file (`LezzetSatosu.sql`) located in the root directory. You can either:
   - Restore this `.sql` file directly into your SQL Server Management Studio (SSMS) to get all existing seed data.
   - Or, update the connection string in `cafeSite2/appsettings.json` to point to your local SQL Server instance:
     ```json
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=Cafe;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     ```
     And then run Entity Framework migrations:
     ```powershell
     Update-Database
     ```

3. **Run the Application:**
   ```bash
   dotnet run
   ```
   Or open `cafeSite2.sln` in Visual Studio 2022 and press `F5`.

## Repository Structure
- `/cafeSite2`: The main ASP.NET Core 9 application source code.
- `LezzetSatosu.sql`: SQL Server database export/backup.
- `LezzetSatosuPublishFile/`: Pre-published files for direct deployment to IIS or other hosting providers.
- `lezzetSatosuImages/`: Raw image assets used throughout the project.

## License

This project is open-source. Please see the repository for more details.
