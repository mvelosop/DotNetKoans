using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Assert = Xunit.KoanHelpers.KoanAssert;

namespace DotNetKoans.CSharp
{
    [Trait("Topic", "11 - About Lambdas")]
    public class AboutLambdas : Koan
    {
        [Koan(1, DisplayName = "11.01 - UsingAnonymousMethods")]
        public void UsingAnonymousMethods()
        {
            //The AboutDelegates Koans introduced you to delegates. In all of those koans, 
            //the delegate was assigned to a predefined method. 
            //Anonymous methods let you define the method in place.
            //This Koan produces the same result as AboutDelegates.ChangingTypesWithConverter, but it uses 
            //an anonymous method instead. As you can see there is no method name, but it is 
            //prefixed with "delegate"
            var numbers = new[] { 1, 2, 3, 4 };

            var result = Array.ConvertAll(numbers, delegate(int x)
                {
                    return x.ToString();
                });

            Assert.Equal(FILL_ME_IN, result);
        }

        [Koan(2, DisplayName = "11.02 - AnonymousMethodsCanAccessOuterVariables")]
        public void AnonymousMethodsCanAccessOuterVariables()
        {
            //Anonymous methods can access variable defined in the scope of the method where they are defined.
            //In C# this is called accessing an Outer Variable. In other languages it is called closure. 
            var numbers = new[] { 4, 5, 6, 7, 8, 9 };
            int toFind = 7;

            Assert.Equal(FILL_ME_IN, Array.FindIndex(numbers, delegate(int x)
                {
                    return x == toFind;
                }));
        }

        [Koan(3, DisplayName = "11.03 - AccessEvenAfterVariableIsOutOfScope")]
        public void AccessEvenAfterVariableIsOutOfScope()
        {
            Predicate<int> criteria;

            {
                //Anonymous methods even have access to the value after the value has gone out of scope
                int toFind = 7;

                criteria = delegate(int x)
                    {
                        return x == toFind;
                    };
            }

            var numbers = new[] { 4, 5, 6, 7, 8, 9 };

            //toFind is not available here, yet criteria still works
            Assert.Equal(FILL_ME_IN, Array.FindIndex(numbers, criteria));
        }

        [Koan(4, DisplayName = "11.04 - LambdaExpressionsAreShorthand")]
        public void LambdaExpressionsAreShorthand()
        {
            var numbers = new[] { 1, 2, 3, 4 };

            var anonymous = Array.ConvertAll(numbers, delegate(int x)
                {
                    return x.ToString();
                });

            //Lambda expressions are really nothing more than a short hand way of writing anonymous methods
            //The following is the same work done using a Lambda expression. 
            //The delegate key word is replaced with => on the other side of the parameters
            //        |                               |
            //        |                               \-----\
            //        \----------------------------\        |
            //                                     v        v
            var lambda = Array.ConvertAll(numbers,  (int x) => 
                {
                    return x.ToString(); 
                });

            Assert.Equal(FILL_ME_IN, anonymous);
            //The => pair is spoken as "going into". If you were talking about this 
            //code with a peer, you would say "x going into..."
        }

        [Koan(5, DisplayName = "11.05 - TypeCanBeInferred")]
        public void TypeCanBeInferred()
        {
            //Fortunately the above form of a Lambda is the most verbose form. 
            //Most of the time you can take many of the pieces out. 
            //The next few Koans will step you through the optional pieces.
            var numbers = new[] { 1, 2, 3, 4 };

            var anonymous = Array.ConvertAll(numbers, delegate(int x)
                {
                    return x.ToString();
                });

            // type is removed from the parameter --v
            var lambda = Array.ConvertAll(numbers, (x) =>
                {
                    return x.ToString();
                });

            Assert.Equal(FILL_ME_IN, anonymous);
        }

        [Koan(6, DisplayName = "11.06 - ParensNotNeededOnSingleParemeterLambdas")]
        public void ParensNotNeededOnSingleParemeterLambdas()
        {
            var numbers = new[] { 1, 2, 3, 4 };

            var anonymous = Array.ConvertAll(numbers, delegate(int x)
            {
                return x.ToString();
            });


            //When you have only one parameter, no parenthesis are needed -\
            //                                     v-----------------------/
            var lambda = Array.ConvertAll(numbers, x =>
                {
                    return x.ToString();
                });

            Assert.Equal(FILL_ME_IN, anonymous);
        }

        [Koan(7, DisplayName = "11.07 - BlockNotNeededOnSingleStatementLambdas")]
        public void BlockNotNeededOnSingleStatementLambdas()
        {
            var numbers = new[] { 1, 2, 3, 4 };

            var anonymous = Array.ConvertAll(numbers, delegate(int x)
                {
                    return x.ToString();
                });

            var lambda = Array.ConvertAll(numbers, x => x.ToString());

            //When you have only one statement, the curly brackets are not needed. What other two things are also missing?
            Assert.Equal(FILL_ME_IN, anonymous);
        }
    }
}
