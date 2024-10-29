use Northwind


--1) Select All the  product details
select * from Products

--2) Select the product which are priced more than 10
select * from Products where UnitPrice > 10

--3)  Print the products in the ascending order of price
select * from Products order by UnitPrice asc

--4) Print the products that are price between 10 and 25
select * from Products where UnitPrice between 10 and 25

--5) Print all the products that are packaged in box
select * from Products where UnitsOnOrder != 0

--6) Print the products that are available more than 10 units and are restocked
select * from Products where UnitsInStock < 10 and ReorderLevel > 0

--7) Print the name and price of all the products that are reordered
select ProductName, UnitPrice from Products where ReorderLevel = 0

--8) Print all the customers who have no region
select * from Customers where region is null

--9) print the full name of customers
select ContactName from Customers

--10) Print the number of customers from every country
select Country, count(ContactName) as num_of_customers from Customers group by Country

--11) Count the number of city in every country from which we have customers
select Country, count(City) as num_of_cities from Customers group by Country

--12) Print the total number of sale done by every employee
select EmployeeID, count(EmployeeID) as num_of_sales from Orders group by EmployeeID


--13) Print the total freight charge paid by every customer
select CustomerID, sum(Freight) as total_freight from Orders group by CustomerID


--14) Print the total number of times every product was ordered
select ProductID, count(ProductID) as total_orders from "Order Details" group by ProductID


--15) Print the average price of the products in descending order for every category. Consider the category only if we have more than 2 products in it
select CategoryID, avg(UnitPrice) as average_price
from Products group by CategoryID 
having count(CategoryID) > 2
order by average_price desc


select * from Products
select * from Customers
select * from Orders
select * from Employees

