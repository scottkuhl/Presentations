//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets645D53C60AB1A6DCC27A03FF4703B368EB0DF3BB225861C1E00555EA1C88A0F5))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// The type contains views for EntitySets and AssociationSets that were generated at design time.
    /// </Summary>
    public sealed class ViewsForBaseEntitySets645D53C60AB1A6DCC27A03FF4703B368EB0DF3BB225861C1E00555EA1C88A0F5 : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// The constructor stores the views for the extents and also the hash values generated based on the metadata and mapping closure and views.
        /// </Summary>
        public ViewsForBaseEntitySets645D53C60AB1A6DCC27A03FF4703B368EB0DF3BB225861C1E00555EA1C88A0F5()
        {
            this.EdmEntityContainerName = "SchoolContext";
            this.StoreEntityContainerName = "CodeFirstDatabase";
            this.HashOverMappingClosure = "62d52ade10df9fa794aa896cbdab8a45961e0dfe136d4d5cf36b32583613d2c5";
            this.HashOverAllExtentViews = "5a90abf40dac8cb39a3b094cf47ca9269ceaff4ddd4d219fe8a76fa3897688c3";
            this.ViewCount = 14;
        }
        
        /// <Summary>
        /// The method returns the view for the index given.
        /// </Summary>
        protected override System.Collections.Generic.KeyValuePair<string, string> GetViewAt(int index)
        {
            if ((index == 0))
            {
                return GetView0();
            }
            if ((index == 1))
            {
                return GetView1();
            }
            if ((index == 2))
            {
                return GetView2();
            }
            if ((index == 3))
            {
                return GetView3();
            }
            if ((index == 4))
            {
                return GetView4();
            }
            if ((index == 5))
            {
                return GetView5();
            }
            if ((index == 6))
            {
                return GetView6();
            }
            if ((index == 7))
            {
                return GetView7();
            }
            if ((index == 8))
            {
                return GetView8();
            }
            if ((index == 9))
            {
                return GetView9();
            }
            if ((index == 10))
            {
                return GetView10();
            }
            if ((index == 11))
            {
                return GetView11();
            }
            if ((index == 12))
            {
                return GetView12();
            }
            if ((index == 13))
            {
                return GetView13();
            }
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.Course
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.Course", @"
    SELECT VALUE -- Constructing Course
        [CodeFirstDatabaseSchema.Course](T1.Course_CourseID, T1.Course_Title, T1.Course_Credits, T1.Course_DepartmentID, T1.Course_CreatedBy, T1.Course_CreatedOn, T1.Course_UpdatedBy, T1.Course_UpdatedOn)
    FROM (
        SELECT 
            T.CourseID AS Course_CourseID, 
            T.Title AS Course_Title, 
            T.Credits AS Course_Credits, 
            T.DepartmentID AS Course_DepartmentID, 
            T.CreatedBy AS Course_CreatedBy, 
            T.CreatedOn AS Course_CreatedOn, 
            T.UpdatedBy AS Course_UpdatedBy, 
            T.UpdatedOn AS Course_UpdatedOn, 
            True AS _from0
        FROM SchoolContext.Courses AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.Department
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.Department", @"
    SELECT VALUE -- Constructing Department
        [CodeFirstDatabaseSchema.Department](T1.Department_DepartmentID, T1.Department_Name, T1.Department_Budget, T1.Department_StartDate, T1.Department_PersonID, T1.Department_RowVersion, T1.Department_CreatedBy, T1.Department_CreatedOn, T1.Department_UpdatedBy, T1.Department_UpdatedOn)
    FROM (
        SELECT 
            T.DepartmentID AS Department_DepartmentID, 
            T.Name AS Department_Name, 
            T.Budget AS Department_Budget, 
            T.StartDate AS Department_StartDate, 
            T.PersonID AS Department_PersonID, 
            T.RowVersion AS Department_RowVersion, 
            T.CreatedBy AS Department_CreatedBy, 
            T.CreatedOn AS Department_CreatedOn, 
            T.UpdatedBy AS Department_UpdatedBy, 
            T.UpdatedOn AS Department_UpdatedOn, 
            True AS _from0
        FROM SchoolContext.Departments AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.Person
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.Person", "\r\n    SELECT VALUE -- Constructing Person\r\n        [CodeFirstDatabaseSchema.Perso" +
                    "n](T2.Person_PersonID, T2.Person_LastName, T2.Person_FirstName, T2.Person_UserNa" +
                    "me, T2.Person_Email, T2.Person_CreatedBy, T2.Person_CreatedOn, T2.Person_Updated" +
                    "By, T2.Person_UpdatedOn, T2.Person_HireDate, T2.Person_EnrollmentDate, T2.Person" +
                    "_Discriminator)\r\n    FROM (\r\n        SELECT -- Constructing Discriminator\r\n     " +
                    "       T1.Person_PersonID, \r\n            T1.Person_LastName, \r\n            T1.Pe" +
                    "rson_FirstName, \r\n            T1.Person_UserName, \r\n            T1.Person_Email," +
                    " \r\n            T1.Person_CreatedBy, \r\n            T1.Person_CreatedOn, \r\n       " +
                    "     T1.Person_UpdatedBy, \r\n            T1.Person_UpdatedOn, \r\n            T1.Pe" +
                    "rson_HireDate, \r\n            T1.Person_EnrollmentDate, \r\n            CASE\r\n     " +
                    "           WHEN T1._from1 THEN N\'Instructor\'\r\n                ELSE N\'Student\'\r\n " +
                    "           END AS Person_Discriminator\r\n        FROM (\r\n            SELECT \r\n   " +
                    "             T.PersonID AS Person_PersonID, \r\n                T.LastName AS Pers" +
                    "on_LastName, \r\n                T.FirstMidName AS Person_FirstName, \r\n           " +
                    "     T.UserName AS Person_UserName, \r\n                T.Email AS Person_Email, \r" +
                    "\n                T.CreatedBy AS Person_CreatedBy, \r\n                T.CreatedOn " +
                    "AS Person_CreatedOn, \r\n                T.UpdatedBy AS Person_UpdatedBy, \r\n      " +
                    "          T.UpdatedOn AS Person_UpdatedOn, \r\n                TREAT(T AS [Contoso" +
                    "University.DAL.Instructor]).HireDate AS Person_HireDate, \r\n                TREAT" +
                    "(T AS [ContosoUniversity.DAL.Student]).EnrollmentDate AS Person_EnrollmentDate, " +
                    "\r\n                True AS _from0, \r\n                CASE WHEN T IS OF (ONLY [Con" +
                    "tosoUniversity.DAL.Instructor]) THEN True ELSE False END AS _from1, \r\n          " +
                    "      CASE WHEN T IS OF (ONLY [ContosoUniversity.DAL.Student]) THEN True ELSE Fa" +
                    "lse END AS _from2\r\n            FROM SchoolContext.People AS T\r\n        ) AS T1\r\n" +
                    "    ) AS T2");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.OfficeAssignment
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.OfficeAssignment", @"
    SELECT VALUE -- Constructing OfficeAssignment
        [CodeFirstDatabaseSchema.OfficeAssignment](T1.OfficeAssignment_PersonID, T1.OfficeAssignment_Location, T1.OfficeAssignment_CreatedBy, T1.OfficeAssignment_CreatedOn, T1.OfficeAssignment_UpdatedBy, T1.OfficeAssignment_UpdatedOn)
    FROM (
        SELECT 
            T.PersonID AS OfficeAssignment_PersonID, 
            T.Location AS OfficeAssignment_Location, 
            T.CreatedBy AS OfficeAssignment_CreatedBy, 
            T.CreatedOn AS OfficeAssignment_CreatedOn, 
            T.UpdatedBy AS OfficeAssignment_UpdatedBy, 
            T.UpdatedOn AS OfficeAssignment_UpdatedOn, 
            True AS _from0
        FROM SchoolContext.OfficeAssignments AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.Enrollment
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView4()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.Enrollment", @"
    SELECT VALUE -- Constructing Enrollment
        [CodeFirstDatabaseSchema.Enrollment](T1.Enrollment_EnrollmentID, T1.Enrollment_CourseID, T1.Enrollment_PersonID, T1.Enrollment_Grade, T1.Enrollment_CreatedBy, T1.Enrollment_CreatedOn, T1.Enrollment_UpdatedBy, T1.Enrollment_UpdatedOn)
    FROM (
        SELECT 
            T.EnrollmentID AS Enrollment_EnrollmentID, 
            T.CourseID AS Enrollment_CourseID, 
            T.PersonID AS Enrollment_PersonID, 
            CAST(T.Grade AS [Edm.Int32]) AS Enrollment_Grade, 
            T.CreatedBy AS Enrollment_CreatedBy, 
            T.CreatedOn AS Enrollment_CreatedOn, 
            T.UpdatedBy AS Enrollment_UpdatedBy, 
            T.UpdatedOn AS Enrollment_UpdatedOn, 
            True AS _from0
        FROM SchoolContext.Enrollments AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.CourseInstructor
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView5()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.CourseInstructor", @"
    SELECT VALUE -- Constructing CourseInstructor
        [CodeFirstDatabaseSchema.CourseInstructor](T1.CourseInstructor_CourseID, T1.CourseInstructor_PersonID)
    FROM (
        SELECT 
            Key(T.Course_Instructors_Source).CourseID AS CourseInstructor_CourseID, 
            Key(T.Course_Instructors_Target).PersonID AS CourseInstructor_PersonID, 
            True AS _from0
        FROM SchoolContext.Course_Instructors AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.Courses
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView6()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.Courses", @"
    SELECT VALUE -- Constructing Courses
        [ContosoUniversity.DAL.Course](T1.Course_CourseID, T1.Course_Title, T1.Course_Credits, T1.Course_DepartmentID, T1.Course_CreatedBy, T1.Course_CreatedOn, T1.Course_UpdatedBy, T1.Course_UpdatedOn)
    FROM (
        SELECT 
            T.CourseID AS Course_CourseID, 
            T.Title AS Course_Title, 
            T.Credits AS Course_Credits, 
            T.DepartmentID AS Course_DepartmentID, 
            T.CreatedBy AS Course_CreatedBy, 
            T.CreatedOn AS Course_CreatedOn, 
            T.UpdatedBy AS Course_UpdatedBy, 
            T.UpdatedOn AS Course_UpdatedOn, 
            True AS _from0
        FROM CodeFirstDatabase.Course AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.Departments
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView7()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.Departments", @"
    SELECT VALUE -- Constructing Departments
        [ContosoUniversity.DAL.Department](T1.Department_DepartmentID, T1.Department_Name, T1.Department_Budget, T1.Department_StartDate, T1.Department_PersonID, T1.Department_RowVersion, T1.Department_CreatedBy, T1.Department_CreatedOn, T1.Department_UpdatedBy, T1.Department_UpdatedOn)
    FROM (
        SELECT 
            T.DepartmentID AS Department_DepartmentID, 
            T.Name AS Department_Name, 
            T.Budget AS Department_Budget, 
            T.StartDate AS Department_StartDate, 
            T.PersonID AS Department_PersonID, 
            T.RowVersion AS Department_RowVersion, 
            T.CreatedBy AS Department_CreatedBy, 
            T.CreatedOn AS Department_CreatedOn, 
            T.UpdatedBy AS Department_UpdatedBy, 
            T.UpdatedOn AS Department_UpdatedOn, 
            True AS _from0
        FROM CodeFirstDatabase.Department AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.People
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView8()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.People", @"
    SELECT VALUE -- Constructing People
        CASE
            WHEN T1._from1 THEN [ContosoUniversity.DAL.Instructor](T1.Person_PersonID, T1.Person_LastName, T1.Person_FirstMidName, T1.Person_UserName, T1.Person_Email, T1.Person_CreatedBy, T1.Person_CreatedOn, T1.Person_UpdatedBy, T1.Person_UpdatedOn, T1.Instructor_HireDate)
            ELSE [ContosoUniversity.DAL.Student](T1.Person_PersonID, T1.Person_LastName, T1.Person_FirstMidName, T1.Person_UserName, T1.Person_Email, T1.Person_CreatedBy, T1.Person_CreatedOn, T1.Person_UpdatedBy, T1.Person_UpdatedOn, T1.Student_EnrollmentDate)
        END
    FROM (
        SELECT 
            T.PersonID AS Person_PersonID, 
            T.LastName AS Person_LastName, 
            T.FirstName AS Person_FirstMidName, 
            T.UserName AS Person_UserName, 
            T.Email AS Person_Email, 
            T.CreatedBy AS Person_CreatedBy, 
            T.CreatedOn AS Person_CreatedOn, 
            T.UpdatedBy AS Person_UpdatedBy, 
            T.UpdatedOn AS Person_UpdatedOn, 
            T.HireDate AS Instructor_HireDate, 
            T.EnrollmentDate AS Student_EnrollmentDate, 
            True AS _from0, 
            CASE WHEN T.Discriminator = N'Instructor' THEN True ELSE False END AS _from1, 
            CASE WHEN T.Discriminator = N'Student' THEN True ELSE False END AS _from2
        FROM CodeFirstDatabase.Person AS T
        WHERE T.Discriminator IN {N'Instructor', N'Student'}
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.OfficeAssignments
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView9()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.OfficeAssignments", @"
    SELECT VALUE -- Constructing OfficeAssignments
        [ContosoUniversity.DAL.OfficeAssignment](T1.OfficeAssignment_PersonID, T1.OfficeAssignment_Location, T1.OfficeAssignment_CreatedBy, T1.OfficeAssignment_CreatedOn, T1.OfficeAssignment_UpdatedBy, T1.OfficeAssignment_UpdatedOn)
    FROM (
        SELECT 
            T.PersonID AS OfficeAssignment_PersonID, 
            T.Location AS OfficeAssignment_Location, 
            T.CreatedBy AS OfficeAssignment_CreatedBy, 
            T.CreatedOn AS OfficeAssignment_CreatedOn, 
            T.UpdatedBy AS OfficeAssignment_UpdatedBy, 
            T.UpdatedOn AS OfficeAssignment_UpdatedOn, 
            True AS _from0
        FROM CodeFirstDatabase.OfficeAssignment AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.Enrollments
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView10()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.Enrollments", @"
    SELECT VALUE -- Constructing Enrollments
        [ContosoUniversity.DAL.Enrollment](T1.Enrollment_EnrollmentID, T1.Enrollment_CourseID, T1.Enrollment_PersonID, T1.Enrollment_Grade, T1.Enrollment_CreatedBy, T1.Enrollment_CreatedOn, T1.Enrollment_UpdatedBy, T1.Enrollment_UpdatedOn)
    FROM (
        SELECT 
            T.EnrollmentID AS Enrollment_EnrollmentID, 
            T.CourseID AS Enrollment_CourseID, 
            T.PersonID AS Enrollment_PersonID, 
            CAST(T.Grade AS [ContosoUniversity.DAL.Grade]) AS Enrollment_Grade, 
            T.CreatedBy AS Enrollment_CreatedBy, 
            T.CreatedOn AS Enrollment_CreatedOn, 
            T.UpdatedBy AS Enrollment_UpdatedBy, 
            T.UpdatedOn AS Enrollment_UpdatedOn, 
            True AS _from0
        FROM CodeFirstDatabase.Enrollment AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.Course_Instructors
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView11()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.Course_Instructors", @"
    SELECT VALUE -- Constructing Course_Instructors
        [ContosoUniversity.DAL.Course_Instructors](T3.[Course_Instructors.Course_Instructors_Source], T3.[Course_Instructors.Course_Instructors_Target])
    FROM (
        SELECT -- Constructing Course_Instructors_Source
            CreateRef(SchoolContext.Courses, row(T2.[Course_Instructors.Course_Instructors_Source.CourseID]), [ContosoUniversity.DAL.Course]) AS [Course_Instructors.Course_Instructors_Source], 
            T2.[Course_Instructors.Course_Instructors_Target]
        FROM (
            SELECT -- Constructing Course_Instructors_Target
                T1.[Course_Instructors.Course_Instructors_Source.CourseID], 
                CreateRef(SchoolContext.People, row(T1.[Course_Instructors.Course_Instructors_Target.PersonID]), [ContosoUniversity.DAL.Instructor]) AS [Course_Instructors.Course_Instructors_Target]
            FROM (
                SELECT 
                    T.CourseID AS [Course_Instructors.Course_Instructors_Source.CourseID], 
                    T.PersonID AS [Course_Instructors.Course_Instructors_Target.PersonID], 
                    True AS _from0
                FROM CodeFirstDatabase.CourseInstructor AS T
            ) AS T1
        ) AS T2
    ) AS T3");
        }
        
        /// <Summary>
        /// return view for CodeFirstDatabase.Audit
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView12()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("CodeFirstDatabase.Audit", @"
    SELECT VALUE -- Constructing Audit
        [CodeFirstDatabaseSchema.Audit](T1.Audit_AuditId, T1.Audit_TableId, T1.Audit_User, T1.Audit_TableName, T1.Audit_Action, T1.Audit_CreatedOn, T1.Audit_Before, T1.Audit_After)
    FROM (
        SELECT 
            T.AuditId AS Audit_AuditId, 
            T.TableId AS Audit_TableId, 
            T.User AS Audit_User, 
            T.TableName AS Audit_TableName, 
            T.Action AS Audit_Action, 
            T.CreatedOn AS Audit_CreatedOn, 
            T.Before AS Audit_Before, 
            T.After AS Audit_After, 
            True AS _from0
        FROM SchoolContext.Audits AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for SchoolContext.Audits
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView13()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("SchoolContext.Audits", @"
    SELECT VALUE -- Constructing Audits
        [ContosoUniversity.DAL.Audit](T1.Audit_AuditId, T1.Audit_TableId, T1.Audit_User, T1.Audit_TableName, T1.Audit_Action, T1.Audit_CreatedOn, T1.Audit_Before, T1.Audit_After)
    FROM (
        SELECT 
            T.AuditId AS Audit_AuditId, 
            T.TableId AS Audit_TableId, 
            T.User AS Audit_User, 
            T.TableName AS Audit_TableName, 
            T.Action AS Audit_Action, 
            T.CreatedOn AS Audit_CreatedOn, 
            T.Before AS Audit_Before, 
            T.After AS Audit_After, 
            True AS _from0
        FROM CodeFirstDatabase.Audit AS T
    ) AS T1");
        }
    }
}
