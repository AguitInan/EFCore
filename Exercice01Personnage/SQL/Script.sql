CREATE TABLE Personnage
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Pseudo VARCHAR(100),
    PointsDeVie INT,
    Armure INT,
    Degats INT,
    DateCreation DATETIME,
    NombrePersonneTues INT
);
