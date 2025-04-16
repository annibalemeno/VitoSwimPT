BEGIN TRANSACTION;
DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Esercizi]') AND [c].[name] = N'Stile');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Esercizi] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Esercizi] DROP COLUMN [Stile];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250403210912_StileStringRemoved', N'9.0.3');

COMMIT;
GO

