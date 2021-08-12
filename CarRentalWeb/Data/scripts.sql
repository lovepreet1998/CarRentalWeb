USE [rental_db]
GO
SET IDENTITY_INSERT [dbo].[CarCategories] ON 
GO
INSERT [dbo].[CarCategories] ([CarCategoryID], [CarCategoryName]) VALUES (1, N'SUV')
GO
INSERT [dbo].[CarCategories] ([CarCategoryID], [CarCategoryName]) VALUES (2, N'Hatchback')
GO
INSERT [dbo].[CarCategories] ([CarCategoryID], [CarCategoryName]) VALUES (3, N'Sedan')
GO
INSERT [dbo].[CarCategories] ([CarCategoryID], [CarCategoryName]) VALUES (4, N'Luxury')
GO
SET IDENTITY_INSERT [dbo].[CarCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (1, N'Maruti')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (2, N'Honda')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (3, N'Ford')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (4, N'Mahindra')
GO
INSERT [dbo].[Companies] ([CompanyID], [CompanyName]) VALUES (5, N'Hyndai')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (1, N'Figo', 10, 2, 3)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (2, N'Swift', 12, 2, 1)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (3, N'Amaze', 25, 3, 2)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (4, N'Ciaz MT', 26, 1, 1)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (5, N'Eco Sport', 35, 1, 3)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (6, N' SCORPIO', 35, 1, 4)
GO
INSERT [dbo].[Cars] ([CarID], [CarName], [Price], [CarCategoryID], [CompanyID]) VALUES (7, N'I20', 15, 2, 5)
GO
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[RentDetails] ON 
GO
INSERT [dbo].[RentDetails] ([RentDetailID], [CarID], [CustomerName], [ContactNo], [RentalDate]) VALUES (1, 1, N'Frank Kulas', N'03 736 5891', CAST(N'2021-08-31T11:13:00.0000000' AS DateTime2))
GO
INSERT [dbo].[RentDetails] ([RentDetailID], [CarID], [CustomerName], [ContactNo], [RentalDate]) VALUES (2, 4, N'Ford Trantow', N'02 565 4329 ', CAST(N'2021-09-03T11:14:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[RentDetails] OFF
GO
