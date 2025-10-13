BEGIN TRANSACTION;
ALTER TABLE [Piani] ADD [Createdby] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';

CREATE INDEX [IX_Piani_Createdby] ON [Piani] ([Createdby]);

ALTER TABLE [Piani] ADD CONSTRAINT [FK_Piani_Utenti_Createdby] FOREIGN KEY ([Createdby]) REFERENCES [Utenti] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250913091435_PianoCreatedBy', N'9.0.3');

COMMIT;
GO

