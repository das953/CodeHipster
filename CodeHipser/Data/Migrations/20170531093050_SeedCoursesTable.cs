using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeHipser.Data.Migrations
{
    public partial class SeedCoursesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Build a Real-world App with ASP.NET Core and Angular', 'Many companies are starting to use ASP.NET Core for their new projects. If you’re familiar with ASP.NET MVC 5 and Entity Framework 6 and are looking for a course to get you up to speed with ASP.NET Core and Entity Framework Core in a pragmatic way, this course is for you. In this course, you’ll learn how to integrate ASP.NET Core with Angular and build a real-world app.', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Ionic 2 Crash Course (FREE for Limited Time)', 'Ionic is a framework built on top of Angular and it allows you to build hybrid mobile apps for iOS and Android. These apps are essentially web apps that are loaded in a native shell. You can use Ionic plug-ins to access native device functionality. With Ionic you can quickly turn your ideas into real working mobile apps. This course is ideal for busy developers who don’t have a lot of time and want to quickly get started with Ionic.', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Testing Angular Apps with Jasmine', 'Automated testing can help you catch more bugs before releasing your software, and this means better quality software for your users and piece of mind for you. In this course, you’ll learn how to write unit and integration tests for your Angular apps. No prior knowledge or experience of automated testing is required. You’ll learn the fundamentals of automated testing, whats, whys and hows.', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Build Enterprise Applications with Angular 2', 'So you’ve mastered the fundamentals of Angular 2 and are hungry for more? In this course, you’ll learn the key concepts and popular frameworks used with Angular in enterprise applications. You’ll learn about Firebase, implementing authentication and authorization using Auth0 and JSON Web Tokens, building mobile apps with Angular and Ionic, integrating your Angular apps with ASP.NET Core and Redux.', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Become a Full-stack .NET Developer', 'Have you ever wondered how professional developers build an app from A to Z? Have you ever wanted to learn how you should start from requirements document and deliver working software with clean, maintainable and robust code supported by automated tests? This course is exactly what you’re looking for!', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('The Complete ASP.NET MVC 5 Course', 'Learn to build and deploy fast and secure web applications with ASP.NET MVC 5. This course is ideal for developers who are comfortable with C# and have basic familiarity with web development (HTML, CSS, JavaScript and jQuery). You’ll learn how to build a real-world app with ASP.NET MVC 5 and Entity Framework 6.', 'Mosh Hamedani')");

            migrationBuilder.Sql("INSERT INTO Courses (Name, Description, Teacher) VALUES ('Entity Framework in Depth', 'Entity Framework is an Object/Relational Mapper (ORM) that helps you read and write data from and to a database. In this course, I’ll teach you Entity Framework from the basics to advanced topics including code-first and database-first workflows.', 'Mosh Hamedani')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
