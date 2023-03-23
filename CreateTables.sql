USE [Test]
GO

CREATE TABLE dbo.goods (item_id int PRIMARY KEY, item_name varchar(50));
CREATE TABLE dbo.categories (category_id int PRIMARY KEY, category_name varchar(50));
CREATE TABLE item_category(
    item_id  int REFERENCES dbo.goods(item_id) ON UPDATE CASCADE ON DELETE CASCADE
  , category_id int REFERENCES dbo.categories(category_id) ON UPDATE CASCADE ON DELETE CASCADE
  , PRIMARY KEY (item_id)
);

-- В определенном смысле категория с идентификатором 0 является костылем (т.е. без категории).
-- Изначально, в связовающей таблице предполагалось использовать NULL для товаров, для которых
-- не задана категория, но удачно обработать этот кейс не вышло.
INSERT INTO [dbo].[categories] ([category_id], [category_name]) VALUES (0, '');
INSERT INTO [dbo].[categories] ([category_id], [category_name]) VALUES (1, 'Cat_1');
INSERT INTO [dbo].[categories] ([category_id], [category_name]) VALUES (2, 'Cat_2');
INSERT INTO [dbo].[goods] ([item_id], [item_name]) VALUES (1, 'Test_1');
INSERT INTO [dbo].[goods] ([item_id], [item_name]) VALUES (2, 'Test_2');
INSERT INTO [dbo].[goods] ([item_id], [item_name]) VALUES (3, 'Test_3');
INSERT INTO [dbo].[goods] ([item_id], [item_name]) VALUES (4, 'Test_4');
INSERT INTO [dbo].[item_category] ([item_id], [category_id]) VALUES (1, 1);
INSERT INTO [dbo].[item_category] ([item_id], [category_id]) VALUES (2, 1);
INSERT INTO [dbo].[item_category] ([item_id], [category_id]) VALUES (3, 0);
INSERT INTO [dbo].[item_category] ([item_id], [category_id]) VALUES (4, 2);

GO
