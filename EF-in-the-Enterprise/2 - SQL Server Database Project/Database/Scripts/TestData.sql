-- Students
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Alexander', 'Carson', '9/1/2010', 'Student'); DECLARE @Person_Alexander INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Alonso', 'Meredith', '9/1/2012', 'Student'); DECLARE @Person_Alonso INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Anand', 'Arturo', '9/1/2013', 'Student'); DECLARE @Person_Anand INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Barzdukas', 'Gytis', '9/1/2012', 'Student'); DECLARE @Person_Barzdukas INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Li', 'Yan', '9/1/2012', 'Student'); DECLARE @Person_Li INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Justice', 'Peggy', '9/1/2011', 'Student'); DECLARE @Person_Justice INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Norman', 'Laura', '9/1/2013', 'Student'); DECLARE @Person_Norman INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, EnrollmentDate, Discriminator) VALUES ('Olivetto', 'Nino', '9/1/2005', 'Student'); DECLARE @Person_Olivetto INT = @@IDENTITY;

-- Instructors
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator) VALUES ('Abercrombie', 'Kim', '3/11/1995', 'Instructor'); DECLARE @Person_Abercrombie INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator) VALUES ('Fakhouri', 'Fadi', '7/6/2002', 'Instructor'); DECLARE @Person_Fakhouri INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator) VALUES ('Harui', 'Roger', '7/1/1998', 'Instructor'); DECLARE @Person_Harui INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator) VALUES ('Kapoor', 'Candace', '1/15/2001', 'Instructor'); DECLARE @Person_Kapoor INT = @@IDENTITY;
INSERT INTO dbo.Person (LastName, FirstName, HireDate, Discriminator) VALUES ('Zheng', 'Roger', '2/12/2004', 'Instructor'); DECLARE @Person_Zheng INT = @@IDENTITY;

-- Departments
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID) VALUES ('English', 350000, '9/1/2007', @Person_Abercrombie); DECLARE @Department_English INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID) VALUES ('Mathematics', 100000, '9/1/2007', @Person_Fakhouri); DECLARE @Department_Mathematics INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID) VALUES ('Engineering', 350000, '9/1/2007', @Person_Harui); DECLARE @Department_Engineering INT = @@IDENTITY;
INSERT INTO dbo.Department (Name, Budget, StartDate, PersonID) VALUES ('Economics', 100000, '9/1/2007', @Person_Kapoor); DECLARE @Department_Economics INT = @@IDENTITY;

-- Courses
DECLARE @Course_Chemistry INT = 1050; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Chemistry, 'Chemistry', 3, @Department_Engineering);
DECLARE @Course_Microeconomics INT = 4022; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Microeconomics, 'Microeconomics', 3, @Department_Economics); 
DECLARE @Course_Macroeconomics INT = 4041; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Macroeconomics, 'Macroeconomics', 3, @Department_Economics); 
DECLARE @Course_Calculus INT = 1045; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Calculus, 'Calculus', 4, @Department_Mathematics); 
DECLARE @Course_Trigonometry INT = 3141; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Trigonometry, 'Trigonometry', 4, @Department_Mathematics); 
DECLARE @Course_Composition INT = 2021; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Composition, 'Composition', 3, @Department_English); 
DECLARE @Course_Literature INT = 2042; INSERT INTO dbo.Course (CourseID, Title, Credits, DepartmentID) VALUES (@Course_Literature, 'Literature', 4, @Department_English); 

-- Course Instructors
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Composition, @Person_Abercrombie);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Literature, @Person_Abercrombie);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Chemistry, @Person_Harui);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Trigonometry, @Person_Harui);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Chemistry, @Person_Kapoor);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Microeconomics, @Person_Zheng);
INSERT INTO dbo.CourseInstructor(CourseID, PersonID) VALUES (@Course_Macroeconomics, @Person_Zheng);

-- Office Assignment
INSERT INTO dbo.OfficeAssignment (PersonID, Location) VALUES (@Person_Fakhouri, 'Smith 17');
INSERT INTO dbo.OfficeAssignment (PersonID, Location) VALUES (@Person_Harui, 'Gowan 27');
INSERT INTO dbo.OfficeAssignment (PersonID, Location) VALUES (@Person_Kapoor, 'Thompson 304');

-- Enrollments
DECLARE @Enrollment_Grade_A INT = 0;
DECLARE @Enrollment_Grade_B INT = 1;
DECLARE @Enrollment_Grade_C INT = 2;
DECLARE @Enrollment_Grade_D INT = 3;
DECLARE @Enrollment_Grade_F INT = 4;
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Chemistry, @Person_Alexander, @Enrollment_Grade_A);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Microeconomics, @Person_Alexander, @Enrollment_Grade_C);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Macroeconomics, @Person_Alexander, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Trigonometry, @Person_Alonso, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Trigonometry, @Person_Alonso, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Composition, @Person_Alonso, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Chemistry, @Person_Anand, NULL);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Microeconomics, @Person_Anand, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Chemistry, @Person_Barzdukas, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Composition, @Person_Li, @Enrollment_Grade_B);
INSERT INTO dbo.Enrollment (CourseID, PersonID, Grade) VALUES (@Course_Literature, @Person_Justice, @Enrollment_Grade_B);
