begin try
begin tran
Create table Customer (
	CustomerID int,
	CompanyName varchar(45) not null,
	Street varchar(45),
	City varchar(45),
	State char(2),
	ZipCode varchar(15),
	ContactName varchar(45) not null,
	ContactTitle varchar(45) not null,
	ContactTelephone varchar(45) not null,
	BusinessType varchar(45),
	NumberOfEmployees int,
	Primary Key(CustomerID)
	);

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

Create table Consultant(
	EmployeeID int,
	FirstName varchar(45) not null,
	LastName varchar(45) not null,
	Street varchar(45),
	City varchar(45),
	State char(2),
	ZipCode varchar(15),
	Telephone varchar(45),
	DateOfBirth date not null,
	Age int not null,
	Primary Key(EmployeeID)
);
Create table TechnicalConsultant(
	EmployeeID int primary key references Consultant(EmployeeID)
);

Create table BusinessConsultant(
	EmployeeID int primary key references Consultant(EmployeeID)
);

Create table ServicesPerformed(
	ServicesPerformedID int,
	Date datetime not null,
	Amount decimal(8,2) not null,
	Primary Key(ServicesPerformedID),
	CustomerID int Foreign Key References Customer(CustomerID),
	TechnicalConsultantID int Foreign Key References TechnicalConsultant(EmployeeID));

Create table LocationHasServicesPerformed(
	LocationID int,
	CustomerID int,
	Constraint FK_Location Foreign Key (LocationID, CustomerID) references Location(LocationID,CustomerID),
	ServicesPerformedID int Foreign Key References ServicesPerformed(ServicesPerformedID),
	Primary Key(LocationID, CustomerID, ServicesPerformedID));



Create table Estimate(
	EstimateID int,
	Date datetime not null,
	Amount decimal(8,2) not null,
	Primary Key(EstimateID),
	BusinessConsultant int Foreign Key References BusinessConsultant(EmployeeID),
	CustomerID int Foreign Key References Customer(CustomerID)
);

Create table Service(
	ServiceID int,
	Description varchar(45),
	Cost decimal(6,2) not null,
	Coverage varchar(45),
	ClearanceRequired varchar(45),
	Primary Key(ServiceID)
);

Create table EstimateHasService(
	EstimateID int Foreign Key References Estimate(EstimateID),
	ServiceID int Foreign Key References Service(ServiceID),
	Primary Key(EstimateID, ServiceID)
);

Create table ServicesPerformedHasService(
	ServicesPerformedID int Foreign Key References ServicesPerformed(ServicesPerformedID),
	ServiceID int Foreign Key References Service(ServiceID),
	Primary Key(ServicesPerformedID, ServiceID)
);

Create table TechnicalSkill(
	TechnicalSkillID varchar(45),
	Description varchar(45),
	EmployeeID int Foreign Key References TechnicalConsultant(EmployeeID),
	Primary Key(TechnicalSkillID)
);

Create table BusinessExperience(
	BusinessExperienceID int,
	NumberOfYears int not null,
	TypeOfBusiness varchar(45),
	EmployeeID int Foreign Key References BusinessConsultant(EmployeeID),
	Primary Key(BusinessExperienceID)
);

Create table Degree(
	DegreeID varchar(45),
	Description varchar(100),
	Primary Key(DegreeID)
);


Create table BusinessExperienceHasDegree(
	BusinessExperienceID int Foreign Key References BusinessExperience(BusinessExperienceID),
	DegreeID varchar(45) Foreign Key References Degree(DegreeID),
	Primary Key(BusinessExperienceID, DegreeID)
);

Create table TechnicalConsultantHasDegree(
	EmployeeID int Foreign Key References TechnicalConsultant(EmployeeID),
	DegreeID varchar(45) Foreign Key References Degree(DegreeID),
	Primary Key(EmployeeID, DegreeID)
);


