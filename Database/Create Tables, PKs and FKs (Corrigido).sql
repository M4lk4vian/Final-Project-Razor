-- Script gerado a partir do schema e dados reais da base de dados local (JD_JPA_JFT_FINAL, SQLEXPRESS)
-- em 2026-09-30, para corrigir o ficheiro "Create Tables, PKs and FKs.txt" que estava desatualizado
-- (nomes de colunas diferentes, tipos diferentes, stored procedures quebradas e sem uso).
-- Este ficheiro cria o schema exatamente como o código C# (Repository) espera, e insere os dados reais.

-- ============================================================
-- LIMPEZA (idempotente — permite correr o script mais que uma vez)
-- ============================================================
IF OBJECT_ID('dbo.Ingredients_Recipes', 'U') IS NOT NULL DROP TABLE dbo.Ingredients_Recipes;
IF OBJECT_ID('dbo.Ratings', 'U') IS NOT NULL DROP TABLE dbo.Ratings;
IF OBJECT_ID('dbo.Comments', 'U') IS NOT NULL DROP TABLE dbo.Comments;
IF OBJECT_ID('dbo.Favorites', 'U') IS NOT NULL DROP TABLE dbo.Favorites;
IF OBJECT_ID('dbo.Recipes', 'U') IS NOT NULL DROP TABLE dbo.Recipes;
IF OBJECT_ID('dbo.Ingredients', 'U') IS NOT NULL DROP TABLE dbo.Ingredients;
IF OBJECT_ID('dbo.Units', 'U') IS NOT NULL DROP TABLE dbo.Units;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID('dbo.Difficulties', 'U') IS NOT NULL DROP TABLE dbo.Difficulties;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories;
GO

-- ============================================================
-- SCHEMA (tabelas sem dependências primeiro)
-- ============================================================

CREATE TABLE Categories (
    categoryId   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    categoryName NVARCHAR(500) NULL
);

CREATE TABLE Difficulties (
    difficultyId   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    difficultyName NVARCHAR(50) NULL
);

CREATE TABLE Users (
    userId        INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    userName      NVARCHAR(50) NULL,
    password      NVARCHAR(50) NULL,
    blockedStatus BIT NULL,
    isAdmin       BIT NULL
);

CREATE TABLE Units (
    unitId   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    unitName NVARCHAR(50) NULL
);

CREATE TABLE Ingredients (
    ingredientId   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ingredientName NVARCHAR(20) NULL
);

-- Tabelas com dependências

CREATE TABLE Recipes (
    recipeId      INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    title         NVARCHAR(500) NOT NULL,
    prepMethod    NVARCHAR(1000) NOT NULL,
    blockedStatus BIT NOT NULL,
    prepTime      NVARCHAR(50) NOT NULL,
    id_category   INT NOT NULL FOREIGN KEY REFERENCES Categories(categoryId),
    id_difficulty INT NOT NULL FOREIGN KEY REFERENCES Difficulties(difficultyId)
);

CREATE TABLE Favorites (
    favoriteId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    id_user    INT NOT NULL FOREIGN KEY REFERENCES Users(userId),
    id_recipe  INT NOT NULL FOREIGN KEY REFERENCES Recipes(recipeId)
);

CREATE TABLE Comments (
    commentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    content   NVARCHAR(500) NULL,
    id_recipe INT NULL FOREIGN KEY REFERENCES Recipes(recipeId),
    id_user   INT NULL FOREIGN KEY REFERENCES Users(userId)
);

CREATE TABLE Ratings (
    ratingId  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    rating    FLOAT NULL,
    id_user   INT NULL FOREIGN KEY REFERENCES Users(userId),
    id_recipe INT NULL FOREIGN KEY REFERENCES Recipes(recipeId)
);

CREATE TABLE Ingredients_Recipes (
    ingredientRecipeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    id_recipe          INT NOT NULL FOREIGN KEY REFERENCES Recipes(recipeId),
    id_ingredient       INT NOT NULL FOREIGN KEY REFERENCES Ingredients(ingredientId),
    quantity           FLOAT NULL,
    id_unit            INT NULL FOREIGN KEY REFERENCES Units(unitId)
);
GO

-- ============================================================
-- DADOS REAIS (extraídos da BD local em 2026-09-30)
-- ============================================================

-- Categories
SET IDENTITY_INSERT Categories ON;
INSERT INTO Categories (categoryId, categoryName) VALUES
(1, N'Breakfast'),
(2, N'Lunch'),
(3, N'Afternoon Snack'),
(4, N'Dinner'),
(5, N'Dessert');
SET IDENTITY_INSERT Categories OFF;

-- Difficulties
SET IDENTITY_INSERT Difficulties ON;
INSERT INTO Difficulties (difficultyId, difficultyName) VALUES
(1, N'Easy'),
(2, N'Medium'),
(3, N'Hard'),
(4, N'Expert'),
(5, N'Hell''s Kitchen Level');
SET IDENTITY_INSERT Difficulties OFF;

-- Users
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (userId, userName, password, blockedStatus, isAdmin) VALUES
(1, N'Admin', N'123456', 0, 1),
(2, N'User200', N'123456', 0, 0),
(3, N'User3', N'123456', 0, 0),
(4, N'User4', N'123456', 0, 0),
(9, N'User5', N'123456', 0, 0),
(10, N'User6', N'123456', 0, 1),
(11, N'António', N'123456', 0, 0),
(12, N'Mónica Alves', N'123456', 0, 0),
(13, N'User201', N'123456', 0, 0);
SET IDENTITY_INSERT Users OFF;

