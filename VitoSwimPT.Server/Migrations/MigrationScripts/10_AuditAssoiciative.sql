BEGIN TRANSACTION;
ALTER TABLE [PianiAllenamento] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [PianiAllenamento] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [EserciziAllenamenti] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [EserciziAllenamenti] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250825133121_AddAuditAssociative', N'9.0.3');

COMMIT;
GO

