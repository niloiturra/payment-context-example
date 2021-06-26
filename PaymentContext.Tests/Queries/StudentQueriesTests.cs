using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.Queries
{
    public class StudentQueriesTests
    {
        private IList<Student> _students = new List<Student>();
        public StudentQueriesTests()
        {
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Name("Aluno", i.ToString()),
                    new Document("11111111111", EDocumentType.CPF), new Email(i.ToString() + "@teste")));
            }
        }
        
        [Fact]
        public void should_return_null_when_document_not_exists()
        {
            var exp = StudentQueries.GetStudentInfo("2345643634");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();
            
            Assert.Null(student);
        }
        
        [Fact]
        public void should_return_document_when_document_exists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();
            
            Assert.NotNull(student);
        }
    }
}