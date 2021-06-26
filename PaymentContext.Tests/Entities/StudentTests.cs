using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests
{
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;

        public StudentTests()
        {
            _name = new Name("Tony", "Stark");
            _document = new Document("36545678981", EDocumentType.CPF);
            _email = new Email("tonystark@marvel.com");
            _address = new Address("Rua 1", "123", "Bairro exemplo", "City", "NY", "EUA", "123");
            _student = new Student(_name, _document, _email);
        }

        [Fact]
        public void should_return_error_when_had_active_subscription()
        {
            //arrange
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", _email, DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "STARK INDUSTRIES", _document, _address);
            subscription.AddPayment(payment);

            //act
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);

            //assert
            Assert.False(_student.IsValid);
        }

        [Fact]
        public void should_return_error_when_subscription_has_no_payment()
        {
            //arrange & act
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);

            //assert
            Assert.False(_student.IsValid);
        }

        [Fact]
        public void should_return_success_when_add_subscription()
        {
            //arrange
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("12345678", _email, DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "STARK INDUSTRIES", _document, _address);
            subscription.AddPayment(payment);

            //act
            _student.AddSubscription(subscription);

            //assert
            Assert.True(_student.IsValid);
        }
    }
}
