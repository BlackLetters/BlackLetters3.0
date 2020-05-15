CREATE TABLE [dbo].[Books] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (MAX) NULL,
    [Price]         NVARCHAR (MAX) NULL,
    [Status]        NVARCHAR (MAX) NULL,
    [Type]          NVARCHAR (MAX) NULL,
    [Author]        NVARCHAR (MAX) NULL,
    [TransactionID] INT            NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Books_Transactions_TransactionID] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_TransactionID]
    ON [dbo].[Books]([TransactionID] ASC);
