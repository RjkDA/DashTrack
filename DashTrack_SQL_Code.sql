
CREATE DATABASE DashTrack

DROP TABLE InfoTable
CREATE TABLE InfoTable
(
	UserID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Name VARCHAR(50) NOT NULL,
	UserName VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Phone CHAR(10) NOT NULL,
	SecurityQ VARCHAR(50) NOT NULL,
	SecurityA VARCHAR(50) NOT NULL,
);

DROP TABLE StatsTable
CREATE TABLE StatsTable
(
	StatsID INT NOT NULL IDENTITY(1,1),
	UserID INT NOT NULL,
	Income DECIMAL(18,2) NULL,
	Gas DECIMAL(18,2) NULL,
	CompletedOn VARCHAR(50) NULL,
	ProfitLoss DECIMAL(18,2) NULL,
	ProfitLossSum DECIMAL(18,2) NULL,
);

-- Register Page
INSERT INTO InfoTable (Name, UserName, Password, Email, Phone, SecurityQ, SecurityA) 
VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)

-- Reset Password
UPDATE InfoTable 
SET Password = @p2 
WHERE Email = @p1

-- Login Page
SELECT Email, Password, UserID 
FROM InfoTable 
WHERE Email = @p1 AND Password = @p2

-- Data Add
INSERT INTO StatsTable (Income, Gas, UserID, CompletedOn, ProfitLoss, ProfitLossSum) 
VALUES (@p1, @p2, @p3, @p4, @p5, @p6)

-- Main Page
SELECT SUM(Income-Gas) AS ProfitLoss, Cast(CompletedOn AS datetime) AS CompletedOn 
FROM StatsTable ST INNER JOIN InfoTable IT ON IT.UserID = ST.UserID
WHERE IT.Email = '" + email + "'
GROUP BY Cast(CompletedOn As datetime)

SELECT SUM(Income) AS IncomeSum, SUM(Gas) AS GasSum 
FROM StatsTable ST INNER JOIN InfoTable IT ON IT.UserID = ST.UserID 
WHERE IT.Email = '" + email + "'

SELECT TOP 10 SUM(Income-Gas) AS ProfitLoss, Email 
FROM StatsTable ST INNER JOIN InfoTable IT ON IT.UserID = ST.UserID 
GROUP BY Email
ORDER BY SUM(ProfitLoss) DESC

SELECT Income, Gas, Cast(CompletedOn AS datetime) AS CompletedOn 
FROM StatsTable ST Inner Join InfoTable IT ON IT.UserID = ST.UserID 
WHERE IT.Email = '" + email + "'

