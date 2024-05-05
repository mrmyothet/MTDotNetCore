UI + Business Logic + Data Access + Db

Mobile, Web => API => Database

C# => Db

---

- 2024-04-09--ConsoleApp
- 2024-04-10--Ado.Net
- 2024-04-22--Dapper
- 2024-04-23--EFCore 
- 2024-04-24--ASP.NET Core Web API EFCore CRUD 

---

Code First   
Database First <=

---

Scaffold-DbContext - to create a model based on the existing database.   

```console
Scaffold-DbContext "Server=MYOTHETPC\MSSQLSERVER2012;Database=DotNetTrainingBatch4;User   ID=MYOTHETPC\Administrator;Password=admin123!;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context ScaffoldDbContext
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