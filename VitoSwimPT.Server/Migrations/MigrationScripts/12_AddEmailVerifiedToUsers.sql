BEGIN TRANSACTION;
ALTER TABLE [Utenti] ADD [EmailVerified] bit NOT NULL DEFAULT CAST(0 AS bit);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830111037_AddEmailVerifiedToUsers', N'9.0.3');

COMMIT;
GO

