# 🧩 Subscription System 

## 🌟 Overview
This project is a **WPF desktop application** built using the **MVVM (Model-View-ViewModel) design pattern** and connected to a **MySQL database**.

It demonstrates how to build a **real-world, maintainable desktop application** with clean architecture, proper separation of concerns, and full **CRUD (Create, Read, Update, Delete)** functionality.

The application manages:
- **Email Users**
- **Software Subscriptions**
- **Domain Subscriptions**
- **Dashboard Overview**


## 📊 Dashboard Overview
The application contains a **central dashboard** that provides a quick system overview.

### Dashboard Features
- 📧 **Total Email Users count**
- 🌐 **Total Domains count**
- 💻 **Total Software Subscriptions count**
- Real-time updates when records are added or removed
- Clean, read-only summary view for administrators

The dashboard helps users instantly understand system usage without navigating into individual modules.

---

## 🚀 Key Features

### 👤 Email User Management
- Add new email users  
- Edit existing users  
- Delete users with confirmation  
- Prevent duplicate email registrations  
- Real-time DataGrid refresh  

### 💻 Software Subscription Management
- Add software subscriptions  
- Edit subscription details  
- Delete subscriptions  
- Plan types and categories via ComboBoxes  
- Date handling with DatePickers  
- Live updates using `ObservableCollection`  
- Integrated DataGrid with **Edit / Delete actions**

### 🌐 Domain Subscription Management
- Add Domain subscriptions  
- Edit Domain details  
- Delete Domain  
- Date handling with DatePickers  
- Live updates using `ObservableCollection`  
- Integrated DataGrid with **Edit / Delete actions**

--- 

### 🧠 Architecture & Design
- Strict **MVVM pattern**
- No business logic in Views
- Reusable **RelayCommand**
- Service layer for database operations
- Property change notifications using `INotifyPropertyChanged`

---

## 🏗 Application Architecture

```text
Project│
├── Models
│   ├── EmailUser.cs
│   └── SoftwareSubscription.cs
│
├── Views
│   ├── EmailView.xaml
│   └── SoftwareView.xaml
│
├── ViewModels
│   ├── DashboardViewModel.cs
│   ├── EmailUserViewModel.cs
│   ├── DomainViewModel.cs
│   └── SoftwareViewModel.cs
│
├── Services
│   ├── EmailUserService.cs
│   └── SoftwareService.cs
│
├── Commands
│   └── RelayCommand.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Styles
│   └── Controls.xaml
└── App.xaml
```

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
- `Pomelo.EntityFrameworkCore.MySql (9.0.0)` – EF Core provider for MySQL  
- `Microsoft.EntityFrameworkCore.Tools (9.0.12)` – EF Core tools for migrations and database updates  

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

### 2. Configure Database

- Start MySQL from XAMPP
- Create Database Named `TS`
- Update connection String in `Data/AppDBContext.cs`
```bash
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            "server=localhost;database=TS;user=root;password=;",
            new MySqlServerVersion(new Version(8,0,32))
        );
    }
```

### 3. Run Migrations
```bash
Add-Migration InitialCreate
Update-Database
```

### 4. Run the Application

-  Open the solution in Visual Studio

- Press F5

---

### 🔁 CRUD Workflow (Example)

- User enters data in the form

- Clicks Submit

- RelayCommand triggers ViewModel method

- ViewModel calls Service

- Service updates MySQL via EF Core

- Dashboard & DataGrids refresh automatically