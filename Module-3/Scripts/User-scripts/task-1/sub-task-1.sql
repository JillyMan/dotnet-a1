﻿--Query 1
--select Orders.OrderID, 
--		Orders.ShippedDate as shippedDate, 
--		Orders.ShipVia as shipVia 
--from Northwind.Orders as Orders
--where shippedDate > '1998-04-06' and shipVia >= 2;

--Query 2
--select Orders.OrderID, 
--case 
--	when Orders.ShippedDate is null then 'Not Shipped'
--end as ShippedDate
--from Northwind.Orders as Orders
--where ShippedDate is NULL;

--Query 3
--select Orders.OrderID as 'Order Number',
--case 
--	when Orders.ShippedDate is null then 'Not Shipped'
--	else cast(Orders.ShippedDate as char)
--end as 'Shipped Date'
--from Northwind.Orders as Orders
--where Orders.ShippedDate > '1998-05-05' or Orders.ShippedDate is null;
