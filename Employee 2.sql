select City,Department,count(Department) as total from employee group by City,Department;

insert into employee(Name,Department,Salary,City)Values('Priya','QA',60000,'Chennai'),('Hema','IT',85000,'Chennai'),
('Harini','HR',85000,'Chennai'),
('Bala','QA',85000,'Coimbatore'),
('Akash','IT',85000,'Madurai');

select*from employee;
select city,count(City) as total from employee group by city order by total desc;
select city,count(City) as total from employee group by city order by total;

select department,count(Name) as total  from employee group by Department having Department='IT';