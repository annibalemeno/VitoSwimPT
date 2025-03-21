BEGIN TRANSACTION;
CREATE TABLE [EserciziAllenamenti] (
    [EsercizioId] int NOT NULL,
    [AllenamentoId] int NOT NULL,
    CONSTRAINT [PK_EserciziAllenamenti] PRIMARY KEY ([EsercizioId], [AllenamentoId]),
    CONSTRAINT [FK_EserciziAllenamenti_Allenamenti_AllenamentoId] FOREIGN KEY ([AllenamentoId]) REFERENCES [Allenamenti] ([AllenamentoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EserciziAllenamenti_Esercizi_EsercizioId] FOREIGN KEY ([EsercizioId]) REFERENCES [Esercizi] ([EsercizioId]) ON DELETE CASCADE
);

CREATE INDEX [IX_EserciziAllenamenti_AllenamentoId] ON [EserciziAllenamenti] ([AllenamentoId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250320120128_EsercizioAllenamento', N'9.0.3');

COMMIT;
GO

