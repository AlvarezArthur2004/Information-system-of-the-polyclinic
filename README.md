## Description

This is a hospital management system on ASP.NET.CORE that includes scheduling, electronic medical records, auth system,and databases for doctors, patients, and administrators.


## Used Frameworks

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.NETCore.App
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Syncfusion.DocIO.Net.Core
- Syncfusion.DocIORenderer.Net.Core

## How to start
Download all essential Framework. Also you need to upload Microsoft SQL Server Manager and make basic setting.

Open NuGet Package Console and write this commands

 	add-migration ApplicationDBContextMigration -context ApplicationDBContext
  	add-migration DoctorDbContextMigration -context DoctorDbContext
   	add-migration CommentDbContextMigration -context CommentDbContext
    add-migration ApplicationUserMigration -context ApplicationUser

	Update-Database -context ApplicationDBContext
 	Update-Database -context DoctorDbContext
	Update-Database -context CommentDbContext
 	Update-Database -context ApplicationUser

After that find Auth file and press start
