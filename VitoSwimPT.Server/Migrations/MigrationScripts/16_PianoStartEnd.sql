BEGIN TRANSACTION;
ALTER TABLE [Piani] ADD [EndDate] datetime2 NULL;

ALTER TABLE [Piani] ADD [StartDate] datetime2 NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251013090800_PianoStartEnd', N'9.0.3');

COMMIT;
GO

