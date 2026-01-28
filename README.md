# MVVM WPF MySQL Demo Application

## 🌟 Overview
This project is a **WPF desktop application** built using the **MVVM (Model-View-ViewModel) design pattern** and connected to a **MySQL database**.  

It demonstrates clean separation of concerns, modular code, and maintainable architecture, making it suitable for real-world desktop applications.

**Key Highlights:**
- Implements **MVVM architecture** (Model, View, ViewModel separation)  
- Connects to **MySQL database** using Entity Framework Core  
- Supports **CRUD operations** for managing data  
- Uses **data binding**, **commands**, and **notifications**  
- Easy to extend and maintain  

---

## 🚀 Features
- **User Management**: Add, edit, and delete users  
- **Email Subscription Form**: Stores user data securely  
- **Dynamic UI Updates**: Reflects data changes automatically  
- **MVVM Commands**: Implements `ICommand` for button actions  
- **Database Integration**: Persistent storage with MySQL  
- **Validation & Notifications**: Ensures proper data handling  

---

## ⚙️ Prerequisites
Before running the application, make sure you have installed:  
- **Visual Studio 2022 or later** (with .NET Desktop Development workload)  
- **.NET Framework 4.8**  
- **MySQL Server** (via XAMPP or standalone installation)  
- **MySQL Workbench** (optional, for database management)  

---

## 🛠 Tech Stack

**Framework & Architecture**  
- **.NET Framework 4.8** – WPF desktop applications  
- **MVVM (Model-View-ViewModel)** – Clean separation of UI and logic  

**Programming Language**  
- **C#** – Backend logic and UI code  

**Database**  
- **MySQL** – Relational database  
- **XAMPP** – Local development environment  

**ORM / NuGet Packages**  
- `Pomelo.EntityFrameworkCore.MySql` – EF Core provider for MySQL  
- `Microsoft.EntityFrameworkCore.Tools` – EF Core tools for migrations and database updates  

**Tools & IDE**  
- **Visual Studio 2022** – Development  
- **Git & GitHub** – Version control  

---

## 📝 Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository_url>
cd <project_folder>
```

---

## 🏗 Application Structure
```bash
MVVM WPF MySQL Demo
│
├── Model       # Database entity classes
├── View        # XAML UI files
├── ViewModel   # Logic, commands, and data binding
├── Services    # Database operations
└── App.config  # Connection string & config