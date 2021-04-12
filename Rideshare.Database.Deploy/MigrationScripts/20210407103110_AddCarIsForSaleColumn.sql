IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210407103110_AddCarIsForSaleColumn')
BEGIN
    ALTER TABLE [Cars] ADD [IsForSale] bit NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210407103110_AddCarIsForSaleColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210407103110_AddCarIsForSaleColumn', N'2.2.6-servicing-10079');
END;

GO