-- Units
SET IDENTITY_INSERT Units ON;
INSERT INTO Units (unitId, unitName) VALUES
(1, N'Unit'),
(2, N'Tablespoon'),
(3, N'cloves'),
(4, N'Grams'),
(5, N'Kilograms'),
(6, N'Teaspoon'),
(7, N'Cup'),
(8, N'ml'),
(9, N'Chips'),
(10, N'Adequate Amount');
SET IDENTITY_INSERT Units OFF;

-- Ingredients
SET IDENTITY_INSERT Ingredients ON;
INSERT INTO Ingredients (ingredientId, ingredientName) VALUES
(22, N'Brown Sugar'),
(23, N'Butter'),
(27, N'caramel sauce'),
(7, N'chicken thighs'),
(28, N'chopped pecans'),
(17, N'cocoa powder'),
(13, N'Coriander'),
(15, N'Dark Chocolate'),
(1, N'Egg'),
(24, N'Flour'),
(4, N'garlic'),
(5, N'garlic crushed'),
(20, N'grated chocolate'),
(6, N'grated ginger'),
(12, N'Greek Yougurt'),
(14, N'Ground Almonds'),
(26, N'Lemon'),
(10, N'medium spice paste'),
(3, N'onion'),
(25, N'Pink Lady Apples'),
(29, N'pomegranate seeds'),
(21, N'Strawberry'),
(16, N'sugar'),
(2, N'sunflower oil'),
(18, N'thickened cream'),
(11, N'tomatoes'),
(19, N'whipped cream');
SET IDENTITY_INSERT Ingredients OFF;

-- Recipes
SET IDENTITY_INSERT Recipes ON;
INSERT INTO Recipes (recipeId, title, prepMethod, blockedStatus, prepTime, id_category, id_difficulty) VALUES
(1, N'Hard Boiled Egg', N'Place eggs in a medium pot and cover with cold water by 1 inch. Bring to a boil, then cover the pot and turn off the heat. Let the eggs cook, covered, for 9 to 12 minutes, depending on your desired done-ness (see photo).
Transfer the eggs to a bowl of ice water and chill for 14 minutes. This makes the eggs easier to peel. Peel and enjoy!', 0, N'35 minutes', 1, 1),
(2, N'Chicken Curry', N'Heat the oil in a flameproof casserole dish or large frying pan over a medium heat. Add the onion and a generous pinch of salt and fry for 8-10 mins, or until the onion has turned golden brown and sticky. Add the garlic and ginger, cooking for a further minute.
Chop the chicken into chunky 3cm pieces, add to the pan and fry for 5 mins before stirring through the spice paste and tomatoes, along with 250ml water. Bring to the boil, lower to a simmer and cook on a gentle heat uncovered for 25-30 mins or until rich and slightly reduced. Stir though the yogurt, coriander and ground almonds, season and serve with warm naan or fluffy basmati rice.', 0, N'45 minutes', 2, 1),
(3, N'Secret Recipe', N'Well its a secret', 0, N'20 minutes', 1, 1);
SET IDENTITY_INSERT Recipes OFF;

-- Favorites
SET IDENTITY_INSERT Favorites ON;
INSERT INTO Favorites (favoriteId, id_user, id_recipe) VALUES
(1, 2, 1);
SET IDENTITY_INSERT Favorites OFF;

-- Comments
SET IDENTITY_INSERT Comments ON;
INSERT INTO Comments (commentId, content, id_recipe, id_user) VALUES
(1, N'Very good', 1, 2),
(6, N'EVERYTHING SUCKS', 2, 2),
(7, N'Very good', 1, 2),
(8, N'Very simple and easy to make', 1, 3);
SET IDENTITY_INSERT Comments OFF;

-- Ratings
SET IDENTITY_INSERT Ratings ON;
INSERT INTO Ratings (ratingId, rating, id_user, id_recipe) VALUES
(7, 0.0, 3, 1);
SET IDENTITY_INSERT Ratings OFF;

-- Ingredients_Recipes
SET IDENTITY_INSERT Ingredients_Recipes ON;
INSERT INTO Ingredients_Recipes (ingredientRecipeId, id_recipe, id_ingredient, quantity, id_unit) VALUES
(1, 1, 1, 1.0, 1),
(2, 2, 2, 2.0, 2),
(3, 2, 3, 1.0, 1),
(4, 2, 5, 2.0, 3),
(5, 2, 6, 1.0, 6),
(6, 2, 7, 6.0, 1),
(7, 2, 10, 3.0, 2),
(8, 2, 11, 400.0, 4),
(9, 2, 12, 100.0, 4),
(10, 2, 13, 1.0, 2),
(11, 2, 14, 50.0, 4),
(12, 3, 22, 2000.0, 5),
(13, 3, 7, 2.0, 4);
SET IDENTITY_INSERT Ingredients_Recipes OFF;
GO

-- ============================================================
-- Reajustar os contadores de identity para o próximo valor livre
-- (garante que novos registos criados pela app não colidem com os IDs importados)
-- ============================================================
DBCC CHECKIDENT ('Categories', RESEED);
DBCC CHECKIDENT ('Difficulties', RESEED);
DBCC CHECKIDENT ('Users', RESEED);
DBCC CHECKIDENT ('Units', RESEED);
DBCC CHECKIDENT ('Ingredients', RESEED);
DBCC CHECKIDENT ('Recipes', RESEED);
DBCC CHECKIDENT ('Favorites', RESEED);
DBCC CHECKIDENT ('Comments', RESEED);
DBCC CHECKIDENT ('Ratings', RESEED);
DBCC CHECKIDENT ('Ingredients_Recipes', RESEED);
GO
