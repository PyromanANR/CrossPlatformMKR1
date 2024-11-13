using MKR1;
using System;
using System.IO;
using Xunit;

namespace mkr1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_ValidInput()
        {
            string[] lines = { "3", "4", "5" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.Null(ex);
        }

        [Fact]
        public void Test_InputExceedsLimit()
        {
            string[] lines = new string[33]; // ������ 32 �����

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("The number of ingredients should not exceed 32.", ex.Message);
        }

        [Fact]
        public void Test_InputExceedsLimit2()
        {
            string[] lines = new string[32]; // ������ 32 �����

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
        }

        [Fact]
        public void Test_InvalidNumberFormat()
        {
            string[] lines = { "abc" };

            var ex = Record.Exception(() => Program.ValidateInput(lines));
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal("'abc' is not a real number.", ex.Message);
        }

        [Fact]
        public void Test_ValidProcessing()
        {
            string[] lines = { "3", "4", "5" };
            string expected = "4\n11\n26\n";

            string result = Program.ProcessLines(lines);

            Assert.Equal(expected, result);
        }
    }
}
