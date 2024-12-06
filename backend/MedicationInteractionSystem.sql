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

CREATE TABLE SeverityLevel (
    SeverityLevelID INT PRIMARY KEY,
    LevelName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(MAX)
);

CREATE TABLE ClinicalRecommendation (
    ClinicalRecommendationID INT PRIMARY KEY,
    RecommendationText NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Interaction (
    InteractionID INT PRIMARY KEY,
    DrugID1 INT FOREIGN KEY REFERENCES Drug(DrugID),
    DrugID2 INT FOREIGN KEY REFERENCES Drug(DrugID),
    SeverityLevelID INT FOREIGN KEY REFERENCES SeverityLevel(SeverityLevelID),
    ClinicalRecommendationID INT FOREIGN KEY REFERENCES ClinicalRecommendation(ClinicalRecommendationID),
    Description NVARCHAR(MAX)
);

CREATE TABLE UserAccount (
    UserAccountID INT PRIMARY KEY,
    Username NVARCHAR(255) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    UserType NVARCHAR(50) NOT NULL,
    LastLogin DATETIME
);

CREATE TABLE PatientProfile (
    PatientID INT PRIMARY KEY,
    UserAccountID INT FOREIGN KEY REFERENCES UserAccount(UserAccountID),
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    DateOfBirth DATE,
    PhoneNumbers NVARCHAR(MAX), -- Multivalued data can be separated by commas
    Emails NVARCHAR(MAX)
);

CREATE TABLE HealthcareProvider (
    ProviderID INT PRIMARY KEY,
    UserAccountID INT FOREIGN KEY REFERENCES UserAccount(UserAccountID),
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Specialty NVARCHAR(255)
);

CREATE TABLE MedicationLog (
    MedicationLogID INT PRIMARY KEY,
    PatientID INT FOREIGN KEY REFERENCES PatientProfile(PatientID),
    DrugID INT FOREIGN KEY REFERENCES Drug(DrugID),
    Dosage NVARCHAR(50),
    StartDate DATE,
    EndDate DATE,
    Notes NVARCHAR(MAX)
);

CREATE TABLE SearchQuery (
    QueryID INT PRIMARY KEY,
    UserAccountID INT FOREIGN KEY REFERENCES UserAccount(UserAccountID),
    SearchTerms NVARCHAR(MAX), -- Multivalued data can be separated by commas
    SearchDate DATETIME
);

CREATE TABLE InteractionReport (
    ReportID INT PRIMARY KEY,
    InteractionID INT FOREIGN KEY REFERENCES Interaction(InteractionID),
    UserAccountID INT FOREIGN KEY REFERENCES UserAccount(UserAccountID),
    DateGenerated DATETIME NOT NULL,
    Content NVARCHAR(MAX)
);

CREATE TABLE SystemAlert (
    AlertID INT PRIMARY KEY,
    InteractionID INT FOREIGN KEY REFERENCES Interaction(InteractionID),
    DateCreated DATETIME NOT NULL,
    Message NVARCHAR(MAX)
);

CREATE TABLE AdministratorSetting (
    SettingID INT PRIMARY KEY,
    SettingName NVARCHAR(255) NOT NULL,
    SettingValue NVARCHAR(255),
    UpdatedBy INT FOREIGN KEY REFERENCES UserAccount(UserAccountID)
);

CREATE TABLE Dataset (
    DatasetID INT PRIMARY KEY,
    SourceName NVARCHAR(255) NOT NULL,
    Version NVARCHAR(50),
    DateUpdated DATETIME,
    UpdatedBy INT FOREIGN KEY REFERENCES UserAccount(UserAccountID)
);

INSERT INTO SeverityLevel (SeverityLevelID, LevelName, Description)
VALUES
(1, 'Mild', 'Low severity interaction'),
(2, 'Moderate', 'Requires attention but not critical'),
(3, 'Severe', 'Critical interaction that may cause harm');

INSERT INTO ClinicalRecommendation (ClinicalRecommendationID, RecommendationText)
VALUES
(1, 'Reduce dosage if both drugs are used together.'),
(2, 'Avoid using these drugs together.'),
(3, 'Monitor patient closely for adverse effects.');


INSERT INTO Interaction (InteractionID, DrugID1, DrugID2, SeverityLevelID, ClinicalRecommendationID, Description)
VALUES
(1, 1, 2, 2, 1, 'Moderate interaction between Amoxicillin and Paracetamol.'),
(2, 2, 3, 3, 2, 'Severe interaction between Paracetamol and Ibuprofen.'),
(3, 1, 3, 1, 3, 'Mild interaction between Amoxicillin and Ibuprofen.');

SELECT d.Name AS DrugName, dc.CategoryName AS Category
FROM Drug d
JOIN DrugCategory dc ON d.DrugCategoryID = dc.DrugCategoryID;

SELECT
    i.InteractionID,
    d1.Name AS Drug1,
    d2.Name AS Drug2,
    s.LevelName AS Severity,
    c.RecommendationText AS Recommendation
FROM Interaction i
JOIN Drug d1 ON i.DrugID1 = d1.DrugID
JOIN Drug d2 ON i.DrugID2 = d2.DrugID
JOIN SeverityLevel s ON i.SeverityLevelID = s.SeverityLevelID
JOIN ClinicalRecommendation c ON i.ClinicalRecommendationID = c.ClinicalRecommendationID;

SELECT
    m.MedicationLogID,
    CONCAT(p.FirstName, ' ', p.LastName) AS PatientName,
    d.Name AS DrugName,
    m.Dosage,
    m.StartDate,
    m.EndDate
FROM MedicationLog m
JOIN PatientProfile p ON m.PatientID = p.PatientID
JOIN Drug d ON m.DrugID = d.DrugID;













