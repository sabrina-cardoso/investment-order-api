CREATE DATABASE InvestmentOrdersDb;
GO

USE InvestmentOrdersDb;
GO

CREATE TABLE InvestorProfile (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Investors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(100) NOT NULL,
    Document NVARCHAR(50) NOT NULL UNIQUE,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    ProfileId INT NOT NULL,
    FOREIGN KEY (ProfileId) REFERENCES InvestorProfile(Id)
);
GO

CREATE TABLE AssetType (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Assets (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Code NVARCHAR(10) NOT NULL UNIQUE,
    Typeid INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    LastUpdated DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (Typeid) REFERENCES AssetType(Id)
);
GO

CREATE TABLE OrderStatus (
    Id INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE Orders (
    Id INT PRIMARY KEY IDENTITY(1,1),
    InvestorId INT NOT NULL,
    AssetId INT NOT NULL,
    Amount INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    StatusId INT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (InvestorId) REFERENCES Investors(Id),
    FOREIGN KEY (AssetId) REFERENCES Assets(Id),
    FOREIGN KEY (StatusId) REFERENCES OrderStatus(Id)
);
GO

INSERT INTO InvestorProfile (Id, Name) VALUES (1, 'Conservador');
INSERT INTO InvestorProfile (Id, Name) VALUES (2, 'Moderado');
INSERT INTO InvestorProfile (Id, Name) VALUES (3, 'Agressivo');

INSERT INTO OrderStatus (Id, Name) VALUES (1, 'Pending');
INSERT INTO OrderStatus (Id, Name) VALUES (2, 'Executed');
INSERT INTO OrderStatus (Id, Name) VALUES (3, 'Canceled');
INSERT INTO OrderStatus (Id, Name) VALUES (4, 'Rejected');


INSERT INTO AssetType (Id, Name) VALUES (1, 'Ação');
INSERT INTO AssetType (Id, Name) VALUES (2, 'Opção');
INSERT INTO AssetType (Id, Name) VALUES (3, 'Fundo Imobiliário');
INSERT INTO AssetType (Id, Name) VALUES (4, 'ETF');
INSERT INTO AssetType (Id, Name) VALUES (5, 'BDR');
INSERT INTO AssetType (Id, Name) VALUES (6, 'Futuro');
INSERT INTO AssetType (Id, Name) VALUES (7, 'Tesouro Direto');
