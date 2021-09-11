﻿using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
   public enum Grade
   {
      A, B, C, D, F
   }

   public class Enrollment : AuditBase
   {
      public int EnrollmentID { get; set; }
      public int CourseID { get; set; }
      public int PersonID  { get; set; }

      [DisplayFormat(NullDisplayText = "No grade")]
      public Grade? Grade { get; set; }

      public virtual Course Course { get; set; }
      public virtual Student Student { get; set; }
   }
}