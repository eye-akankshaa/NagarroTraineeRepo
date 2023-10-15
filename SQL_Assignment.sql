
--Exercise 1

--1. Display the number of records in the [SalesPerson] table. (Schema(s) involved: Sales)

Select count(*) as Sales_Person_Count from Sales.SalesPerson;

--2. Select both the FirstName and LastName of records from the Person table where the FirstName begins with the letter ‘B’. 
--(Schema(s) involved: Person)

Select FirstName,LastName from Person.Person where FirstName LIKE 'B%';

--3.Select a list of FirstName and LastName for employees where Title is one of Design Engineer, Tool Designer or Marketing 
--Assistant. (Schema(s) involved: HumanResources, Person)

Select FirstName ,LastName from Person.Person where BusinessEntityID IN 
(Select BusinessEntityID from HumanResources.Employee where
JobTitle='Design Engineer' OR JobTitle='Tool Designer' OR JobTitle='Marketing Assistant');

            --OR

select Firstname, LastName from Person.Person, HumanResources.Employee 
where Person.BusinessEntityID=HumanResources.Employee.BusinessEntityID
and Employee.JobTitle in ('Design Engineer','Tool Designer','Marketing Assistant')




--4.Display the Name and Color of the Product with the maximum weight. (Schema(s) involved: Production)

Select  Name,Color from Production.Product where Weight =(Select max(Weight) from Production.Product);



/*5.Display Description and MaxQty fields from the SpecialOffer table. Some of the MaxQty values are NULL, in this case display 
the value 0.00 instead. (Schema(s) involved: Sales)*/

Select Description , ISNULL(MaxQty,0.00) as MaxQtyNotNull from Sales.SpecialOffer;



/*6.Display the overall Average of the [CurrencyRate].[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’ for the year 2005 
i.e. FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’. Note: The field [CurrencyRate].[AverageRate] is defined as 
'Average exchange rate for the day.' (Schema(s) involved: Sales)*/

Select avg(AverageRate) as Average from  Sales.CurrencyRate where
FromCurrencyCode='USD' and ToCurrencyCode='GBP' and Year(CurrencyRateDate)=2005;



/*7.Display the FirstName and LastName of records from the Person table where FirstName contains the letters ‘ss’. Display an 
additional column with sequential numbers for each row returned beginning at integer 1. (Schema(s) involved: Person)*/

Select FirstName ,LastName from Person.Person where FirstName LIKE '%ss%';--Half Query w/o Serial No

Select ROW_NUMBER() OVER(order by(select null)) as S_No, FirstName,LastName 
from Person.Person where FirstName like '%ss%';



/*8.Sales people receive various commission rates that belong to 1 of 4 bands. (Schema(s) involved: Sales)
CommissionPct Commission Band
0.00 Band 0
Up To 1% Band 1
Up To 1.5% Band 2
Greater 1.5% Band 3
Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate 
band as above*/

Select BusinessEntityID as SalesPersonId,
Case
	when CommissionPct=0.00 then 'Band 0'
	when CommissionPct<=0.01 then 'Band 1'
	when CommissionPct<=0.015 then 'Band 2'
	else 'Band 3'
End as Commission_Band
from Sales.SalesPerson;



/*9.Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez. Hint: use 
[uspGetEmployeeManagers] (Schema(s) involved: [Person], [HumanResources] */

--using existing stored procedure of the adventure works database

DECLARE @tempId AS INT    --declaring local variable temp of int type

SET @tempId=(select BusinessEntityID from Person.Person where FirstName='Ruth' 
	AND LastName='Ellerbrock' AND PersonType='EM')--starting point jaha s we want the hierarchy
 
execute dbo.uspGetEmployeeManagers @tempId;--executing procedure


/*10.Display the ProductId of the product with the largest stock level. Hint: Use the Scalar-valued function [dbo]. [UfnGetStock]. 
(Schema(s) involved: Production)*/

select top 1 ProductId from Production.Product
order by  [dbo].[ufnGetStock](ProductID) desc;








-------------------------------*******************************************---------------------------------------
 


 --Exercise-2

/*Write separate queries using a join, a subquery, a CTE, and then an EXISTS to list all AdventureWorks
customers who have not placed an order*/
 
 --LEFT JOIN
Select c.CustomerID
From Sales.Customer c 
	 LEFT JOIN Sales.SalesOrderHeader s ON c.CustomerID=s.CustomerID
WHERE s.SalesOrderID IS NULL 

--RIGHT JOIN
Select c.CustomerID
From Sales.SalesOrderHeader s
	 RIGHT JOIN  Sales.Customer c ON s.CustomerID=c.CustomerID
WHERE s.SalesOrderID IS NULL

--INNER JOIN
Select CustomerID
From Sales.Customer
WHERE CustomerID NOT IN
(Select c.CustomerID
From sales.Customer c
	 INNER JOIN sales.SalesOrderHeader s ON c.CustomerID=s.CustomerID)

