using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachineApp.core;
using CoffeeMachineApp.infrastructure;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CoffeeMachineApp.Tests.infrastructure
{
    public abstract class MessageComposerTest
    {
        private MessageComposer _messageComposer;

        [SetUp]
        public void SetUp()
        {
            _messageComposer = CreateSut();
        }

        [Test]
        public void select_drink_message()
        {
            var result = _messageComposer.ComposeSelectDrinkMessage();

            var expectedResult = Message.Create(SelectDrinkMessageText());
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static string SelectDrinkMessageText()
        {
            return "Por favor, seleccione una bebida.";
        }

        [Test]
        public void missing_money_message()
        {
            var amount = 0.5m;

            var result = _messageComposer.ComposeMissingMoneyMessage(amount);

            var expectedResult = Message.Create(GetSelectMissingZeroPointFiveMoneyText());
            Assert.That(result, Is.EqualTo(expectedResult));
        }



        [Test]
        public void missing_money_message_with_spanish_decimal_separator()
        {
            var amount = 1.9m;

            var result = _messageComposer.ComposeMissingMoneyMessage(amount);

            var expectedResult = Message.Create(GetSelectMissingOnePointNineMoneyText());
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        protected abstract MessageComposer CreateSut();

        protected abstract string GetSelectMissingZeroPointFiveMoneyText();

        protected abstract string GetSelectMissingOnePointNineMoneyText();
    }

    public class SpainMessageComposerTest : MessageComposerTest
    {
        protected override MessageComposer CreateSut()
        {
            return new SpainMessageComposer();
        }

        protected override string GetSelectMissingZeroPointFiveMoneyText()
        {
            return "Te falta 0,5";
        }

        protected override string GetSelectMissingOnePointNineMoneyText()
        {
            return "Te falta 1,9";

        }
    }

    public class PuertoRicoMessageComposerTest : MessageComposerTest
    {
        protected override MessageComposer CreateSut()
        {
            return new PuertoRicoMessageComposer();
        }

        protected override string GetSelectMissingZeroPointFiveMoneyText()
        {
            return "Te falta 0.5";
        }

        protected override string GetSelectMissingOnePointNineMoneyText()
        {
            return "Te falta 1.9";
            
        }
    }
}
