using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Tests.Commands
{
    public class CreateCreditCardSubscriptionCommandTests
    {
        [Fact]
        public void should_return_error_when_name_is_invalid()
        {
            //arrange
            var command = new CreateCreditCardSubscriptionCommand();
            command.FirstName = "";

            //act
            command.Validate();

            //assert
            Assert.False(command.IsValid);
        }
    }
}