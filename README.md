# AbsenceTest
This app have been created as a test:
Instructions
In the app directory App_Code, ther is a SLQ script, you have to open it and run it on your SQL Server, in the web config file there is a Connection commented, so you then can change it,  also if you open the project directly in visual studio, the Data base is attached as localdb and you can develop there, then anyway you have to create an Script  and run it in you SQL EXpress or Enterprise Server for the application to run if you want to take it on production enviroment.

Important to know:

From the App_Code Folder

ClDataReturn Is a General class to manage all data return in a table. 
Connection manage all connected object to SQL. 
Absence Manage All Absence Data that you are creating or listening
It is important to run this app in Visual Studio 2019 or higer

//2020,11/20 22PM
I have change the proyec for it to run with Entity Framework and Object Model Class and Inteface, have  added new foltder Interfces for separte the Model from Process.
I also have changed the DataBase name, since I had problem with the other DataBase , know the name is DbTest.

If you want now or in the future, you can create separate proyects for Model (DataObjects), DAL(Data Access Layer), In a big proyect it is recommendated, but since this is a little test I dont see it necesesary


