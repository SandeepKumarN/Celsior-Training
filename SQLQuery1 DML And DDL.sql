create database databasecourse07oct2024

use databasecourse07oct2024


CREATE TABLE Areas 
(area varchar(10) primary key,
zipcode char(6)
);

CREATE TABLE Employees
(id INT IDENTITY(101,1) constraint pk_employee_ID primary key,
name varchar(20),
phone varchar(15),
area varchar(10) constraint fk_area foreign key references Areas(area))

sp_help Areas

Drop Table Areas;

select * from Areas;

INSERT INTO Areas(area, zipcode)
VALUES('Bengaluru', '560045'),
('Hyderabad', '562105'),
('Noida', '563425'),
('Delhi', '543218');


sp_help Employees

INSERT INTO Employees(name,phone,area) VALUES('San', '12345', 'Bengaluru'), 
('ABC', '123678', 'Hyderabad');

Select * From Employees;

Drop Table Employees;

CREATE TABLE Skills
(skill_name varchar(50) constraint pk_skill primary key,
skill_description varchar(1000))

insert into Skills values('C#', 'Web'), ('Java', 'oops');

CREATE TABLE EmployeeSkills
(Employee_id INT constraint fk_Employee_Skill_id foreign key references Employees(ID),
Employee_Skill varchar(50) constraint fk_Skill foreign key references Skills(skill_name),
skill_level float,
constraint pk_employee_skill primary key(Employee_id, Employee_skill))

sp_help EmployeeSkills

drop table EmployeeSkills
INSERT INTO EmployeeSkills VALUES(101, 'C#', 4),(101, 'Java', 4);

select * from EmployeeSkills;


