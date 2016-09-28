using System;
using System.Collections.Generic;
using Xunit;

using Assert = Xunit.KoanHelpers.Assert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "09 - About Control Statements")]
    public class AboutControlStatements : Koan
    {
        [Koan(1, DisplayName = "09.01 - IfThenElseStatementsWithBrackets")]
        public void IfThenElseStatementsWithBrackets()
        {
            bool b;

            if (true)
            {
                b = true;
            }
            else
            {
                b = false;
            }

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(2, DisplayName = "09.02 - IfThenElseStatementsWithoutBrackets")]
        public void IfThenElseStatementsWithoutBrackets()
        {
            bool b;

            if(true)
                b = true;
            else
                b = false;

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(3, DisplayName = "09.03 - IfThenStatementsWithBrackets")]
        public void IfThenStatementsWithBrackets()
        {
            bool b = false;
            if (true)
            {
                b = true;
            }

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(4, DisplayName = "09.04 - IfThenStatementsWithoutBrackets")]
        public void IfThenStatementsWithoutBrackets()
        {
            bool b = false;
            if (true)
                b = true;

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(5, DisplayName = "09.05 - WhyItsWiseToAlwaysUseBrackets")]
        public void WhyItsWiseToAlwaysUseBrackets()
        {
            bool b1 = false;
            bool b2 = false;

            int counter = 1;

            if (counter == 0)
                b1 = true;
                b2 = true;

            Assert.Equal(FILL_ME_IN, b1);
            Assert.Equal(FILL_ME_IN, b2);
        }

        [Koan(6, DisplayName = "09.06 - TernaryOperators")]
        public void TernaryOperators()
        {
            Assert.Equal(FILL_ME_IN, (true ? 1 : 0));
            Assert.Equal(FILL_ME_IN, (false ? 1 : 0));
        }

        //This is out of place for control statements, but necessary for Koan 8
        [Koan(7, DisplayName = "09.07 - NullableTypes")]
        public void NullableTypes()
        {
            int i = 0;
            //i = null; //You can't do this

            int? nullableInt = null; //but you can do this
            Assert.NotNull(FILL_ME_IN);
            Assert.Null(FILL_ME_IN);
        }

        [Koan(8, DisplayName = "09.08 - AssignIfNullOperator")]
        public void AssignIfNullOperator()
        {
            int? nullableInt = null;

            int x = nullableInt ?? 42;

            Assert.Equal(FILL_ME_IN, x);
        }

        [Koan(9, DisplayName = "09.09 - IsOperators")]
        public void IsOperators()
        {
            bool isKoan = false;
            bool isAboutControlStatements = false;
            bool isAboutMethods = false;

            var myInstance = this;

            if (myInstance is Koan)
                isKoan = true;

            if (myInstance is AboutControlStatements)
                isAboutControlStatements = true;

            if (myInstance is AboutMethods)
                isAboutMethods = true;

            Assert.Equal(FILL_ME_IN, isKoan);
            Assert.Equal(FILL_ME_IN, isAboutControlStatements);
            Assert.Equal(FILL_ME_IN, isAboutMethods);

        }

        [Koan(10, DisplayName = "09.10 - WhileStatement")]
        public void WhileStatement()
        {
            int i = 1;
            int result = 1;

            while (i <= 3)
            {
                result = result + i;
                i += 1;
            }

            Assert.Equal(FILL_ME_IN, result);
        }

        [Koan(11, DisplayName = "09.11 - BreakStatement")]
        public void BreakStatement()
        {
            int i = 1;
            int result = 1;

            while (true)
            {
                if (i > 3) { break; }

                result = result + i;
                i += 1;    
            }

            Assert.Equal(FILL_ME_IN, result);
        }

        [Koan(12, DisplayName = "09.12 - ContinueStatement")]
        public void ContinueStatement()
        {
            int i = 0;
            var result = new List<int>();

            while(i < 10)
            {
                i += 1;

                if ((i % 2) == 0) { continue; }

                result.Add(i);
            }

            Assert.Equal(FILL_ME_IN, result);
        }

        [Koan(13, DisplayName = "09.13 - ForStatement")]
        public void ForStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (list[i].ToUpper());
            }

            Assert.Equal(FILL_ME_IN, list);
        }

        [Koan(14, DisplayName = "09.14 - ForEachStatement")]
        public void ForEachStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };
            var finalList = new List<string>();

            foreach (string item in list)
            {
                finalList.Add(item.ToUpper());
            }

            Assert.Equal(FILL_ME_IN, list);
            Assert.Equal(FILL_ME_IN, finalList);
        }

        [Koan(15, DisplayName = "09.15 - ModifyingACollectionDuringForEach")]
        public void ModifyingACollectionDuringForEach()
        {
            var list = new List<string> { "fish", "and", "chips" };

            try
            {
                foreach (string item in list)
                {
                    list.Add(item.ToUpper());
                }
            }
            catch (Exception ex)
            {
                Assert.Equal(typeof(FillMeIn), ex.GetType());
            }
        }

        [Koan(16, DisplayName = "09.16 - CatchingModificationExceptions")]
        public void CatchingModificationExceptions()
        {
            string whoCaughtTheException = "No one";

            var list = new List<string> { "fish", "and", "chips" };

            try
            {
                foreach (string item in list)
                {
                    try
                    {
                        list.Add(item.ToUpper());
                    }
                    catch
                    {
                        whoCaughtTheException = "When we tried to Add it";
                    }
                }
            }
            catch
            {
                whoCaughtTheException = "When we tried to move to the next item in the list";
            }

            Assert.Equal(FILL_ME_IN, whoCaughtTheException);
        }
    }
}