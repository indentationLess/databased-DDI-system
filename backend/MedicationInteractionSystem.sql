CREATE DATABASE MedicationInteractionSystem;

USE MedicationInteractionSystem;


CREATE TABLE DrugCategory (
    DrugCategoryID INT PRIMARY KEY,
    CategoryName NVARCHAR(255),
    Description NVARCHAR(MAX)
);

INSERT INTO DrugCategory (DrugCategoryID, CategoryName, Description)
VALUES
(1, 'Antibiotics', 'Drugs used to treat bacterial infections'),
(2, 'Antipyretics', 'Drugs that reduce fever'),
(3, 'Analgesics', 'YOU GOT ANY IBUPROFEN?I HAVE A HEADACHE.');

SELECT * FROM DrugCategory;

CREATE TABLE Drug (
    DrugID INT PRIMARY KEY,
    Name NVARCHAR(255),
    GenericName NVARCHAR(255),
    BrandName NVARCHAR(255),
    DosageForm NVARCHAR(50),
    Strength NVARCHAR(50),
    DrugCategoryID INT FOREIGN KEY REFERENCES DrugCategory(DrugCategoryID)
);

INSERT INTO Drug (DrugID, Name, GenericName, BrandName, DosageForm, Strength, DrugCategoryID)
VALUES
(1, 'Amoxicillin', 'Amoxicillin', 'Amoxil', 'Capsule', '500mg', 1),
(2, 'Paracetamol', 'Paracetamol', 'Tylenol', 'Tablet', '500mg', 2),
(3, 'Ibuprofen', 'Ibuprofen', 'Advil', 'Tablet', '200mg', 3);

SELECT * FROM Drug;

