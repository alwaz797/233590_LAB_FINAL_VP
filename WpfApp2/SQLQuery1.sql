CREATE DATABASE QuizAppDB;
USE QuizAppDB;

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Level VARCHAR(10) NOT NULL
);

CREATE TABLE Questions (
    QuestionID INT PRIMARY KEY IDENTITY(1,1),
    QuestionText VARCHAR(255) NOT NULL,
    Difficulty VARCHAR(10) NOT NULL
);

CREATE TABLE Options (
    OptionID INT PRIMARY KEY IDENTITY(1,1),
    QuestionID INT,
    OptionText VARCHAR(100) NOT NULL,
    IsCorrect BIT NOT NULL,
    FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
);

CREATE TABLE Results (
    ResultID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    Score INT NOT NULL,
    TotalQuestions INT NOT NULL,
    DateTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

INSERT INTO Users (Username, Password, Level) VALUES 
('john_doe', 'password123', 'Easy'),
('alice_smith', 'password456', 'Hard');

INSERT INTO Questions (QuestionText, Difficulty) VALUES
('What is 2 + 2?', 'Easy'),
('What is the capital of France?', 'Easy'),
('What color is the sky?', 'Easy'),
('How many continents are there?', 'Easy'),
('What is 5 + 3?', 'Easy'),
('What is 15 * 8?', 'Hard'),
('What is the square root of 256?', 'Hard'),
('Who developed the theory of relativity?', 'Hard'),
('What is the atomic number of gold?', 'Hard'),
('What is the capital of Japan?', 'Hard');

INSERT INTO Options (QuestionID, OptionText, IsCorrect) VALUES
(1, '3', 0), (1, '4', 1), (1, '5', 0), (1, '6', 0),
(2, 'Berlin', 0), (2, 'Madrid', 0), (2, 'Paris', 1), (2, 'London', 0),
(3, 'Blue', 1), (3, 'Red', 0), (3, 'Green', 0), (3, 'Yellow', 0),
(4, '6', 0), (4, '7', 0), (4, '8', 1), (4, '9', 0),
(5, '6', 0), (5, '7', 0), (5, '8', 1), (5, '9', 0),
(6, '100', 0), (6, '120', 1), (6, '110', 0), (6, '130', 0),
(7, '10', 0), (7, '12', 0), (7, '14', 0), (7, '16', 1),
(8, 'Isaac Newton', 0), (8, 'Albert Einstein', 1), (8, 'Nikola Tesla', 0), (8, 'Marie Curie', 0),
(9, '79', 1), (9, '80', 0), (9, '81', 0), (9, '82', 0),
(10, 'Tokyo', 1), (10, 'Seoul', 0), (10, 'Beijing', 0), (10, 'Hanoi', 0);

INSERT INTO Results (UserID, Score, TotalQuestions) VALUES
(1, 40, 5);
