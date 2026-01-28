# MVVM WPF MySQL Demo Application

## Overview
This project is a **WPF desktop application** built using the **MVVM (Model-View-ViewModel) design pattern** and connected to a **MySQL database**. The application demonstrates the separation of concerns in WPF development, making the code modular, maintainable, and testable.  

**Key highlights:**
- Follows **MVVM architecture** (Model, View, ViewModel separation)
- Connects to **MySQL database** using Entity Framework / ADO.NET
- Includes **CRUD operations** for managing data
- Demonstrates **data binding**, **commands**, and **notifications**
- Designed for **easy extension** to real-world projects  

---

## Features
- **User Management**: Add, edit, and delete users  
- **Email Subscription Form**: Stores user data (first name, last name, company, email, address, password, storage) securely  
- **Dynamic Data Binding**: Updates UI automatically when data changes  
- **MVVM Commands**: Implements ICommand for button actions  
- **Database Interaction**: Connects to MySQL for persistent data storage  
- **Validation & Notifications**: Ensures data integrity and user feedback  

---

## Prerequisites
Before running the application, make sure you have installed:  
- **Visual Studio 2022 or later** (with .NET Desktop Development workload)  
- **.NET Framework 4.8 or compatible version**  
- **MySQL Server** (via XAMPP or standalone installation)  
- **MySQL Workbench** (optional, for database management)  

---

## Setup Instructions

### 1. Clone the Repository
```bash
git clone <repository_url>
cd <project_folder>
