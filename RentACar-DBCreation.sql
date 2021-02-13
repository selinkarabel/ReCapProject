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

	CREATE TABLE Users(
	UserID int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(50),
	MiddleName nvarchar(50),
	LastName nvarchar(50),
	UserEmail nvarchar(50),
	UserPassword nvarchar(50)
)

CREATE TABLE Customers(
	CustomerID int PRIMARY KEY IDENTITY(1,1),
	UserID int,
	CompanyName nvarchar(50),
	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

CREATE TABLE Rentals(
	RentalID int PRIMARY KEY IDENTITY(1,1),
	CarID int,
	CustomerID int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY (CarID) REFERENCES Cars(CarID),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

INSERT INTO Users(FirstName,MiddleName,LastName,UserEmail,UserPassword)
VALUES
	('Selin','-','Karabel','sk@gmail.com','123456'),
	('Cengizhan','M','Karabel','ck@gmail.com','123456'),
	('Chivas','Von','Karabel','cvk@gmail.com','123456');

INSERT INTO Customers(UserID,CompanyName)
VALUES
	('1','Selin K.'),
	('2','TheKarabels'),
	('3','WL German Shepherd');