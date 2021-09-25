-Crie as tabelas no Server Explorer

CREATE TABLE [dbo].[Login] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (50) NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Jogos] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Numero] NVARCHAR (MAX) NOT NULL,
	[TipoJogo] INT  NOT NULL,
    [QtdaJogada] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-Crie o catalogo Loteria.mdf

-Use a connect string e coloque no app.config
    <connectionStrings>
        <add name="conexaoSQL" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=DIGITE O SEU CAMINHO ATÉ O CATALOGO\Loteria.mdf;Integrated Security=True"/>
      
    </connectionStrings>