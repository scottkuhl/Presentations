-- Clean up order should be first in, last out.

DELETE FROM dbo.Enrollment; DBCC CHECKIDENT('dbo.Enrollment', RESEED, 0);
DELETE FROM dbo.OfficeAssignment;
DELETE FROM dbo.CourseInstructor;
DELETE FROM dbo.Course;
DELETE FROM dbo.Department; DBCC CHECKIDENT('dbo.Department', RESEED, 0);
DELETE FROM dbo.Person; DBCC CHECKIDENT('dbo.Person', RESEED, 0);