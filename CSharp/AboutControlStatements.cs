using System;
using System.Collections.Generic;
using Xunit;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "10 - About Control Statements")]
    public class AboutControlStatements : Koan
    {
        [Koan(1, DisplayName = "10.01 - If then else statements with brackets")]
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

        [Koan(2, DisplayName = "10.02 - If then else statements without brackets")]
        public void IfThenElseStatementsWithoutBrackets()
        {
            bool b;

            if(true)
                b = true;
            else
                b = false;

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(3, DisplayName = "10.03 - If then statements with brackets")]
        public void IfThenStatementsWithBrackets()
        {
            bool b = false;
            if (true)
            {
                b = true;
            }

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(4, DisplayName = "10.04 - If then statements without brackets")]
        public void IfThenStatementsWithoutBrackets()
        {
            bool b = false;
            if (true)
                b = true;

            Assert.Equal(FILL_ME_IN, b);
        }

        [Koan(5, DisplayName = "10.05 - Why its wise to always use brackets")]
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

        [Koan(6, DisplayName = "10.06 - Ternary operators")]
        public void TernaryOperators()
        {
            Assert.Equal(FILL_ME_IN, (true ? 1 : 0));
            Assert.Equal(FILL_ME_IN, (false ? 1 : 0));
        }

        //This is out of place for control statements, but necessary for Koan 8
        [Koan(7, DisplayName = "10.07 - Nullable types")]
        public void NullableTypes()
        {
            int i = 0;
            //i = null; //You can't do this

            int? nullableInt = null; //but you can do this
            Assert.NotNull(FILL_ME_IN);
            Assert.Null(FILL_ME_IN);
        }

        [Koan(8, DisplayName = "10.08 - Assign if null operator")]
        public void AssignIfNullOperator()
        {
            int? nullableInt = null;

            int x = nullableInt ?? 42;

            Assert.Equal(FILL_ME_IN, x);
        }

        [Koan(9, DisplayName = "10.09 - Is operators")]
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

        [Koan(10, DisplayName = "10.10 - While statement")]
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

        [Koan(11, DisplayName = "10.11 - Break statement")]
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

        [Koan(12, DisplayName = "10.12 - Continue statement")]
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

        [Koan(13, DisplayName = "10.13 - For statement")]
        public void ForStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (list[i].ToUpper());
            }

            Assert.Equal(FILL_ME_IN, list);
        }

        [Koan(14, DisplayName = "10.14 - For each statement")]
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

        [Koan(15, DisplayName = "10.15 - Modifying a collection during for each")]
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

        [Koan(16, DisplayName = "10.16 - Catching modification exceptions")]
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