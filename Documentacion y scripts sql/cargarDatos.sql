USE [retoBackendOrenes]
GO
INSERT [dbo].[tblCliente] ([clienteId], [nombre], [correo], [telefono]) VALUES (N'f20487d1-31a5-4393-9835-05aab14c8bbb', N'Pepito', N'pepito@gmail.com', N'111111111')
INSERT [dbo].[tblCliente] ([clienteId], [nombre], [correo], [telefono]) VALUES (N'7981bfbb-8491-4a86-bdae-7e51459cf7e1', N'Desiderio Almansa', N'desiderio.almansa.p@gmail.com', N'872648958')
INSERT [dbo].[tblCliente] ([clienteId], [nombre], [correo], [telefono]) VALUES (N'3f42dba4-8094-440b-9a8b-a3f91c90d3e5', N'Antonio', N'antonio@gmail.com', N'33333333')
INSERT [dbo].[tblCliente] ([clienteId], [nombre], [correo], [telefono]) VALUES (N'9cef0e8a-f6dd-417a-87d4-c68c2f6363dc', N'Juan', N'juan@gmail.com', N'222222222')
GO
INSERT [dbo].[tblConductor] ([conductorId], [nombre], [telefono], [carnetCirculacion]) VALUES (N'95620e2b-307e-48b6-9a4b-3aab29f5fe08', N'Alejandro', N'567568865', N'B')
INSERT [dbo].[tblConductor] ([conductorId], [nombre], [telefono], [carnetCirculacion]) VALUES (N'7fafd5c9-f1d0-4c33-84b2-6dc3847f5e7b', N'Pedro', N'123123123', N'C')
INSERT [dbo].[tblConductor] ([conductorId], [nombre], [telefono], [carnetCirculacion]) VALUES (N'cf14928f-4f2c-4918-b936-f7e71069d152', N'Javier', N'345345345', N'C')
GO
INSERT [dbo].[tblVehiculo] ([vehiculoId], [conductorId], [pedidosPendientes], [ubicacionActual]) VALUES (N'c0f395f3-7012-4f6b-ac94-00e8572df166', N'cf14928f-4f2c-4918-b936-f7e71069d152', 0, N'40.982526, -3.925930')
INSERT [dbo].[tblVehiculo] ([vehiculoId], [conductorId], [pedidosPendientes], [ubicacionActual]) VALUES (N'cfcdabd5-19b7-4b76-9685-0b7bbf064c94', N'95620e2b-307e-48b6-9a4b-3aab29f5fe08', 0, N'47.984441, -3.928233')
INSERT [dbo].[tblVehiculo] ([vehiculoId], [conductorId], [pedidosPendientes], [ubicacionActual]) VALUES (N'ea0afe9e-6b86-4043-b322-665148de9941', N'7fafd5c9-f1d0-4c33-84b2-6dc3847f5e7b', 2, N'38.996401, -3.922214')
GO
INSERT [dbo].[tblPedido] ([numeroPedido], [clienteId], [direccionEnvio], [bultos], [importeTotal], [vehiculoId], [fechaCreacion], [entregado]) VALUES (N'5c814a96-7320-4287-8ff2-5a6b1a3e1cbb', N'f20487d1-31a5-4393-9835-05aab14c8bbb', N'Calle Ejemplo, 8, Ciudad Real', 1, CAST(20.00 AS Decimal(18, 2)), N'cfcdabd5-19b7-4b76-9685-0b7bbf064c94', CAST(N'2022-09-23T18:15:57.8100000' AS DateTime2), 0)
INSERT [dbo].[tblPedido] ([numeroPedido], [clienteId], [direccionEnvio], [bultos], [importeTotal], [vehiculoId], [fechaCreacion], [entregado]) VALUES (N'68771b79-4432-4ba0-a534-6f354510b3e2', N'9cef0e8a-f6dd-417a-87d4-c68c2f6363dc', N'Calle Ejemplo4, 2, Almagro', 4, CAST(80.00 AS Decimal(18, 2)), N'ea0afe9e-6b86-4043-b322-665148de9941', CAST(N'2022-09-24T01:29:04.9034173' AS DateTime2), 0)
INSERT [dbo].[tblPedido] ([numeroPedido], [clienteId], [direccionEnvio], [bultos], [importeTotal], [vehiculoId], [fechaCreacion], [entregado]) VALUES (N'34c3e0b2-ba04-48c9-85bd-7f5f358f184d', N'3f42dba4-8094-440b-9a8b-a3f91c90d3e5', N'Calle Ejemplo3, 2, Bolaños de Calatrava', 1, CAST(50.00 AS Decimal(18, 2)), N'ea0afe9e-6b86-4043-b322-665148de9941', CAST(N'2022-09-24T01:28:27.3679996' AS DateTime2), 0)
INSERT [dbo].[tblPedido] ([numeroPedido], [clienteId], [direccionEnvio], [bultos], [importeTotal], [vehiculoId], [fechaCreacion], [entregado]) VALUES (N'657de340-e91d-4065-a3e0-fed3e2ddb361', N'7981bfbb-8491-4a86-bdae-7e51459cf7e1', N'Calle Ejemplo2, 2, Madrid', 2, CAST(30.00 AS Decimal(18, 2)), N'c0f395f3-7012-4f6b-ac94-00e8572df166', CAST(N'2022-09-24T01:27:24.5670301' AS DateTime2), 0)
GO
INSERT [dbo].[tblLogCambiosUbicacion] ([logId], [vehiculoId], [fechaCambio], [ubicacionAnterior], [ubicacionNueva]) VALUES (N'fe9af1a0-fd3e-484e-a875-08da9d80a1a3', N'c0f395f3-7012-4f6b-ac94-00e8572df166', CAST(N'2022-09-23T18:28:21.9419999' AS DateTime2), N'45.982526, -3.925930', N'39.982526, -3.925930')
INSERT [dbo].[tblLogCambiosUbicacion] ([logId], [vehiculoId], [fechaCambio], [ubicacionAnterior], [ubicacionNueva]) VALUES (N'25a90b05-cc2a-4b2b-36e5-08da9d8deb9c', N'cfcdabd5-19b7-4b76-9685-0b7bbf064c94', CAST(N'2022-09-23T20:03:29.5083111' AS DateTime2), N'38.984441, -3.928233', N'50.984441, -3.928233')
INSERT [dbo].[tblLogCambiosUbicacion] ([logId], [vehiculoId], [fechaCambio], [ubicacionAnterior], [ubicacionNueva]) VALUES (N'74bc59a1-1b05-4387-2421-08da9d98a8f0', N'c0f395f3-7012-4f6b-ac94-00e8572df166', CAST(N'2022-09-23T21:20:22.1173257' AS DateTime2), N'39.982526, -3.925930', N'40.982526, -3.925930')
INSERT [dbo].[tblLogCambiosUbicacion] ([logId], [vehiculoId], [fechaCambio], [ubicacionAnterior], [ubicacionNueva]) VALUES (N'd19b0f98-5343-4e42-8b99-08da9d9d6405', N'cfcdabd5-19b7-4b76-9685-0b7bbf064c94', CAST(N'2022-09-23T21:54:13.9779741' AS DateTime2), N'50.984441, -3.928233', N'47.984441, -3.928233')
GO
