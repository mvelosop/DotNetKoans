using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "01 - About Asserts")]
    public class AboutAsserts : Koan
    {
        //We shall contemplate truth by testing reality, via asserts.
        [Koan(1, DisplayName = "01.01 - AssertTruth")]
        public void AssertTruth() 
        {
            Assert.True(false); //This should be true
        }

        //Enlightenment may be more easily achieved with appropriate messages
        [Koan(2, DisplayName = "01.02 - AssertTruthWithMessage")]
        public void AssertTruthWithMessage() 
        {
            Assert.True(false, "This should be true -- Please fix this");
        }

        //To understand reality, we must compare our expectations against reality
        [Koan(3, DisplayName = "01.03 - AssertEquality")]
        public void AssertEquality() 
        {
            var expectedValue = 3;
            var actualValue = 1 + 1;

            Assert.True(expectedValue == actualValue);
        }

        //Some ways of asserting equality are better than others
        [Koan(4, DisplayName = "01.04 - ABetterWayOfAssertingEquality")]
        public void ABetterWayOfAssertingEquality() 
        {
            var expectedValue = 3;
            var actualValue = 1 + 1;

            Assert.Equal(expectedValue, actualValue);
        }

        //Sometimes we will ask you to fill in the values
        [Koan(5, DisplayName = "01.05 - FillInValues")]
        public void FillInValues() 
        {
            Assert.Equal(FILL_ME_IN, 1 + 1);
        }
    }
}
