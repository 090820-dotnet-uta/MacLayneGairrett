SELECT * FROM Customer;

SELECT CustomerId, FirstName, LastName, Country 
FROM Customer
WHERE Country != 'USA';

SELECT CustomerId, Country
FROM Customer
WHERE Country = 'Brazil';

SELECT *
FROM Employee
WHERE Title LIKE '%Sales%';

SELECT DISTINCT BillingCountry
FROM Invoice;

SELECT SUM(Total) AS TotalAmount, COUNT(InvoiceId)
AS Invoicesin2009
FROM Invoice
WHERE InvoiceDate LIKE '%2009%';

SELECT COUNT(InvoiceId) AS Invoice37Entries
FROM InvoiceLine
WHERE InvoiceId = 37;

SELECT COUNT(InvoiceId) AS Invoices, BillingCountry
FROM Invoice
GROUP BY BillingCountry;

SELECT BillingCountry, SUM(Total)
FROM Invoice
GROUP BY BillingCountry
ORDER BY SUM(Total) DESC;






