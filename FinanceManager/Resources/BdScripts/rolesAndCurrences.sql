USE [FinanceManager]
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (1, N'Рубль', N'RUB', 60)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (13, N'Доллар', N'USD', 1)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (16, N'Евро', N'EUR', 1.1)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (18, N'Йена', N'JPY', 120)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (19, N'Швейцарский франк', N'CHF', 1.03)
INSERT [dbo].[Currencies] ([CurrencyId], [Name], [Abbreviation], [Quote]) VALUES (20, N'Британский фунт', N'GBR', 1.5)
SET IDENTITY_INSERT [dbo].[Currencies] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [Name], [Priority]) VALUES (1, N'Админ', 10)
INSERT [dbo].[Roles] ([RoleId], [Name], [Priority]) VALUES (2, N'Пользователь', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
