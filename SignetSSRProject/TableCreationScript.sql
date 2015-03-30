/*
Author: Ashwin Kannalath
ISC 567
Date: 2/16/2015
TABLE CREATION SCRIPT


/*************************
CREATE DATABASE AND TABLES
**************************/

*/

PRINT 'BEGIN SCRIPT EXECUTION'
GO

--Don't display number of rows inserted. Restricts Messages to print statements
SET NOCOUNT ON
GO

USE master
GO

-- Check if database exists and drop it if it does
IF EXISTS (SELECT * FROM sysdatabases WHERE name='ISC567_SSRS_Database')
      BEGIN
	     DROP DATABASE ISC567_SSRS_Database;
	     PRINT 'Dropped database (Database with name ISC567_SSRS_Database Existed)';
      END
GO

/* Create the Database */

--DROP DATABASE ISC567_SSRS_Database
CREATE DATABASE ISC567_SSRS_Database
GO
PRINT 'Database Created'

USE ISC567_SSRS_Database
GO

/* Create tables with appropriate attributes and data types */

--DROP TABLE Employee
CREATE TABLE Employee (
	EmployeeID INT IDENTITY (1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(30) NOT NULL,
	Supervisor BIT NULL,
	ContractLabor BIT NULL,
	WageRateRT MONEY NULL,
	WageRateOT MONEY NULL,
	HomePhone CHAR(15) NULL,
	CellPhone CHAR(15) NULL,
	Address VARCHAR(100) NULL,
	EmailAddress VARCHAR(60) NULL,
	Notes VARCHAR(100) NULL
	)
GO

--DROP TABLE Customer
CREATE TABLE Customer (
	CustomerID INT IDENTITY (1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Company VARCHAR(30) NULL,
	Title VARCHAR(30) NULL,
	BusinessPhone CHAR(12) NULL,
	HomePhone CHAR(15) NULL,
	CellPhone CHAR(15) NULL,
	FaxNumber CHAR(15) NULL,
	EmailAddress VARCHAR(60) NULL,
	Notes VARCHAR(100) NULL
	)
GO

--DROP TABLE Rate
CREATE TABLE Rate (
	RateID INT IDENTITY (1,1) PRIMARY KEY,
	JobType VARCHAR(40) NOT NULL,
	Supervisor Bit,
	RateRT MONEY NOT NULL,
	RateOT MONEY NOT NULL
	)
GO

--DROP TABLE Attendance
CREATE TABLE Attendance (
	AttendanceID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	Date DATE NOT NULL,
	Attendance VARCHAR(15) NULL,
	HoursMissed DECIMAL NULL,
	Reason VARCHAR(100) NULL,
	Excused BIT NULL
	)
GO

--DROP TABLE HoursWorked
CREATE TABLE HoursWorked (
	HoursWorkedID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	JobID INT NOT NULL,
	ItemNumberID INT NULL,
	Date DATE NOT NULL,
	HoursWorkedRT DECIMAL NULL,
	HoursWorkedOT DECIMAL NULL
	)
GO

--DROP TABLE Job
CREATE TABLE Job (
	JobID INT IDENTITY (1,1) PRIMARY KEY,
	JobNumber VARCHAR(100) NOT NULL,
	CustomerID INT NOT NULL,
	RateID INT NOT NULL,
	VesselName VARCHAR(100) NOT NULL,
	Priority INT NULL,
	Status BIT NULL,
	Description VARCHAR(100) NULL,
	StartDate DATE NULL,
	EndDate DATE NULL
	)
GO

--DROP TABLE ItemNumber
CREATE TABLE ItemNumber (
	ItemNumberID INT IDENTITY (1,1) PRIMARY KEY,
	ItemNumber INT NOT NULL,
	Description VARCHAR(100) NULL
	)
GO

--DROP TABLE MaterialsExpense
CREATE TABLE MaterialsExpense (
	MaterialsExpenseID INT IDENTITY (1,1) PRIMARY KEY,
	Expense MONEY NOT NULL,
	JobID INT NOT NULL,
	ItemNumberID INT NULL, -- Remember an assumption/requirement is that each expense can be related to a particular task/ItemNumber
	ExpenseDescription VARCHAR(50) NULL,
	PONumber CHAR(7) NULL,
	InvoiceNumber CHAR(8) NULL,
	TaxIncluded BIT NULL,
	TaxPercentage DECIMAL NULL,
	MarkupPercentage DECIMAL NULL
	)
GO

--DROP TABLE WageHistory
CREATE TABLE WageHistory (
	WageHistoryID INT IDENTITY (1,1) PRIMARY KEY,
	EmployeeID INT NOT NULL,
	WageRT INT NOT NULL,
	WageOT INT NOT NULL,
	DateStart DATE NULL, 
	DateEnd DATE NULL,
	IsCurrent BIT NOT NULL
	)
GO

PRINT 'Tables Created'


--------------------------------------------------------------------------------------------------------


/******************
CREATE CONSTRAINTS
*******************/

/* Create foreign key constraints */

--ALTER TABLE Job DROP CONSTRAINT FK_Job_Rate
ALTER TABLE Job
ADD CONSTRAINT FK_Job_Rate
FOREIGN KEY (RateID) REFERENCES Rate(RateID)
GO

--ALTER TABLE Job DROP CONSTRAINT FK_Job_Customer
ALTER TABLE Job
ADD CONSTRAINT FK_Job_Customer
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_Employee
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_Job
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_Job
FOREIGN KEY (JobID) REFERENCES Job(JobID)
GO

--ALTER TABLE HoursWorked DROP CONSTRAINT FK_HoursWorked_ItemNumber
ALTER TABLE HoursWorked
ADD CONSTRAINT FK_HoursWorked_ItemNumber
FOREIGN KEY (ItemNumberID) REFERENCES ItemNumber(ItemNumberID)
GO

--ALTER TABLE MaterialsExpense DROP CONSTRAINT FK_MaterialsExpense_Job
ALTER TABLE MaterialsExpense
ADD CONSTRAINT FK_MaterialsExpense_Job
FOREIGN KEY (JobID) REFERENCES Job(JobID)
GO

--ALTER TABLE MaterialsExpense DROP CONSTRAINT FK_MaterialsExpense_ItemNumber
ALTER TABLE MaterialsExpense
ADD CONSTRAINT FK_MaterialsExpense_ItemNumber
FOREIGN KEY (ItemNumberID) REFERENCES ItemNumber(ItemNumberID)
GO

--ALTER TABLE Attendance DROP CONSTRAINT FK_Attendance_Employee
ALTER TABLE Attendance
ADD CONSTRAINT FK_Attendance_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

--ALTER TABLE WageHistory DROP CONSTRAINT FK_WageHistory_Employee
ALTER TABLE WageHistory
ADD CONSTRAINT FK_WageHistory_Employee
FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID)
GO

PRINT 'Foreign Key Constraints Created'
--Rate, Customer,Job