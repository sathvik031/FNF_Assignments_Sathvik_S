Create database SampleDb
--Databases are created from the Master database. U can get into master database using 'use' keyword.
use SampleDb -- From now on, any db calls u make shall be executed on the using database.

Create table Employee --name of the table
(
	EmpId int Primary key,
	EmpName nvarchar(50) NOT NULL,
	EmpAddress nvarchar(200) NOT NULL,
	EmpSalary money NOT NULL
)

--TO DELETE THE TABLE U CAN DROP IT
Drop table Employee
use master
Drop database SampleDb --Used for dropping the database

--~~~~~~~~~~~~~~~~~~~~
use master

create database FnfTraining
GO
use FnfTraining
GO
Create table Employee --name of the table
(
	EmpId int Primary key,
	EmpName nvarchar(50) NOT NULL,
	EmpAddress nvarchar(200) NOT NULL,
	EmpSalary money NOT NULL
)
GO --executes a batch of statements upto the point from the previous go.
sp_databases
sp_tables
sp_columns Employee

--create a table called DeptTable with Id and DeptName. I want Id to be auto generated.
create table DeptTable
(
DeptId int primary key identity(1,1),
DeptName nvarchar(20)
)

sp_tables

--Add a new column into the Employee table
Alter table Employee
Add DeptId int NOT NULL references DeptTable(DeptId) -- The value in this column shall be only the values from the DeptID of the DeptTable
--U can also drop the column with alter table.

-- Step 1: Drop the foreign key constraint
ALTER TABLE Employee
DROP CONSTRAINT FK__Employee__DeptId__398D8EEE;
Go
-- Step 2: Drop the column
ALTER TABLE Employee
DROP COLUMN DeptId;
Go
sp_rename column DeptId DeptID

use master
drop database FnfTraining