using System;
using Xunit;
using CourseGrader;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_GradeTestScores_ReturnsPass_WhenAvgGreaterThan70()
        {
            int[] testCase = { 55, 50, 90, 90 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("pass", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsPass_WhenAvgEqualTo70()
        {
            int[] testCase = { 50, 50, 90, 90 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("pass", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_WhenAvgGreaterThan70_WithAScoreLessThan50()
        {
            int[] testCase = { 49, 50, 90, 91 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_WhenAvgLessThan70()
        {
            int[] testCase = { 49, 50, 70, 91 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_WhenAvgLessThan70_AndAllScoresLessThan50()
        {
            int[] testCase = { 49, 49, 49 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_WhenNoTestScores()
        {
            int[] testCase = { };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsPass_WhenAvg70_AndOnlyOneScore()
        {
            int[] testCase = { 70 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("pass", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_WhenAvgLessThan70_AndOnlyOneScore()
        {
            int[] testCase = { 69 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }

        [Fact]
        public void Test_GradeTestScores_ReturnsFail_ScoreIsZero()
        {
            int[] testCase = { 0 };

            string actual = Program.GradeTestScores(testCase);

            Assert.Equal("fail", actual);
        }
    }
}
