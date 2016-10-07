using Xunit;

//using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "01 - About Asserts")]
    public class AboutAsserts : Koan
    {
        //We shall contemplate truth by testing reality, via asserts.
        [Koan(1, DisplayName = "01.01 - Assert truth")]
        public void AssertTruth() 
        {
            Assert.True(true); //This should be true
        }

        //Enlightenment may be more easily achieved with appropriate messages
        [Koan(2, DisplayName = "01.02 - Assert truth with message")]
        public void AssertTruthWithMessage() 
        {
            Assert.True(true, "This should be true -- Please fix this");
        }

        //To understand reality, we must compare our expectations against reality
        [Koan(3, DisplayName = "01.03 - Assert equality")]
        public void AssertEquality() 
        {
            var expectedValue = 2;
            var actualValue = 1 + 1;

            Assert.True(expectedValue == actualValue);
        }

        //Some ways of asserting equality are better than others
        [Koan(4, DisplayName = "01.04 - A better way of asserting equality")]
        public void ABetterWayOfAssertingEquality() 
        {
            var expectedValue = 3;
            var actualValue = 1 + 1;

            Assert.Equal(expectedValue, actualValue);
        }

        //Sometimes we will ask you to fill in the values
        [Koan(5, DisplayName = "01.05 - Yo will have to fill in values sometimes")]
        public void FillInValues() 
        {
            Assert.Equal(FILL_ME_IN, 1 + 1);
        }
    }
}
