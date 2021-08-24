# SCM
A Simple Contact Manager 
# Summary
The Simple Contact Manager is a .Net Framework project that allows users to peruse Contact records, insert new Contact records,
and update existing ones.

The application is responsive, not requiring any full posts back to the controller, and has the following three views.
  1. List: This is the main page and from where all controls are accessed
  2. _Create: This is a partial view that houses the controls for the insert form
  3. _Edit: This is a partial view that houses the controls for the edit form

# Setup
To setup the application, first download, and open the project in visual studio. Within `SCM.Data` navigate to the `App.config` file.
Identify the following lines of code (Line 9-11)
```
  <connectionStrings>
    <add name="SCMContext" connectionString="server=(localdb)\MSSQLLocalDB;database=SCM;" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
Replace the connectionString value based on what works for you. database value can remain the same, however server value should be one of the 
SQL Servers listed in the SQL Server Object Explorer in Visual Studio. (Access the Explorer from View, or by using Ctrl+\,Ctrl+S)

Next, Open up the Package Manager Console (navigate to Tools > NuGet Package Manager > Package Manager Console), switch the Default project to SCM Data, and run the following commands
```
enable-migrations
```
```
add-migration 'initialMigration'
```
```
update-database
```
