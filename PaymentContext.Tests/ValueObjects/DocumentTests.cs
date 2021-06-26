using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {
        [Fact]
        public void should_return_error_when_cnpj_is_invalid()
        {
            //arrange & act
            var doc = new Document("123", EDocumentType.CNPJ);

            //assert
            Assert.False(doc.IsValid);
        }

        [Fact]
        public void should_return_success_when_cnpj_is_valid()
        {
            //arrange & act
            var doc = new Document("34110468000150", EDocumentType.CNPJ);

            //assert
            Assert.True(doc.IsValid);
        }

        [Fact]
        public void should_return_error_when_cpf_is_invalid()
        {
            //arrange & act
            var doc = new Document("234", EDocumentType.CPF);

            //assert
            Assert.False(doc.IsValid);
        }

        [Fact]
        public void should_return_success_when_cpf_is_valid()
        {
            //arrange & act
            var doc = new Document("34225545806", EDocumentType.CPF);

            //assert
            Assert.True(doc.IsValid);
        }
    }
}