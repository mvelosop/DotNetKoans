using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Linq;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "06 - About Strings")]
    public class AboutStrings : Koan
    {
        //Note: This is one of the longest katas and, perhaps, one
        //of the most important. String behavior in .NET is not
        //always what you expect it to be, especially when it comes
        //to concatenation and newlines, and is one of the biggest
        //causes of memory leaks in .NET applications

        [Koan(1, DisplayName = "06.01 - DoubleQuotedStringsAreStrings")]
        public void DoubleQuotedStringsAreStrings()
        {
            var str = "Hello, World";

            Assert.Equal(typeof(FillMeIn), str.GetType());
        }

        [Koan(2, DisplayName = "06.02 - SingleQuotedStringsAreNotStrings")]
        public void SingleQuotedStringsAreNotStrings()
        {
            var str = 'H';

            Assert.Equal(typeof(FillMeIn), str.GetType());
        }

        [Koan(3, DisplayName = "06.03 - CreateAStringWhichContainsDoubleQuotes")]
        public void CreateAStringWhichContainsDoubleQuotes()
        {
            var str = "Hello, \"World\"";

            Assert.Equal(FILL_ME_IN, str.Length);
        }

        [Koan(4, DisplayName = "06.04 - AnotherWayToCreateAStringWhichContainsDoubleQuotes")]
        public void AnotherWayToCreateAStringWhichContainsDoubleQuotes()
        {
            //The @ symbol creates a 'verbatim string literal'. 
            //Here's one thing you can do with it:
            var str = @"Hello, ""World""";

            Assert.Equal(FILL_ME_IN, str.Length);
        }

        [Koan(5, DisplayName = "06.05 - VerbatimStringsCanHandleFlexibleQuoting")]
        public void VerbatimStringsCanHandleFlexibleQuoting()
        {
            var strA = @"Verbatim Strings can handle both ' and "" characters (when escaped)";
            var strB = "Verbatim Strings can handle both ' and \" characters (when escaped)";

            Assert.Equal(FILL_ME_IN, strA.Equals(strB));
        }

        [Koan(6, DisplayName = "06.06 - VerbatimStringsCanHandleMultipleLinesToo")]
        public void VerbatimStringsCanHandleMultipleLinesToo()
        {
            //Tip: What you create for the literal string will have to 
            //escape the newline characters. For Windows, that would be
            // \r\n. If you are on non-Windows, that would just be \n.
            //We'll show a different way next.
            var verbatimString = @"I
am a
broken line";

            Assert.Equal(20, verbatimString.Length);

            var literalString = FILL_ME_IN;

            Assert.Equal(literalString, verbatimString);
        }

        [Koan(7, DisplayName = "06.07 - ACrossPlatformWayToHandleLineEndings")]
        public void ACrossPlatformWayToHandleLineEndings()
        {
            //Since line endings are different on different platforms
            //(\r\n for Windows, \n for Linux) you shouldn't just type in
            //the hardcoded escape sequence. A much better way
            //(We'll handle concatenation and better ways of that in a bit)
            var literalString = "I" + System.Environment.NewLine + "am a" + System.Environment.NewLine + "broken line";

            var verbatimString = FILL_ME_IN;

            Assert.Equal(literalString, verbatimString);
        }

        [Koan(8, DisplayName = "06.08 - PlusWillConcatenateTwoStrings")]
        public void PlusWillConcatenateTwoStrings()
        {
            var str = "Hello, " + "World";

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(9, DisplayName = "06.09 - PlusConcatenationWillNotModifyOriginalStrings")]
        public void PlusConcatenationWillNotModifyOriginalStrings()
        {
            var strA = "Hello, ";
            var strB = "World";

            var fullString = strA + strB;

            Assert.Equal(FILL_ME_IN, strA);
            Assert.Equal(FILL_ME_IN, strB);
        }

        [Koan(10, DisplayName = "06.10 - PlusEqualsWillModifyTheTargetString")]
        public void PlusEqualsWillModifyTheTargetString()
        {
            var strA = "Hello, ";
            var strB = "World";

            strA += strB;

            Assert.Equal(FILL_ME_IN, strA);
            Assert.Equal(FILL_ME_IN, strB);
        }

        [Koan(11, DisplayName = "06.11 - StringsAreReallyImmutable")]
        public void StringsAreReallyImmutable()
        {
            //So here's the thing. Concatenating strings is cool
            //and all. But if you think you are modifying the original
            //string, you'd be wrong. 

            var strA = "Hello, ";

            var originalString = strA;

            var strB = "World";

            strA += strB;

            Assert.Equal(FILL_ME_IN, originalString);

            //What just happened? Well, the string concatenation actually
            //takes strA and strB and creates a *new* string in memory
            //that has the new value. It does *not* modify the original
            //string. This is a very important point - if you do this kind
            //of string concatenation in a tight loop, you'll use a lot of memory
            //because the original string will hang around in memory until the
            //garbage collector picks it up. Let's look at a better way
            //when dealing with lots of concatenation
        }

        [Koan(12, DisplayName = "06.12 - YouDoNotNeedConcatenationToInsertVariablesInAString")]
        public void YouDoNotNeedConcatenationToInsertVariablesInAString()
        {
            var world = "World";

            var str = String.Format("Hello, {0}", world);

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(13, DisplayName = "06.13 - AnyExpressionCanBeUsedInFormatString")]
        public void AnyExpressionCanBeUsedInFormatString()
        {
            var str = String.Format("The square root of 9 is {0}", Math.Sqrt(9));

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(14, DisplayName = "06.14 - StringsCanBePaddedToTheLeft")]
        public void StringsCanBePaddedToTheLeft()
        {
            //You can modify the value inserted into the result
            var str = string.Format("{0,3}", "x");

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(15, DisplayName = "06.15 - StringsCanBePaddedToTheRight")]
        public void StringsCanBePaddedToTheRight()
        {
            var str = string.Format("{0,-3}", "x");

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(16, DisplayName = "06.16 - SeperatorsCanBeAdded")]
        public void SeperatorsCanBeAdded()
        {
            var str = string.Format("{0:n}", 123456);

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(17, DisplayName = "06.17 - CurrencyDesignatorsCanBeAdded")]
        public void CurrencyDesignatorsCanBeAdded()
        {
            var str = string.Format("{0:C}", 123456);

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(18, DisplayName = "06.18 - NumberOfDisplayedDecimalsCanBeControled")]
        public void NumberOfDisplayedDecimalsCanBeControled()
        {
            var str = string.Format("{0:.##}", 12.3456);

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(19, DisplayName = "06.19 - MinimumNumberOfDisplayedDecimalsCanBeControled")]
        public void MinimumNumberOfDisplayedDecimalsCanBeControled()
        {
            var str = string.Format("{0:.00}", 12.3);

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(20, DisplayName = "06.20 - BuiltInDateFormaters")]
        public void BuiltInDateFormaters()
        {
            var str = string.Format("{0:t}", DateTime.Parse("12/16/2011 2:35:02 PM"));

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(21, DisplayName = "06.21 - CustomeDateFormaters")]
        public void CustomeDateFormaters()
        {
            var str = string.Format("{0:t m}", DateTime.Parse("12/16/2011 2:35:02 PM"));

            Assert.Equal(FILL_ME_IN, str);
        }

        //These are just a few of the formatters available. Dig some and you may find what you need.

        [Koan(22, DisplayName = "06.22 - ABetterWayToConcatenateLotsOfStrings")]
        public void ABetterWayToConcatenateLotsOfStrings()
        {
            //Concatenating lots of strings is a Bad Idea(tm). If you need to do that, then consider StringBuilder.
            var strBuilder = new System.Text.StringBuilder();

            strBuilder.Append("The ");
            strBuilder.Append("quick ");
            strBuilder.Append("brown ");
            strBuilder.Append("fox ");
            strBuilder.Append("jumped ");
            strBuilder.Append("over ");
            strBuilder.Append("the ");
            strBuilder.Append("lazy ");
            strBuilder.Append("dog.");

            var str = strBuilder.ToString();

            Assert.Equal(FILL_ME_IN, str);

            //String.Format and StringBuilder will be more efficent that concatenation. Prefer them.
        }

        [Koan(23, DisplayName = "06.23 - StringBuilderCanUseFormatAsWell")]
        public void StringBuilderCanUseFormatAsWell()
        {
            var strBuilder = new System.Text.StringBuilder();

            strBuilder.AppendFormat("{0} {1} {2} {3} ", "The", "quick", "brown", "fox");
            strBuilder.AppendFormat("{0} {1} {2} ", "jumped", "over", "the");
            strBuilder.AppendFormat("{0} {1}.", "lazy", "dog");

            var str = strBuilder.ToString();

            Assert.Equal(FILL_ME_IN, str);
        }

        [Koan(24, DisplayName = "06.24 - LiteralStringsInterpretsEscapeCharacters")]
        public void LiteralStringsInterpretsEscapeCharacters()
        {
            var str = "\n";

            Assert.Equal(FILL_ME_IN, str.Length);
        }

        [Koan(25, DisplayName = "06.25 - VerbatimStringsDoNotInterpretEscapeCharacters")]
        public void VerbatimStringsDoNotInterpretEscapeCharacters()
        {
            var str = @"\n";

            Assert.Equal(FILL_ME_IN, str.Length);
        }

        [Koan(26, DisplayName = "06.26 - VerbatimStringsStillDoNotInterpretEscapeCharacters")]
        public void VerbatimStringsStillDoNotInterpretEscapeCharacters()
        {
            var str = @"\\\";

            Assert.Equal(FILL_ME_IN, str.Length);
        }

        [Koan(27, DisplayName = "06.27 - YouCanGetASubstringFromAString")]
        public void YouCanGetASubstringFromAString()
        {
            var str = "Bacon, lettuce and tomato";

            Assert.Equal(FILL_ME_IN, str.Substring(19));
            Assert.Equal(FILL_ME_IN, str.Substring(7, 3));
        }

        [Koan(28, DisplayName = "06.28 - YouCanGetASingleCharacterFromAString")]
        public void YouCanGetASingleCharacterFromAString()
        {
            var str = "Bacon, lettuce and tomato";

            Assert.Equal(FILL_ME_IN, str[0]);
        }

        [Koan(29, DisplayName = "06.29 - SingleCharactersAreRepresentedByIntegers")]
        public void SingleCharactersAreRepresentedByIntegers()
        {
            Assert.Equal(97, 'a');
            Assert.Equal(98, 'b');
            Assert.Equal(FILL_ME_IN, 'b' == ('a' + 1));
        }

        [Koan(30, DisplayName = "06.30 - StringsCanBeSplit")]
        public void StringsCanBeSplit()
        {
            var str = "Sausage Egg Cheese";
            string[] words = str.Split();

            Assert.Equal(new[] { FILL_ME_IN }, words);
        }

        [Koan(31, DisplayName = "06.31 - StringsCanBeSplitUsingCharacters")]
        public void StringsCanBeSplitUsingCharacters()
        {
            var str = "the:rain:in:spain";
            string[] words = str.Split(':');

            Assert.Equal(new[] { FILL_ME_IN }, words);
        }

        [Koan(32, DisplayName = "06.32 - StringsCanBeSplitUsingRegularExpressions")]
        public void StringsCanBeSplitUsingRegularExpressions()
        {
            var str = "the:rain:in:spain";

            var regex = new System.Text.RegularExpressions.Regex(":");

            string[] words = regex.Split(str);

            Assert.Equal(new[] { FILL_ME_IN }, words);

            //A full treatment of regular expressions is beyond the scope
            //of this tutorial. The book "Mastering Regular Expressions"
            //is highly recommended to be on your bookshelf
        }

        [Koan(33, DisplayName = "06.33 - AnEasyWayToConcatenateCollectionsOfStrings")]
        public void AnEasyWayToConcatenateCollectionsOfStrings()
        {
            var stringList = new List<string> {
                "The",
                "quick",
                "brown",
                "fox",
                "jumped",
                "over",
                "the",
                "lazy",
                "dog."
            };

            var str = String.Join(" ", stringList);

            Assert.Equal(FILL_ME_IN, str);
        }


    }
}
