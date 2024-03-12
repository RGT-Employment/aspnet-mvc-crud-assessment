CREATE TABLE [dbo].[LaunchEntry] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [LaunchInfo]       NVARCHAR (50) NULL,
    [PostedByUserName] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
