using EmploymentTestLibrary;
using EmploymentTestLibrary.DBModels;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace EmploymentTestUnitTest
{
    [TestFixture]
    public class UnitTest
    {
        Mock<IDBRepository> _IDBRepository = new Mock<IDBRepository>();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Calculation()
        {
            //arrange
            var test = "$2.00";
            var logic = new Logic(_IDBRepository.Object);

            //act
            var result = logic.EmploymentTest("1+1");

            //assert
            result.Should().Be(test);            
        }

        [Test]
        [TestCase("a", false), TestCase("1+1", true), TestCase("1 - 1", true), TestCase("1 @ 1", true), TestCase("2 * 1", true), TestCase("8 * 2", true), TestCase("8 / 2", false)]
        public void Valid_Calculation_Should_Return(string input, bool answer)
        {
            //arrange          
            var logic = new Logic(_IDBRepository.Object);

            //act
            var result = logic.TestForValidCalculation(input);

            //assert
            result.Should().Be(answer);
        }

        [Test]
        public void DailyCost_Should_Return_()
        {
            //arrange
            _IDBRepository.Setup(db => db.GetInterestRate())
                .Returns(
                new Interest()
                {
                    InterestRate = 42,
                    TimesPerYear = 12
                });

            var logic = new Logic(_IDBRepository.Object);

            //act
            var result = logic.EstimateDailyCost(1000);

            //assert
            result.Should().Be("$50.69");
        }
    }
}
