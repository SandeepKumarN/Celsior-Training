use pubs
go
select * from publishers

select * from publishers where country = 'USA'

select * from publishers where country != 'USA'

select * from publishers where country <> 'USA'

select * from publishers where country = 'USA' and city='Boston'

select * from publishers where country = 'USA'or city='Paris'

select * from titles

select * from titles where price<15

select title, price, notes from titles

select title, price, notes from titles where price<15

select title from titles where price>8 and price<15

select * from titles where type = 'business' or type = 'psycology'

select * from titles where type in ('business', 'psycology')

select * from titles where type not in ('business', 'psycology')

select * from titles where price is null

select * from titles where title like '%Anger%'

select * from titles where title like '_he%'

select * from employee

select * from employee where fname like '%e%'

select * from employee where hire_date < '1991-10-26'

select * from employee where pub_id  = 0877 and minit <> ''

select * from employee order by fname

select * from employee order by fname desc

select * from employee order by pub_id

select * from employee order by pub_id, fname

select * from employee order by pub_id desc, fname

select * from employee where fname like '%e%' order by pub_id



select count(emp_id) from employee

select count(emp_id) as no_of_employees from employee


select min(job_id) from employee
select min(job_id) least_job_id from employee

select min(hire_date) from employee
select min(hire_date) first_hire_date from employee


select * from titles


select min(price) as min_title_price from titles
select avg(price) as average_cost from titles where pub_id = 1389;
select sum(price) as total_price FROM titles WHERE type = 'business';

select max(price) max_title_price from titles
select * from titles where price = (select max(price) from titles);

select count(title_id) as num_of_titles from titles where type = 'popular_comp';


select pub_id, avg(price) avg_price from titles group by pub_id

select type, count(title_id) no_of_titles from titles group by type

select pub_id, count(emp_id) as num_of_employees from employee group by pub_id

select country, count(pub_id) as num_of_publishers from publishers group by country

select country, count(pub_id) as num_of_publishers from publishers group by country having count(pub_id)>2



