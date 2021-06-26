using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using Xunit;

namespace PaymentContext.Tests.Handlers
{
    public class SubscriptionHandlerTests
    {
        [Fact]
        public void should_return_error_when_document_exists()
        {
            //arrange
            var handler = new SubscriptionHandler(new MockStudentRepository(), new MockEmailService());
            var command = new CreateBoletoSubscriptionCommand()
            {
                City = "NY",
                Country = "NY",
                Document = "99999999999",
                Email = "hello@teste.com",
                Neighborhood = "Neight",
                Number = "123",
                Payer = "Tony",
                State = "EX",
                Street = "Rua",
                Total = 10,
                BarCode = "1234567",
                BoletoNumber = "12351231",
                ExpireDate = DateTime.Now,
                FirstName = "Tony",
                LastName = "Stark",
                PaidDate = DateTime.Now,
                PayerDocument = "123123",
                PayerEmail = "email@teste.com",
                PaymentNumber = "123",
                TotalPaid = 10,
                ZipCode = "1231",
                PayerDocumentType = EDocumentType.CPF
            };
            
            //act
            handler.Handle(command);
            
            //assert
            Assert.False(handler.IsValid);
        }
    }
}