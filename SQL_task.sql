﻿SELECT
    Products.ProductName, 
    Categories.CategoryName
FROM 
    Products
LEFT JOIN 
    ProductCategories ON Products.ProductID = ProductCategories.ProductID
LEFT JOIN 
    Categories ON ProductCategories.CategoryID = Categories.CategoryID;
