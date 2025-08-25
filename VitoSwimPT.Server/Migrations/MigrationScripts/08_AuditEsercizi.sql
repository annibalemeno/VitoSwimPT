BEGIN TRANSACTION;
ALTER TABLE [Esercizi] ADD [InsertDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

ALTER TABLE [Esercizi] ADD [UpdateDateTime] datetime2 NOT NULL DEFAULT (GETDATE());

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250825131737_AuditEsercizi', N'9.0.3');

COMMIT;
GO

