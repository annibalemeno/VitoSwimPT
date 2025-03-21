BEGIN TRANSACTION;
CREATE TABLE [Allenamenti] (
    [AllenamentoId] int NOT NULL IDENTITY,
    [NomeAllenamento] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    CONSTRAINT [PK_Allenamenti] PRIMARY KEY ([AllenamentoId])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250318141214_BaseAllenamento', N'9.0.3');

COMMIT;
GO

