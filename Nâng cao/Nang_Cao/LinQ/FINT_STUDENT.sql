CREATE DATABASE FINT_STUDENT;
GO

USE FINT_STUDENT;
GO

CREATE TABLE students (
	MSSV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50),
    DiemTB FLOAT
)

INSERT INTO students VALUES 
('SV001', N'Nguyễn Văn A', 7.5),
('SV002', N'Trần Thị B', 8.0),
('SV003', N'Lê Văn C', 6.8);

select *from students;