## Criando Procedure `spDeleteStudent` 

CREATE OR ALTER   PROCEDURE [dbo].[spDeleteStudent] ( 
    @StudentId UNIQUEIDENTIFIER
)
AS</br>
        BEGIN TRANSACTION </br>
                DELETE FROM  [StudentCourse] </br>
            WHERE [StudentId] = @StudentId</br>
            </br>
        DELETE FROM [Student] </br>
        WHERE [Id] = @StudentId   </br>
    COMMIT</br>
GO

## Criando Procedure `spGetCoursesByCategory` 

CREATE OR ALTER PROCEDURE [spGetCoursesByCategory]
   ( @CategoryId UNIQUEIDENTIFIER ) </br>
AS</br>
    SELECT * FROM [Course] WHERE [CategoryId] = @CategoryId</br>
