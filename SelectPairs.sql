USE [Test]
GO

SELECT items.Name, categories.category_name
FROM (
	SELECT goods.item_name AS Name, cat.category_id AS category_id
		FROM [dbo].[goods] AS goods
		JOIN [dbo].[item_category] AS cat ON goods.item_id = cat.item_id
	) AS items
	JOIN [dbo].[categories] AS categories ON categories.category_id = items.category_id;
GO