--using SUBQUERY
Select CustomerID
From sales.Customer
WHERE CustomerID NOT IN
(Select CustomerID 
From sales.SalesOrderHeader)

--using CTE
WITH ctecust(CustomerID) --creating common table expression
AS
(
	Select CustomerID
	From sales.Customer
	WHERE CustomerID NOT IN
	(Select CustomerID 
	  From sales.SalesOrderHeader)
)
Select * From ctecust

--Using Exists
Select CustomerID
From Sales.Customer
WHERE CustomerID NOT IN(Select c.CustomerID
From Sales.Customer c
WHERE EXISTS 
(Select s.CustomerID 
From Sales.SalesOrderHeader s
WHERE s.CustomerID=c.CustomerID))

--using NOT EXISTS
Select c.CustomerID
From Sales.Customer c
WHERE NOT EXISTS 
(Select s.CustomerID 
From Sales.SalesOrderHeader s
WHERE c.CustomerID=s.CustomerID)










----------------------------------*************************--------------------------------

 --Exercise-3

 /*Show the most recent five orders that were purchased from account numbers that have spent more than $70,000 
   with AdventureWorks.*/

--CTE

with tempSales 
as (
	Select *,Row_Number() 
	over(Partition by AccountNumber order by OrderDate desc) 
	as RowNumber
	from sales.SalesOrderHeader)

Select * from tempSales
where AccountNumber in(
	Select AccountNumber from Sales.SalesOrderHeader
	group by AccountNumber having sum(TotalDue)>70000) and
RowNumber<6 order by AccountNumber,OrderDate desc

---------------------------------**************************************------------------------------------------
 
 
 
 --Exercise-4
 
/*Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date, and returns a table of all the SalesOrderDetail rows 
for that Sales Order including Quantity, ProductID, UnitPrice, and the unit price converted to the target currency based on the end of 
day rate for the date provided. Exchange rates can be found in the Sales.CurrencyRate table. ( Use AdventureWorks)*/



GO
---Inline Table Valued Function
CREATE FUNCTION dbo.getDetailSalesOrder(@SalesOrderID int, @CurrencyCode nchar(3), @CurrencyDate datetime)
RETURNS TABLE
AS RETURN(Select SalesOrderID, SalesOrderDetailID, ProductID, OrderQty, UnitPrice, UnitPrice*EndOfDayRate as 'ConvertedPrice'
	from Sales.SalesOrderDetail, Sales.CurrencyRate
	where SalesOrderID=@SalesOrderID and  ToCurrencyCode=@CurrencyCode and CurrencyRateDate=@CurrencyDate)

GO
Select * from dbo.getDetailSalesOrder(45343,'JPY','2005-08-24 00:00:00.000')





















------------------------------***********************************--------------------------------------





--Exercise-5

/*Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. Alter the above 
Store Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)*/


Go
Create procedure dbo.uspGetFirstName(@FirstName nvarchar(50))
as
BEGIN 
	select * 
	from Person.Person 
	where FirstName=@FirstName 
END
GO
exec dbo.uspGetFirstName 'Stanley'


/*ALTER procedure [dbo].[uspGetFirstName](@FirstName nvarchar(50)=null)
as
begin 
	select * 
	from Person.Person 
	where FirstName=@FirstName end

exec dbo.uspGetFirstName*/





--------------------------------***********************************----------------------------------------






--Exercise-6

/*Write a trigger for the Product table to ensure the list price can never be raised more than 15 Percent in a single change. Modify the 
above trigger to execute its check code only if the ListPrice column is updated (Use AdventureWorks Database)*/

--Generic Update
GO
CREATE TRIGGER checkPrice
ON Production.Product
FOR UPDATE
AS
IF  EXISTS(SELECT 1 FROM Product p JOIN deleted d ON p.ProductID=d.ProductID AND p.ListPrice-d.ListPrice>0.15*d.ListPrice)
BEGIN 
RAISERROR('You can not update list price by more than 15percent', 16, 1)
ROLLBACK TRAN--Transaction rolled back and aborted
RETURN
END

GO

--Specific Update

/*	Modified trigger uncomment and execute to see the changes
ALTER TRIGGER [Production].[checkPrice]
ON [Production].[Product]
FOR UPDATE
AS
SET NOCOUNT ON
IF UPDATE(ListPrice)
BEGIN
IF  EXISTS(SELECT 1 FROM Product p JOIN deleted d ON p.ProductID=d.ProductID AND p.ListPrice-d.ListPrice>0.15*d.ListPrice)
BEGIN
RAISERROR('You can not update list price by more than 15percent', 16, 1)
ROLLBACK TRAN
RETURN
END
END
SET NOCOUNT OFF
*/

Update Production.Product
Set ListPrice=40
Where ProductID=1

go
Select * from Production.Product where ProductID=1;