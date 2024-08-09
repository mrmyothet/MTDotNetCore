- Week 01 - April 8 - April 10
  - C# Basic
  - SQL Basic
  - Ado.Net Read
  - Ado.Net CRUD
  - VSCode
  - Ado.Net Create
- Week 02 - April 22 - April 24
  - Dapper CRUD
  - GitHub Public Setting
  - Database Export as Script
  - EFCore CRUD
  - Console App Folder Structure
  - ASP.NET Core Web API Blog CRUD

- Week 03 - April 29 - May 1
  - ASP.NET Core Web API Dapper CRUD
  - Ado.Net CRUD
  - Dapper Custom Service
  - Ado.Net Custom Service

- Week 04 - May 6 - May 8
  - Layered (N-Layer) Architecture
  - Burma Project Idea Discussion For API 
  - Burma Project Idea JSON data to API
  - Console App CRUD with API using HttpClient
  - Console App CRUD with API using RestClient

- Week 05 - May 13 - May 15
  - Myanmar Proverbs API
  - Pizza API
  - Pizza API using Query with Dapper Service
  - Console App CRUD with API using Refit
  - Windows Forms Intro
  - .net framework vs .net core vs .net
  - Windows Forms - Hello World
  - Windows Forms Blog - Create

- Week 06 - May 27 - May 29
  - Windows Forms Blog - List
  - Windows Forms Blog - Edit, Delete
  - If Case, Switch Case
  - Sql Injection
  - NLayer Architecture
  - JavaScript Blog CRUD
  - Html + JavaScript Blog CRUD

- Week 07 - June 03 - June 05
  - jQuery Plugin (SweetAlert, Notiflix)
  - jQuery_Plugins_DataTable,_Date_Picker,_Ladda_Button,_iCheckbox

- Week 08 - June 10 - June 11
  - Dependency Injection
  - Dependency Injection - Code
  - JetBrains Rider Installation

- Week 09 - June 17 - June 19
  - ASP.NET Core Minimal API CRUD
  - ASP.NET Core Web MVC Blog List
  - ASP.NET Core Web MVC Blog Create
  - ASP.NET Core Web MVC Blog Edit Update Delete
  - AsNoTracking

---

UI + Business Logic + Data Access + Db

Mobile, Web => API => Database

C# => Db

---

Code First   
Database First <=

---

Scaffold-DbContext - to create a model based on the existing database.   

```bash

Scaffold-DbContext "Server=MYOTHETPC\MSSQLSERVER2012;Database=DotNetTrainingBatch4;User   ID=MYOTHETPC\Administrator;Password=admin123!;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ScaffoldDbContext
Scaffold-DbContext "Name=ConnectionStrings:DotNetTrainingBatch4" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext -table Tbl_PieChart

```

```console
dotnet tool install --global dotnet-ef --version 7
dotnet ef dbcontext scaffold "Server=.;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f
```

HTTP Methods
============
- get
- post
- put
- patch
- delete

  - get		  => read
  - post	  => create
  - put/patch => update
  - delete	  => delete

HTTP Status Codes
=================
- 100 - 199 => Information responses
- 200 - 299 => Successful responses
- 300 - 399 => Redirection messages
- 400 - 499 => Client error responses
- 500 - 599 => Server error responses 

Application Environment (Stages)
================================

- DEV - Development - [ Software Developer ]
- SIT - System Integration Test - [ Software Developer & QA Engineer ]
- UAT - User Acceptance Test - [ Client ]
- PROD - Production - [ Public user ]

### HTTPClient 
- Console App - Client (Frontend)
- ASP.NET Core Web API - Server (Backend)
