ALTER TABLE [User]
ADD [isApproved] BIT NOT NULL DEFAULT(0),
    [isLocked]   BIT NOT NULL DEFAULT(0),
    [lockedAt]   DATETIME2 NULL,
    [lockedReason] NVARCHAR(200) NULL,
    [createdAt]  DATETIME2 NOT NULL DEFAULT(SYSDATETIME());

	alter table [product] add [IsActive] bit not null default(1);

	INSERT INTO [User] ([username], [email], [password], [role], [avatarURL])
VALUES 
	('seller01', 'seller@gmail.com', '123', 'Seller', 'seller01.png'),
	('customer01', 'customer@gmail.com', '123', 'Customer', 'customer01.png'),
    ('admin01', 'admin@gmail.com', '123', 'SuperAdmin', 'admin01.png'),
    ('support01', 'support@gmail.com', '123', 'Support', 'support01.png'),
    ('moderator01', 'moderator@gmail.com', '123', 'Moderator', 'moderator01.png'),
	('ops01', 'ops@gmail.com', '123', 'Ops', 'ops01.png');
GO

INSERT INTO [Product] ([title], [description], [price], [images], [categoryId], [sellerId], [isAuction], [auctionEndTime])
VALUES 
    ('iPhone 14 Pro', 'Latest Apple iPhone with advanced camera', 999.99, 'iphone1.jpg,iphone2.jpg', 1, 1, 0, NULL),
    ('Nike Running Shoes', 'Comfortable running shoes for athletes', 89.99, 'shoes1.jpg', 2, 1, 0, NULL),
    ('Garden Tool Set', 'Complete gardening tools for home use', 49.99, 'tools1.jpg,tools2.jpg', 3, 1, 1, DATEADD(day, 7, GETDATE())),
    ('Basketball', 'Professional basketball for outdoor games', 29.99, 'ball1.jpg', 4, 1, 0, NULL),
    ('Science Fiction Novel', 'Bestselling sci-fi book series', 14.99, 'book1.jpg', 5, 1, 1, DATEADD(day, 3, GETDATE()));

	INSERT INTO [Category] ([name])
VALUES 
    ('Electronics'),
    ('Clothing & Accessories'),
    ('Home & Garden'),
    ('Sports & Outdoors'),
    ('Books & Media');

	INSERT INTO [Address] ([userId], [fullName], [phone], [street], [city], [state], [country], [isDefault])
VALUES 
    (2, 'John Doe', '123-456-7890', '123 Main St', 'New York', 'NY', 'USA', 1),
    (2, 'John Doe', '123-456-7890', '456 Oak Ave', 'Los Angeles', 'CA', 'USA', 0),
    (1, 'Seller Smith', '987-654-3210', '789 Business Rd', 'Chicago', 'IL', 'USA', 1),
    (3, 'Admin User', '555-123-4567', '321 Admin St', 'Seattle', 'WA', 'USA', 1),
    (4, 'Support Team', '555-987-6543', '654 Support Blvd', 'Miami', 'FL', 'USA', 1);

	INSERT INTO [OrderTable] ([buyerId], [addressId], [orderDate], [totalPrice], [status])
VALUES 
    (2, 1, GETDATE(), 999.99, 'Completed'),
    (2, 2, DATEADD(day, -1, GETDATE()), 89.99, 'Processing'),
    (3, 4, DATEADD(day, -2, GETDATE()), 49.99, 'Shipped'),
    (4, 5, DATEADD(day, -3, GETDATE()), 29.99, 'Pending'),
    (5, 4, DATEADD(day, -4, GETDATE()), 14.99, 'Cancelled');

INSERT INTO [OrderItem] ([orderId], [productId], [quantity], [unitPrice])
VALUES 
    (1, 1, 1, 999.99),
    (2, 2, 1, 89.99),
    (3, 3, 1, 49.99),
    (4, 4, 1, 29.99),
    (5, 5, 1, 14.99);

	select * from Product
	select * from [User]
	select * from OrderTable