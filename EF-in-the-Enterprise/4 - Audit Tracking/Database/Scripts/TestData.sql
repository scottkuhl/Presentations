-- Students
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Alexander', 'Carson', '9/1/2010', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Alexander INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Alonso', 'Meredith', '9/1/2012', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Alonso INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Anand', 'Arturo', '9/1/2013', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Anand INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Barzdukas', 'Gytis', '9/1/2012', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Barzdukas INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Li', 'Yan', '9/1/2012', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Li INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Justice', 'Peggy', '9/1/2011', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Justice INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Norman', 'Laura', '9/1/2013', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Norman INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Olivetto', 'Nino', '9/1/2005', 'Student', 'UnitTest', GETDATE()); DECLARE @Person_Olivetto INT = @@IDENTITY;

-- Instructors
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Abercrombie', 'Kim', '3/11/1995', 'Instructor', 'UnitTest', GETDATE()); DECLARE @Person_Abercrombie INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Fakhouri', 'Fadi', '7/6/2002', 'Instructor', 'UnitTest', GETDATE()); DECLARE @Person_Fakhouri INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Harui', 'Roger', '7/1/1998', 'Instructor', 'UnitTest', GETDATE()); DECLARE @Person_Harui INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Kapoor', 'Candace', '1/15/2001', 'Instructor', 'UnitTest', GETDATE()); DECLARE @Person_Kapoor INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator, CreatedBy, CreatedOn) VALUES ('Zheng', 'Roger', '2/12/2004', 'Instructor', 'UnitTest', GETDATE()); DECLARE @Person_Zheng INT = @@IDENTITY;

-- Departments
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID, CreatedBy, CreatedOn) VALUES ('English', 350000, '9/1/2007', @Person_Abercrombie, 'UnitTest', GETDATE()); DECLARE @Department_English INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID, CreatedBy, CreatedOn) VALUES ('Mathematics', 100000, '9/1/2007', @Person_Fakhouri, 'UnitTest', GETDATE()); DECLARE @Department_Mathematics INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID, CreatedBy, CreatedOn) VALUES ('Engineering', 350000, '9/1/2007', @Person_Harui, 'UnitTest', GETDATE()); DECLARE @Department_Engineering INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID, CreatedBy, CreatedOn) VALUES ('Economics', 100000, '9/1/2007', @Person_Kapoor, 'UnitTest', GETDATE()); DECLARE @Department_Economics INT = @@IDENTITY;

-- Courses
DECLARE @Course_Chemistry INT = 1050; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, 'Chemistry', 3, @Department_Engineering, 'UnitTest', GETDATE());
DECLARE @Course_Microeconomics INT = 4022; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Microeconomics, 'Microeconomics', 3, @Department_Economics, 'UnitTest', GETDATE()); 
DECLARE @Course_Macroeconomics INT = 4041; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Macroeconomics, 'Macroeconomics', 3, @Department_Economics, 'UnitTest', GETDATE()); 
DECLARE @Course_Calculus INT = 1045; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Calculus, 'Calculus', 4, @Department_Mathematics, 'UnitTest', GETDATE()); 
DECLARE @Course_Trigonometry INT = 3141; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Trigonometry, 'Trigonometry', 4, @Department_Mathematics, 'UnitTest', GETDATE()); 
DECLARE @Course_Composition INT = 2021; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Composition, 'Composition', 3, @Department_English, 'UnitTest', GETDATE()); 
DECLARE @Course_Literature INT = 2042; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID, CreatedBy, CreatedOn) VALUES (@Course_Literature, 'Literature', 4, @Department_English, 'UnitTest', GETDATE()); 

-- Course Instructors
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Composition, @Person_Abercrombie, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Literature, @Person_Abercrombie, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, @Person_Harui, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Trigonometry, @Person_Harui, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, @Person_Kapoor, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Microeconomics, @Person_Zheng, 'UnitTest', GETDATE());
INSERT INTO dbo.CourseInstructor(CourseID, PersonID, CreatedBy, CreatedOn) VALUES (@Course_Macroeconomics, @Person_Zheng, 'UnitTest', GETDATE());

-- Office Assignment
INSERT INTO dbo.OfficeAssignment (PersonID, Location, CreatedBy, CreatedOn) VALUES (@Person_Fakhouri, 'Smith 17', 'UnitTest', GETDATE());
INSERT INTO dbo.OfficeAssignment (PersonID, Location, CreatedBy, CreatedOn) VALUES (@Person_Harui, 'Gowan 27', 'UnitTest', GETDATE());
INSERT INTO dbo.OfficeAssignment (PersonID, Location, CreatedBy, CreatedOn) VALUES (@Person_Kapoor, 'Thompson 304', 'UnitTest', GETDATE());

-- Enrollments
DECLARE @Enrollment_Grade_A INT = 0;
DECLARE @Enrollment_Grade_B INT = 1;
DECLARE @Enrollment_Grade_C INT = 2;
DECLARE @Enrollment_Grade_D INT = 3;
DECLARE @Enrollment_Grade_F INT = 4;
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, @Person_Alexander, @Enrollment_Grade_A, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Microeconomics, @Person_Alexander, @Enrollment_Grade_C, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Macroeconomics, @Person_Alexander, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Trigonometry, @Person_Alonso, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Trigonometry, @Person_Alonso, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Composition, @Person_Alonso, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, @Person_Anand, NULL, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Microeconomics, @Person_Anand, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Chemistry, @Person_Barzdukas, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Composition, @Person_Li, @Enrollment_Grade_B, 'UnitTest', GETDATE());
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade, CreatedBy, CreatedOn) VALUES (@Course_Literature, @Person_Justice, @Enrollment_Grade_B, 'UnitTest', GETDATE());
