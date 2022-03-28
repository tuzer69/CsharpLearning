USE BankSystem

create table Clients (
	Id int IDENTITY NOT NULL,
	FName nvarchar(50) NOT NULL,
	LName nvarchar(50),
	MName nvarchar(50),

	CONSTRAINT PK_Client PRIMARY KEY (Id),
	CONSTRAINT UQ_Client UNIQUE (FName, LName, MName)
)

create table Accounts (
	Id int IDENTITY NOT NULL,
	ClientId int NOT NULL,
	AccNumber int NOT NULL,
	IsDeposit bit NOT NULL,
	Balance int DEFAULT (0)

	CONSTRAINT UQ_Account UNIQUE (AccNumber),
	CONSTRAINT PK_Account PRIMARY KEY (Id),
	CONSTRAINT FK_Client FOREIGN KEY (ClientId) REFERENCES Clients(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)

