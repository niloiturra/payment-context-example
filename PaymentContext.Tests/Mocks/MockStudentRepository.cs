using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class MockStudentRepository: IStudentRepository
    {
        public bool DocumentExists(string document)
        {
            return document == "99999999999";
        }

        public bool EmailExists(string email)
        {
            return email == "hello@example";
        }

        public void CreateSubscription(Student student)
        {
        }
    }
}