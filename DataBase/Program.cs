using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = null;
            SqlDataAdapter da = null;
            DataSet set = null;
            SqlCommandBuilder cmd = null;

            string cs = "";
            conn = new SqlConnection();
            cs = conn.ConnectionString = ConfigurationManager.ConnectionStrings["open"].ConnectionString;
            set = new DataSet();

            string Users = @"create table Users(id int identity primary key not null, Name nvarchar(15) not null, Surname nvarchar(15) not null, Patronymic nvarchar(15) not null, Role nvarchar(15) not null)";
            da = new SqlDataAdapter(Users, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Thread.Sleep(2000);

            string Autorization = @"create table Autorization(id int identity primary key not null, IDUser int foreign key references Users(id) not null, Login nvarchar(15) not null, Password nvarchar(15) not null)";
            da = new SqlDataAdapter(Autorization, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Thread.Sleep(2000);

            string Employee = @"create table Employee(id int identity primary key not null, Name nvarchar(15) not null, Surname nvarchar(15) not null, Patronymic nvarchar(15) not null, DateOfBirth datetime not null, Address nvarchar(70) not null, Phone nvarchar(13) not null, Email nvarchar(60) not null)"; 
            da = new SqlDataAdapter(Employee, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Thread.Sleep(2000);

            string Rating = @"create table Rating(id int identity primary key not null, IDEmployee int foreign key references Employee(id) not null, Scores int not null)";
            da = new SqlDataAdapter(Rating, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Thread.Sleep(2000);

            string Technology = @"create table Technology(id int identity primary key not null, Title nvarchar(40) not null)";
            da = new SqlDataAdapter(Technology, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Thread.Sleep(2000);

            string WhatCan = @"create table WhatCan(id int identity primary key not null, IDTechnology int foreign key references Technology(id) not null, IDEmployee int foreign key references Employee(id) not null)";
            da = new SqlDataAdapter(WhatCan, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            string Reviews = @"create table Reviews(id int identity primary key not null, IDEmployee int foreign key references Employee(id) not null, IDUser int foreign key references Users(id) not null, Date datetime not null, Comments nvarchar(max) not null)";
            da = new SqlDataAdapter(Reviews, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            string StatusTitle = @"create table StatusTitle(id int identity primary key not null, Title nvarchar(30) not null)";
            da = new SqlDataAdapter(StatusTitle, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            string Resume = @"create table Resume(id int identity primary key not null, IDEmployee int foreign key references Employee(id) not null, FileName nvarchar(50) not null, Text varbinary(max) not null)";
            da = new SqlDataAdapter(Resume, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            string EmployeeStatus = @"create table EmployeeStatus(id int identity primary key not null, IDEmployee int foreign key references Employee(id) not null, IDStatusTitle int foreign key references StatusTitle(id) not null)";
            da = new SqlDataAdapter(EmployeeStatus, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            string Results = @"create table Results(id int identity primary key not null, IDEmployee int foreign key references Employee(id) not null, IDUser int foreign key references Users(id) not null, FileName nvarchar(50) not null, Text varbinary(max) not null, Title nvarchar(30) not null)";
            da = new SqlDataAdapter(Results, conn);
            cmd = new SqlCommandBuilder(da);
            da.Fill(set);

            Console.WriteLine("Таблицы созданы");
            Console.ReadLine();
        }
    }
}
