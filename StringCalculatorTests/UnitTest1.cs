using StringCalculator;

namespace StringCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnZero()
        {
            int result = Program.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ReturnSumOfOneNum()
        {
            int result = Program.Add("1");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ReturnSumOfTwoNums()
        {
            int result = Program.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReturnSumOfMultipleNums()
        {
            int result = Program.Add("1,2,3,4");

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ReturnSumOfMultipleNumsWithNewLine()
        {
            int result = Program.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }
        
        [TestMethod]
        public void ReturnSumWithDifferentDelimiters()
        {
            int result = Program.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ReturnSumWithOneNegative()
        {
            Action invocation = () => Program.Add("-1,2");
            Assert.ThrowsException<NegativesNotAllowedException>(invocation, "Negatives not allowed: -1");
        }

        [TestMethod]
        public void ReturnSumWithOneNegativeAndDash()
        {
            Action invocation = () => Program.Add("-1-,2");
            Assert.ThrowsException<NegativesNotAllowedException>(invocation, "Negatives not allowed: -1");
        }

        [TestMethod]
        public void ReturnSumWithTwoNegatives()
        {
            Action invocation = () => Program.Add("2,-4,3,-5");
            Assert.ThrowsException<NegativesNotAllowedException>(invocation, "Negatives not allowed: -4,-5");
        }

        [TestMethod]
        public void ReturnSumWithOver1K()
        {
            int result = Program.Add("1001,2");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ReturnSumWithAnyLengthDelimeters()
        {
            int result = Program.Add("//[|||]\n1|||2|||3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ReturnSumWithMultipleDelimeters()
        {
            int result = Program.Add("//[|][%]\n1|2%3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ReturnSumWithAnyLengthDelimetersAndOver1K()
        {
            int result = Program.Add("//[|||]\n1|||2000|||3");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void ReturnSumWithMultipleSigns()
        {
            int result = Program.Add("//[|||]\n1|||2|||3");

            Assert.AreEqual(6, result);
        }
    }
}