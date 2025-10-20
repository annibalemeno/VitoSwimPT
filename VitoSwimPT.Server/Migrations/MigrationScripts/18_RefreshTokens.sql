BEGIN TRANSACTION;
CREATE TABLE [RefreshTokens] (
    [Id] uniqueidentifier NOT NULL,
    [Token] nvarchar(max) NOT NULL,
    [ExpiresOnUTC] datetime2 NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_RefreshTokens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RefreshTokens_Utenti_UserId] FOREIGN KEY ([UserId]) REFERENCES [Utenti] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_RefreshTokens_UserId] ON [RefreshTokens] ([UserId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251020093743_RefreshToken', N'9.0.3');

COMMIT;
GO

