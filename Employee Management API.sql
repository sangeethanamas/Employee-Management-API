Create table employee(ID int not null primary key identity(1,1), Name varchar(200),Department varchar(100),Salary decimal(10,2));

select*from employee;

insert into employee(Name,Department,Salary)values('Hari','HR',2500);