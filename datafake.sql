USE DATABASE CoffeeShopManagement

INSERT INTO Role (RoleId, RoleName) VALUES (0, N'Cửa hàng trưởng');
INSERT INTO Role (RoleId, RoleName) VALUES (1, N'Nhân viên phục vụ');
INSERT INTO Role (RoleId, RoleName) VALUES (2, N'Nhân viên đặt hàng');
INSERT INTO Role (RoleId, RoleName) VALUES (3, N'Nhân viên bếp');

INSERT INTO Status (StatusId, Name) VALUES (0, N'Hủy đơn');
INSERT INTO Status (StatusId, Name) VALUES (1, N'Đã nhận đơn');
INSERT INTO Status (StatusId, Name) VALUES (2, N'Đang chế biến');
INSERT INTO Status (StatusId, Name) VALUES (3, N'Xong');

INSERT INTO Product (ProductId, ProductName, Price, Status) VALUES ('0372207B-214C-4088-8CB9-09E6B93F8B35', N'Espresso Đá', 20000, '1');
INSERT INTO Product (ProductId, ProductName, Price, Status) VALUES ('9C941CBF-C308-4FB5-AB9F-22DFF8C5B91F', N'Espresso Nóng', 18000, '1');
INSERT INTO Product (ProductId, ProductName, Price, Status) VALUES ('47240FC5-ECAC-42A0-9366-7D2D2CFC8237', N'Phin Di Choco', 27000, '1');
INSERT INTO Product (ProductId, ProductName, Price, Status) VALUES ('8B5A887C-5DF7-4804-A7B4-C092D194E8B4', N'Phin Di sữa đá', 25000, '1');
INSERT INTO Product (ProductId, ProductName, Price, Status) VALUES ('812D806F-4716-45CE-B294-F2A7F3EFD377', N'Trà Đào Cam Xả', 25000, '1');

INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('ab28df5a-8ff0-4c45-b47b-16c1995279a0', '0', N'Trần Thiện Chí', N'Thành Phố Hồ Chí Minh', '123458791', 12000000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('1a940b9a-d161-4c89-81a4-e0a3b2de74fb', '1', N'Lê Văn Nam', N'Thành Phố Hồ Chí Minh', '965784125', 5000000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('0182c33f-3df0-4b68-b26d-aa05f2e828c5', '1', N'Nhiên Khánh Linh', N'Thành Phố Hồ Chí Minh', '927626525', 5500000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('b05618a8-0455-47b0-8462-f421f881f178', '1', N'Khanh Nguyệt Cầm', N'Thành Phố Hồ Chí Minh', '567608096', 5500000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('3aa88e8b-4c8e-4461-8fc8-296183d3d482', '1', N'Khanh Lò', N'Thành Phố Hồ Chí Minh', '978347849', 5500000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('1496835c-75d6-47d4-9ebe-8e05356d139e', '2', N'Trần Khánh Hoàng', N'Thành Phố Hồ Chí Minh', '457895234', 4000000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('76ce881a-72e5-4c75-9c54-58d7a016bdff', '3', N'Trương Liêu', N'Thành Phố Hồ Chí Minh', '257894142', 3500000, 'TRUE');
INSERT INTO Employee (EmployeeId,RoleId ,FullName ,Address ,Phone ,Salary ,Status) VALUES ('8f1e2cb0-f3f5-40a2-99e0-3dcb19dcdbb0', '3', N'Tống Ngọc Linh', N'Thành Phố Hồ Chí Minh', '126874145', 3000000, 'TRUE');


INSERT INTO PrimaryOrder (OrderId, EmployeeId, OrderDate, Note, Total, Status) VALUES ('8f5a63c9-c78d-4a74-a02e-708e569075c9', '1a940b9a-d161-4c89-81a4-e0a3b2de74fb', '2023-02-21', N'Không đường', 2, 0);
INSERT INTO PrimaryOrder (OrderId, EmployeeId, OrderDate, Note, Total, Status) VALUES ('03444f98-8e65-4ca5-a5b4-5799f19ca087', '0182c33f-3df0-4b68-b26d-aa05f2e828c5', '2023-02-22', N'50% đá', 5, 1);
INSERT INTO PrimaryOrder (OrderId, EmployeeId, OrderDate, Note, Total, Status) VALUES ('3af851f1-e813-4772-9abd-12d3aaf32a14', '1a940b9a-d161-4c89-81a4-e0a3b2de74fb', '2023-02-23', N'Đá riêng', 4, 2);
INSERT INTO PrimaryOrder (OrderId, EmployeeId, OrderDate, Note, Total, Status) VALUES ('7cc1b02b-2828-418e-a8e8-2b0023e32111', '0182c33f-3df0-4b68-b26d-aa05f2e828c5', '2023-02-24', N'75% đường', 2, 1);
INSERT INTO PrimaryOrder (OrderId, EmployeeId, OrderDate, Note, Total, Status) VALUES ('33ac6468-c59e-4089-96ba-097275dc97a1', 'b05618a8-0455-47b0-8462-f421f881f178', '2023-02-25', N'Thêm Topping', 1, 3);

INSERT INTO OrderDetails (OrderDetailsID, OrderId, ProductId, Quantity, Amount, OrderDate) VALUES ('1136d1d0-940f-44fa-a754-81f28159bad5', '8f5a63c9-c78d-4a74-a02e-708e569075c9', '0372207B-214C-4088-8CB9-09E6B93F8B35', 2, 40000, '2023-02-17');
INSERT INTO OrderDetails (OrderDetailsID, OrderId, ProductId, Quantity, Amount, OrderDate) VALUES ('90497414-822f-4615-89ca-40c64db81388', '8f5a63c9-c78d-4a74-a02e-708e569075c9', '9C941CBF-C308-4FB5-AB9F-22DFF8C5B91F', 1, 18000, '2023-02-17');
INSERT INTO OrderDetails (OrderDetailsID, OrderId, ProductId, Quantity, Amount, OrderDate) VALUES ('ff47dd86-fb57-4bff-99bd-9b2299bd9bcb', '3af851f1-e813-4772-9abd-12d3aaf32a14', '47240FC5-ECAC-42A0-9366-7D2D2CFC8237', 1, 27000, '2023-02-19');
INSERT INTO OrderDetails (OrderDetailsID, OrderId, ProductId, Quantity, Amount, OrderDate) VALUES ('4f23b04b-de8d-4341-9923-1ca6445f5be8', '7cc1b02b-2828-418e-a8e8-2b0023e32111', '47240FC5-ECAC-42A0-9366-7D2D2CFC8237', 2, 27000, '2023-02-20');
INSERT INTO OrderDetails (OrderDetailsID, OrderId, ProductId, Quantity, Amount, OrderDate) VALUES ('396bf1bc-27a9-46e5-b2fa-3d316680e761', '33ac6468-c59e-4089-96ba-097275dc97a1', '812D806F-4716-45CE-B294-F2A7F3EFD377', 1, 25000, '2023-02-21');

