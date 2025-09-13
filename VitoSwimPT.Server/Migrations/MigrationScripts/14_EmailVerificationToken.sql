BEGIN TRANSACTION;
CREATE TABLE [EmailVerificationTokens] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [CreatedOnUtc] datetime2 NOT NULL,
    [ExpiresOnUtc] datetime2 NOT NULL,
    CONSTRAINT [PK_EmailVerificationTokens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailVerificationTokens_Utenti_UserId] FOREIGN KEY ([UserId]) REFERENCES [Utenti] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_EmailVerificationTokens_UserId] ON [EmailVerificationTokens] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250830113907_EmailVerificationToken', N'9.0.3');

COMMIT;
GO

