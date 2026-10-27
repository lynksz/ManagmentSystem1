-- 1. Таблиця викладачів (Teachers)
CREATE TABLE IF NOT EXISTS Teachers (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL
);

-- 2. Таблиця курсів (Courses)
CREATE TABLE IF NOT EXISTS Courses (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name VARCHAR(150) NOT NULL,
    Description TEXT,
    Semester VARCHAR(50) NOT NULL,
    TeacherID INTEGER,
    FOREIGN KEY (TeacherID) REFERENCES Teachers(ID) ON DELETE SET NULL
);

-- 3. Таблиця пропозицій щодо курсів (Proposals)
CREATE TABLE IF NOT EXISTS Proposals (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    TeacherID INTEGER NOT NULL,
    CourseName VARCHAR(150) NOT NULL,
    ProposalType VARCHAR(20) CHECK(ProposalType IN ('Create', 'Delete')) NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Pending',
    FOREIGN KEY (TeacherID) REFERENCES Teachers(ID) ON DELETE CASCADE
);

-- Тестові дані: Викладачі
INSERT INTO Teachers (Name, Email, PasswordHash) VALUES
('Олександр Шевченко', 'shevchenko@univ.edu.ua', 'e10adc3949ba59abbe56e057f20f883e'),
('Олена Бондаренко', 'bondarenko@univ.edu.ua', 'c33367701511b4f6020ec61ded352059'),
('Ігор Кравченко', 'kravchenko@univ.edu.ua', '5f4dcc3b5aa765d61d8327deb882cf99');

-- Тестові дані: Курси
INSERT INTO Courses (Name, Description, Semester, TeacherID) VALUES
('Об об''єктно-орієнтоване програмування', 'Базовий курс C# та .NET', 'Осінь 2024', 1),
('Бази даних та SQL', 'Проєктування реляційних баз даних', 'Осінь 2024', 2),
('Кросплатформна розробка (.NET MAUI)', 'Розробка мобільних застосунків', 'Весна 2025', 1);

-- Тестові дані: Пропозиції
INSERT INTO Proposals (TeacherID, CourseName, ProposalType, Status) VALUES
(1, 'Архитектура хмарних систем', 'Create', 'Pending'),
(2, 'Застарілі технології розробки', 'Delete', 'Approved'),
(3, 'Вступ до штучного інтелекту', 'Create', 'Pending');