insert Service(ServiceId,Description,Cost,Coverage,ClearanceRequired) values (10,'Penetration Testing',1000,'Full','High');
insert Service(ServiceId,Description,Cost,Coverage,ClearanceRequired) values (11,'Physical Security',250,'Equipment','Low');
insert Service(ServiceId,Description,Cost,ClearanceRequired) values (12,'Email Phishing Campaign',100,'Medium');
insert Service(ServiceId,Description,Cost,ClearanceRequired) values (13,'Contingency Plan',2000,'High');
insert Service(ServiceId,Description,Cost,ClearanceRequired) values (14,'Denial of Service Testing',300,'Low');

insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (1,'Chris','Evans','423 Square Drive','Fort Scott','KS','66701','667-324-6978','12/1/1988',31);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (3,'Steve','Shire','542 Maple St.','Pittsburg','KS','66762','417-454-1243','3/30/1960',59);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (5,'John','Stevens','586 Main Drive','Fort Scott','KS','66701','435-342-6543','1/12/1994',25);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (2,'John','Snow','654 Game St','Cheyanne','WY','65464','435-342-1355','1/12/1994',25);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (4,'Catnis','Everdeen','349 Hunger Road','Fort Scott','KS','66701','435-342-6546','3/10/1933',86);

insert Degree(DegreeID, Description) values ('CIS', 'Bachelor of Business Administration Computer Information Systems');
insert Degree(DegreeID, Description) values ('CS', 'Bachelor of Science');
insert Degree(DegreeID, Description) values ('ACCTG', 'Bachelor of Business Administration Accounting');
insert Degree(DegreeID, Description) values ('HRM', 'Bachelor of Psychology Human Resource Management');
insert Degree(DegreeID, Description) values ('MKTG', 'Bachelor of Business Administration Marketing');

insert BusinessConsultant(EmployeeID) values (3);
insert BusinessConsultant(EmployeeID) values (5);
insert BusinessConsultant(EmployeeID) values (1);
insert BusinessConsultant(EmployeeID) values (2);
insert BusinessConsultant(EmployeeID) values (4);

INSERT INTO [dbo].[BusinessExperience]
           ([BusinessExperienceID]
           ,[NumberOfYears]
           ,[TypeOfBusiness]
           ,[EmployeeID])
     VALUES
           (1
           ,3
           ,'Marketing'
           ,3);
INSERT INTO [dbo].[BusinessExperience]
           ([BusinessExperienceID]
           ,[NumberOfYears]
           ,[TypeOfBusiness]
           ,[EmployeeID])
     VALUES
           (2
           ,5
           ,'Security Consulting'
           ,5);
INSERT INTO [dbo].[BusinessExperience]
           ([BusinessExperienceID]
           ,[NumberOfYears]
           ,[TypeOfBusiness]
           ,[EmployeeID])
     VALUES
           (3
           ,10
           ,'Software Developer'
           ,1);
INSERT INTO [dbo].[BusinessExperience]
           ([BusinessExperienceID]
           ,[NumberOfYears]
           ,[TypeOfBusiness]
           ,[EmployeeID])
     VALUES
           (4
           ,7
           ,'Pentration Testing'
           ,2);
INSERT INTO [dbo].[BusinessExperience]
           ([BusinessExperienceID]
           ,[NumberOfYears]
           ,[TypeOfBusiness]
           ,[EmployeeID])
     VALUES
           (5
           ,1
           ,'Physical Security'
           ,4);


INSERT INTO BusinessExperienceHasDegree(BusinessExperienceID,DegreeID) values (1,'MKTG');
INSERT INTO BusinessExperienceHasDegree(BusinessExperienceID,DegreeID) values (2,'CIS');
INSERT INTO BusinessExperienceHasDegree(BusinessExperienceID,DegreeID) values (3,'CS');
INSERT INTO BusinessExperienceHasDegree(BusinessExperienceID,DegreeID) values (4,'CS');
INSERT INTO BusinessExperienceHasDegree(BusinessExperienceID,DegreeID) values (5,'ACCTG');

insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (6,'Luke','Skywalker','445 Force Drive','Nevada','MO','64772','667-324-4568','12/1/1988',31);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (7,'Harry','Potter','123 Staircase Avenue','Kansas City','KS','64101','417-454-4569','3/30/1960',59);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (8,'Ron','Weesley','456 Rat Drive','Kansas City','KS','64102','435-342-4543','1/12/1994',25);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (9,'John','Larrinson','544 Larry Avenue','Ballard','MO','64123','417-654-7998','3/12/1960',59);
insert Consultant(EmployeeID,FirstName,LastName,Street,City,State,ZipCode,Telephone,DateOfBirth,Age) 
	values (10,'Drako','Mouthful','456 Snake Street','Kansas City','KS','64102','435-342-4543','4/12/1994',25);

insert TechnicalConsultant(EmployeeID) values (6);
insert TechnicalConsultant(EmployeeID) values (7);
insert TechnicalConsultant(EmployeeID) values (8);
insert TechnicalConsultant(EmployeeID) values (9);
insert TechnicalConsultant(EmployeeID) values (10);


insert Customer(CustomerID,CompanyName, Street, City, State, 
	ZipCode, ContactName, ContactTitle, ContactTelephone,
	BusinessType, NumberOfEmployees) 
	values 
	(10,'Peerless Products Inc.', '4320 Main St.', 'Fort Scott', 'KS', '66701', 'Steven Burn','IT Manager', '667-123-4654', 'Manufacturing', 400);

insert Customer(CustomerID,CompanyName, Street, City, State, 
	ZipCode, ContactName, ContactTitle, ContactTelephone,
	BusinessType, NumberOfEmployees) 
	values 
	(11,'Pittsburg State University', '1701 S Broadway', 'Pittsburg', 'KS', '66762', 'Dr. Sha','CIS Professor', '667-123-3254', 'Education', 312);
insert Customer(CustomerID,CompanyName, Street, City, State, 
	ZipCode, ContactName, ContactTitle, ContactTelephone,
	BusinessType, NumberOfEmployees) 
	values 
	(12,'McDonalds', '2342 Maple St.', 'Fort Scott', 'KS', '66701', 'Ronald McDonald','Marketing', '667-123-2345', 'Restaurant', 10);
insert Customer(CustomerID,CompanyName, Street, City, State, 
	ZipCode, ContactName, ContactTitle, ContactTelephone,
	BusinessType, NumberOfEmployees) 
	values 
	(13,'Salon 9', '5843 1st Street', 'Pittsburg', 'KS', '66762', 'Sally Salington','Branch Manager', '667-345-3453', 'Cosmetology', 15);
insert Customer(CustomerID,CompanyName, Street, City, State, 
	ZipCode, ContactName, ContactTitle, ContactTelephone,
	BusinessType, NumberOfEmployees) 
	values 
	(14,'Watko', '2345 Main St.', 'Pittsburg', 'KS', '66762', 'John Wattson','Plant Manager', '667-123-3453', 'Manufacturing', 345);



insert Location(CustomerID,LocationID, BuildingSize, Street, City, State, ZipCode, Telephone)
	values (10,1,123,'4320 Main St.', 'Fort Scott', 'KS', '66701', '667-123-3453');
insert Location(CustomerID,LocationID, BuildingSize, Street, City, State, ZipCode, Telephone)
	values (11,1,1245,'1701 S Broadway', 'Pittsburg', 'KS', '66762', '667-123-4567');
insert Location(CustomerID,LocationID, BuildingSize, Street, City, State, ZipCode, Telephone)
	values (12,1,45668,'2342 Maple St.', 'Fort Scott', 'KS', '66701', '667-123-7569');
insert Location(CustomerID,LocationID, BuildingSize, Street, City, State, ZipCode, Telephone)
	values (13,1,7894,'5843 1st Street', 'Pittsburg', 'KS', '66762', '667-123-7522');
