use Northwind

--1) Learn what is cross join
--A cross join returns the Cartesian product of two tables. It combines every row from the first table with every row from the second table.

--2) Print the product from the category 'Dairy Products'
select * from products
where ProductID in (select p.ProductID from products p
join Categories c on p.CategoryID = c.CategoryID
where c.CategoryName = 'Dairy Products')


--3) Print the products supplied by 'Tokyo Traders'
select * from products p
join suppliers s on p.SupplierID = s.SupplierID
where s.CompanyName = 'Tokyo Traders'


--4) Print the categories in which 'Tokyo Traders' supply products
select distinct c.CategoryName
from Categories c
join Products p on c.CategoryID = p.CategoryID
join suppliers s on p.SupplierID = s.SupplierID
where s.CompanyName = 'Tokyo Traders'


--5) Print all orders by customers from 'Spain'
select * from Orders o
join Customers c on o.CustomerID = c.CustomerID
where c.Country = 'Spain'


--6) Print the Customer name and the freight charge
select c.ContactName, o.Freight
from Customers c
join Orders o on c.CustomerID = o.CustomerID


--7) Print product name and quantity sold for all orders
select p.ProductName, q.Quantity
from [Order Details] q
join Products p on q.ProductID = p.ProductID


--8) print the products that are billed and the unbilled products with the price and sale price and the difference
select p.ProductName, p.UnitPrice, od.UnitPrice
from Products p
left join [Order Details] od on p.ProductID = od.ProductID


--9) Print the order number, Customer name, Product name and the quantity sold for all orders
select o.OrderID, c.ContactName, p.ProductName, od.Quantity
from Orders o
join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID


--10) Print the total order amount for every order(price*quantity)+freight
select o.OrderID, 
sum((od.UnitPrice * od.Quantity) + o.Freight) as Total_Amount
from Orders o
join [Order Details] od on o.OrderID = od.OrderID
group by o.OrderID


--11) Print the customer name, Phone, shipper name, phone for every order
select c.ContactName, c.Phone as Customer_Phone, 
s.CompanyName, s.phone as Shipper_Phone
from Orders o
join Customers c on o.CustomerID = c.CustomerID
join Shippers s on o.ShipVia = s.ShipperID


--12) print the shipper name and number of order by the shipper and the total freight charge
select s.CompanyName, 
count(o.OrderID) as Number_of_Orders, 
sum(o.Freight) as Total_Freight
from Shippers s
left join Orders o on s.ShipperID = o.ShipVia
group by s.CompanyName


--13) Print the product name, customer name, total quantity bought for all products sold by employees from 'USA'
select p.ProductName, c.ContactName, sum(od.Quantity) as Total_Quantity
from orders o
join Customers c on o.CustomerID = c.CustomerID
join [Order Details] od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
join Employees e on o.EmployeeID = e.EmployeeID
where e.Country = 'USA'
GROUP BY p.ProductName, c.ContactName


--14) Print the product name, category and the total sale amount sorted by category, Include all products and all categories
select p.ProductName, c.CategoryName, 
sum(od.UnitPrice * od.Quantity) as Total_Sale_Amount
from Products p
join Categories c on p.CategoryID = c.CategoryID
left join [Order Details] od on p.ProductID = od.ProductID
group by p.ProductName, c.CategoryName
order by c.CategoryName


--15) Print the category name and the total sale for category for all
select c.CategoryName, 
count(od.OrderID) as Total_Sale
from Categories c
left join Products p on c.CategoryID = p.CategoryID
left join [Order Details] od on p.ProductID = od.ProductID
group by c.CategoryName

-----------------------------------------
select * from Suppliers
select * from Categories
select * from Customers
select * from Shippers
select * from Orders
select * from Products
select * from Employees