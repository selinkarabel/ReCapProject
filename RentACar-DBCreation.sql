CREATE TABLE Cars(
	CarID int PRIMARY KEY IDENTITY(1,1),
	BrandID int,
	ColorID int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions nvarchar(50),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
	FOREIGN KEY (ColorID) REFERENCES Colors(ColorID)
)

CREATE TABLE Colors(
	ColorID int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

CREATE TABLE Brands(
	BrandID int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)


INSERT INTO Cars(BrandID,ColorID,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','2012','100','Manuel'),
	('1','3','2015','150','Automatic'),
	('2','1','2017','200','Automatic Hybrid'),
	('3','3','2014','125','Manuel');

INSERT INTO Colors(ColorName)
VALUES
	('White'),
	('Black'),
	('Red');


INSERT INTO Brands(BrandName)
VALUES
	('Mercedes'),
	('BMW'),
	('Dodge');