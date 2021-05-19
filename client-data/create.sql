-- SQLite Init script
DROP TABLE Address;
DROP TABLE Phone;
DROP TABLE Client;

CREATE TABLE Client(
  Id INTEGER PRIMARY KEY,
  Surname TEXT NOT NULL,
  Names TEXT NOT NULL,
  Email TEXT,
  IsActive INTEGER
);

CREATE TABLE Phone(
  Id INTEGER PRIMARY KEY,
  Type TEXT NOT NULL,
  Number TEXT NOT NULL,
  ClientId INTEGER,
  FOREIGN KEY(ClientId) REFERENCES Client(Id)
);

CREATE TABLE Address(
  Id INTEGER PRIMARY KEY,
  Type TEXT NOT NULL,
  Line1 TEXT NOT NULL,
  Line2 TEXT ,
  City TEXT ,
  Country TEXT ,
  Code TEXT ,
  ClientId INTEGER,
  FOREIGN KEY(ClientId) REFERENCES Client(Id)
);

-- INSERT Clients
INSERT INTO Client (Surname, Names, Email, IsActive)
VALUES('Doe', 'John', 'john.doe@example.com', 1);
INSERT INTO Client (Surname, Names, Email, IsActive)
VALUES('Zulu', 'Jabu', 'jabu.zulu@example.com', 1);

-- INSERT Phones
INSERT INTO Phone (Type, Number, ClientId)
VALUES('Mobile', '0812345678', 1);
INSERT INTO Phone (Type, Number, ClientId)
VALUES('Home', '0123456789', 1);
INSERT INTO Phone (Type, Number, ClientId)
VALUES('Mobile', '0723456789', 2);

-- INSERT Address
INSERT INTO Address (Type, Line1, City, Code, ClientId)
VALUES('Physical', '123 Banana Street', 'Mooinooi', '0999', 1);
INSERT INTO Address (Type, Line1, City, Code, ClientId)
VALUES('Physical', '987 Vue Street', 'Sleepwell', '9000', 2);
INSERT INTO Address (Type, Line1, City, Code, ClientId)
VALUES('Postal', 'PO box 101', 'Sleepwell', '9000', 2);