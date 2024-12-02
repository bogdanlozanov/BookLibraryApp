# BookLibraryApp

**BookLibraryApp** is a web application built with ASP.NET Core and Entity Framework Core that allows users to browse a library of books, manage their favorites, and manage users (for admins). It includes features like authentication, role-based authorization, and database seeding.

---

## Features

- **User Authentication**:
  - Users can register, log in, and log out.
  - Admin and regular user roles.
- **Book Management**:
  - Users can view a list of books.
  - Admins can add, edit, and delete books.
- **Favorites Management**:
  - Users can add books to their favorites.
  - Users can view and remove books from their favorites list.
- **Admin Dashboard**:
  - Manage books and users.
  - Assign roles to users.
- **Database Seeding**:
  - Preloaded books and a default admin user.

---

## Installation

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Clone the Repository

```bash
git clone https://github.com/bogdanlozanov/BookLibraryApp.git
cd BookLibraryApp


Technologies Used
Framework: ASP.NET Core
Database: SQL Server (Entity Framework Core)
Frontend: Razor Pages, Bootstrap
Authentication: ASP.NET Identity
