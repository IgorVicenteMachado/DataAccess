##Criando Procedure `spDeleteStudent` 

CREATE OR ALTER   PROCEDURE [dbo].[spDeleteStudent] ( </br>
    @StudentId UNIQUEIDENTIFIER</br>
)</br>
AS</br>
    BEGIN TRANSACTION</br>
        DELETE FROM </br>
            [StudentCourse] </br>
        WHERE </br>
            [StudentId] = @StudentId</br>
            </br>
        DELETE FROM  </br>
            [Student] </br>
        WHERE </br>
            [Id] = @StudentId   </br>
    COMMIT</br>
GO

##Criando Procedure `spGetCoursesByCategory` 

CREATE OR ALTER PROCEDURE [spGetCoursesByCategory] </br>
    @CategoryId UNIQUEIDENTIFIER</br>
AS</br>
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId</br>