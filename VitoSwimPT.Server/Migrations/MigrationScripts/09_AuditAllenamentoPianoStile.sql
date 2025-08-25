BEGIN TRANSACTION;
ALTER TABLE [Stili] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Stili] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Piani] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Piani] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Allenamenti] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Allenamenti] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250825132308_AddAuditAllenamentoPianoStile', N'9.0.3');

COMMIT;
GO

