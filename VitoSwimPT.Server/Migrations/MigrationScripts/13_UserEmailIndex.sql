BEGIN TRANSACTION;
CREATE UNIQUE INDEX [ix_users_email] ON [utenti] ([email]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830111505_UserEmailIndex', N'9.0.3');

COMMIT;
GO