insert Location(CustomerID,LocationID, BuildingSize, Street, City, State, ZipCode, Telephone)
	values (14,1,4566,'2345 Main St.', 'Pittsburg', 'KS', '66762', '667-123-4452');

INSERT INTO Estimate(EstimateID,CustomerID,BusinessConsultant,Amount,Date) VALUES (1,10,1,2000,'11/30/2019');
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (1,10);
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (1,12);

INSERT INTO Estimate(EstimateID,CustomerID,BusinessConsultant,Amount,Date) VALUES (2,11,2,300,'11/3/2019');
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (2,11);

INSERT INTO Estimate(EstimateID,CustomerID,BusinessConsultant,Amount,Date) VALUES (3,12,3,3000,'12/6/2019');
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (3,13);

INSERT INTO Estimate(EstimateID,CustomerID,BusinessConsultant,Amount,Date) VALUES (4,13,4,700,'11/15/2019');
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (4,14);
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (4,11);

INSERT INTO Estimate(EstimateID,CustomerID,BusinessConsultant,Amount,Date) VALUES (5,14,5,3000,'12/5/2019');
INSERT INTO EstimateHasService(EstimateID,ServiceID) VALUES (5,13);

INSERT INTO ServicesPerformed(ServicesPerformedID,CustomerID,TechnicalConsultantID,Amount,Date) VALUES (1,10,6,2100,'11/30/2019');
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (1,10);
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (1,12);

INSERT INTO ServicesPerformed(ServicesPerformedID,CustomerID,TechnicalConsultantID,Amount,Date) VALUES (2,11,7,300,'11/5/2019');
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (2,11);

INSERT INTO ServicesPerformed(ServicesPerformedID,CustomerID,TechnicalConsultantID,Amount,Date) VALUES (3,12,8,3150.89,'12/8/2019');
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (3,13);

INSERT INTO ServicesPerformed(ServicesPerformedID,CustomerID,TechnicalConsultantID,Amount,Date) VALUES (4,13,9,700,'11/20/2019');
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (4,14);
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (4,11);

INSERT INTO ServicesPerformed(ServicesPerformedID,CustomerID,TechnicalConsultantID,Amount,Date) VALUES (5,14,10,3500,'12/10/2019');
INSERT INTO ServicesPerformedHasService(ServicesPerformedID,ServiceID) VALUES (5,13);


INSERT INTO TechnicalConsultantHasDegree(DegreeID,EmployeeID) VALUES ('ACCTG',6);
INSERT INTO TechnicalConsultantHasDegree(DegreeID,EmployeeID) VALUES ('CS',7);
INSERT INTO TechnicalConsultantHasDegree(DegreeID,EmployeeID) VALUES ('HRM',8);
INSERT INTO TechnicalConsultantHasDegree(DegreeID,EmployeeID) VALUES ('CIS',9);
INSERT INTO TechnicalConsultantHasDegree(DegreeID,EmployeeID) VALUES ('MKTG',10);

INSERT INTO TechnicalSkill(TechnicalSkillID,EmployeeID,Description) VALUES ('PEN TEST',6,'Pentration Testing');
INSERT INTO TechnicalSkill(TechnicalSkillID,EmployeeID,Description) VALUES ('CODE',7,'Software Development');
INSERT INTO TechnicalSkill(TechnicalSkillID,EmployeeID,Description) VALUES ('SALES',8,'Sales & Marketing');
INSERT INTO TechnicalSkill(TechnicalSkillID,EmployeeID,Description) VALUES ('PHYSC',9,'Physical Security');
INSERT INTO TechnicalSkill(TechnicalSkillID,EmployeeID,Description) VALUES ('BACKUP',10,'Contingency Planning & Backup');

INSERT INTO LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (1,10,1);
INSERT INTO LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (2,11,1);
INSERT INTO LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (3,12,1);
INSERT INTO LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (4,13,1);
INSERT INTO LocationHasServicesPerformed(ServicesPerformedID,CustomerID,LocationID) VALUES (5,14,1);

commit tran;
end try
begin catch
	rollback tran
end catch