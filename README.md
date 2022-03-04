# EFWinFormsApp
Basic C# CRUD Application using EntityFramework

## How to install?
You must first download **EntityFramework** from your NuGet Package Manager.

You may install it in the NuGet Package Manager/Console inside the Visual Studio by running the command
```
Install-Package EntityFramework
```
Once installed, create a folder inside the project named **Models**
Inside this, **Models** folder, add all the **Model** you would like to use for the application.

Example:
```
    public class Student
    {  
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
```

Once all of them **Models** been added, create a folder named **Data**.

Add the Following code:

```
    public class <Name Of App and with the 'Context' word> : DbContext
    {
        public <Name Of App and with the 'Context' word>() : base()
        {

        }
        //For Example we are using Student model
        public DbSet<Student> Students { get; set; }
    }
```


run the command in the * NuGet Package Manager Console *
```
Enable-Migrations
Add-Migration <Migration Name>
```
Then followed by:
```
Update-Database
```

Once everything is all set, you may use the following CRUD functionality on any page/forms of preference:

## Usage

### Add
```
//Instantiate
<Name of App and with the 'Context' word> context = new <Name Of App and with the 'Context' word>();
 ....
 ....
 context.Students.Add(new Student()
 {
  FirstName = <value>,
  LastName = <value>
 });
 context.SaveChanges();
```
### Update
```
//Instantiate
<Name of App and with the 'Context' word> context = new <Name Of App and with the 'Context' word>();
 ....
 ....
Student student = context.Students.Find(<value>);
student.FirstName = <value>;
student.LastName = <value>;
context.Entry(student).State = EntityState.Modified;
context.SaveChanges();
````
### Delete
```
//Instantiate
<Name of App and with the 'Context' word> context = new <Name Of App and with the 'Context' word>();
 ....
 ....
 Student student = context.Students.Find(<integer value>;
 context.Students.Remove(student);
 context.SaveChanges();
````
### Read
```
//Instantiate
<Name of App and with the 'Context' word> context = new <Name Of App and with the 'Context' word>();
 ....
 ....
 //If using DataGridView
dataGridView1.DataSource = context.Students.ToList();
````
