using NUnit.Framework;

using System;

namespace StudentTests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _service = new StudentService();
        }

        [Test]
        public void AddStudent_ShouldInsertStudent()
        {
            var student = new Student
            {
                Name = "Test User",
                Age = 22,
                Grade = "A",
                Email = $"testuser{Guid.NewGuid()}@example.com" 
            };

            Assert.DoesNotThrow(() => _service.AddStudent(student));
        }

        [Test]
        public void ViewStudents_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => _service.ViewStudents());
        }

        [Test]
        public void DeleteStudent_InvalidId_ShouldNotThrow()
        {
            int nonExistentId = 99999;
            Assert.DoesNotThrow(() => _service.DeleteStudent(nonExistentId));
        }

        [Test]
        public void FilterByGrade_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => _service.FilterByGrade("A"));
        }

        [Test]
        public void FilterByAge_ShouldNotThrow()
        {
            Assert.DoesNotThrow(() => _service.FilterByAge(22));
        }
    }
}
