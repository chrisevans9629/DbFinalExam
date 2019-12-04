begin tran
Create table Customer (
	CustomerID int primary key,
	CompanyName varchar(45) not null,
	Street varchar(45),
	City varchar(45),
	State char(2),
	ZipCode varchar(15),
	ContactName varchar(45) not null,
	ContactTitle varchar(45) not null,
	ContactTelephone varchar(45) not null,
	BusinessType varchar(45),
	NumberOfEmployees int);
Create table Consultant (
	EmployeeID int primary key,
	FirstName varchar(45) not null,
	LastName varchar(45) not null,
	Street varchar(45),
	City varchar(45),
	State char(2),
	ZipCode varchar(15),
	Telephone varchar(45) not null,
	DateOfBirth date,
	Age int);
Create Table BusinessConsultant(
	EmployeeID int primary key references Consultant(EmployeeID));

Create Table TechnicalConsultant(
	EmployeeID int primary key references Consultant(EmployeeID));

Create table Location(
	LocationID int,
	CustomerID int,
	Street varchar(45) not null,
	City varchar(45) not null,
	State char(2) not null,
	ZipCode varchar(15),
	Telephone varchar(45),
	BuildingSize int,
	Primary Key(LocationID, CustomerID));


-- create technical consultant table
Create table ServicesPerformed(
	ServicesPerformedID int primary key,
	Date datetime not null,
	Amount decimal(8,2) not null,
	CustomerID int Foreign Key References Customer(CustomerID),
	TechnicalConsultantID int Foreign Key References TechnicalConsultant(EmployeeID));

Create table LocationHasServicesPerformed(
	LocationID int,
	CustomerID int,
	Constraint FK_Location foreign key (LocationID, CustomerID) references Location(LocationID,CustomerID),
	ServicesPerformedID int Foreign Key References ServicesPerformed(ServicesPerformedID),
	Primary Key(LocationID, CustomerID, ServicesPerformedID));

Create Table Service(
	ServiceId int primary key,
	Description varchar(45),
	Cost Decimal(6,2),
	Coverage varchar(45),
	ClearanceRequired varchar(45));

Create Table Estimate(
	EstimateID int primary key,
	Date datetime,
	Amount decimal(8,2),
	BusinessConsultant int foreign key references BusinessConsultant(EmployeeID));

Create Table Estimate_Has_Service(
	EstimateID int foreign key references Estimate(EstimateID),
	ServiceID int foreign key references Service(ServiceID),
	primary key (EstimateID, ServiceID));



insert Service(ServiceId,Description,Cost,Coverage,ClearanceRequired) values (10,'Penetration Testing',1000,'Full','High');
insert Service(ServiceId,Description,Cost,Coverage,ClearanceRequired) values (11,'Physical Security',250,'Equipment','Low');
insert Service(ServiceId,Description,Cost,ClearanceRequired) values (12,'Email Phishing Campaign',100,'Low');

insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (1,'Chris','Evans','423 Square Drive','Fort Scott','KS','66701','667-324-6978','12/1/1988',31);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (3,'Steve','Shire','542 Maple St.','Pittsburg','KS','66762','417-454-1243','3/30/1960',59);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (5,'John','Stevens','586 Main Drive','Fort Scott','KS','66701','435-342-6543','1/12/1994',25);

insert BusinessConsultant(EmployeeID) values (3);
insert BusinessConsultant(EmployeeID) values (5);
insert TechnicalConsultant(EmployeeID) values (1);

commit tran