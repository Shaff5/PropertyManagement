# PropertyManagement
Property Management CRM

This is the start of a basic CRM for building/landlord property management, somewhat more complicated than the simple CRUD apps that are the basis for learning any new technology. It has a Sql Server database, uses Entity Framework Core for data access, and then has various front ends/frameworks to access this data. I'm starting with a ASP.NET Core web app, and eventually I'd like to have an Angular front end and Xamarin front end, both using a restful API.  After that maybe a React or Vue front end.  The idea is to have some back end functionality that doesn't change much, and use that functionality via various front ends, which seem to change frequently (especially javascript frameworks). I am doing this because whenever I set out to use some new technology/framework I inevitably run up against problems that go beyond the simple CRUD apps that books/docs use as examples.

## Getting Started

PropertyManagement.SqlServerDb is a sql server project containing all the database structures, as well as a post-build script to load a little bit of sample data into the tables. Once the database is built the PropertyManagement.Ui.Mvc project can be run.
