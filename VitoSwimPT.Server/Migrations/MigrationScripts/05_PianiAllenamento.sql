BEGIN TRANSACTION;
CREATE TABLE [PianiAllenamento] (
    [PianoId] int NOT NULL,
    [AllenamentoId] int NOT NULL,
    CONSTRAINT [PK_PianiAllenamento] PRIMARY KEY ([PianoId], [AllenamentoId]),
    CONSTRAINT [FK_PianiAllenamento_Allenamenti_AllenamentoId] FOREIGN KEY ([AllenamentoId]) REFERENCES [Allenamenti] ([AllenamentoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PianiAllenamento_Piani_PianoId] FOREIGN KEY ([PianoId]) REFERENCES [Piani] ([PianoId]) ON DELETE CASCADE
);

CREATE INDEX [IX_PianiAllenamento_AllenamentoId] ON [PianiAllenamento] ([AllenamentoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250323152145_PianiAllenamento', N'9.0.3');

COMMIT;
GO

