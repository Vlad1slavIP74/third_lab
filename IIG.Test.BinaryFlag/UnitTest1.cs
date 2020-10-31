using System;
using System.IO;
using Xunit;

namespace IIG.Test.BinaryFlag
{
    public class UnitTest1
    {
        [Fact]
        public void TestConstructorReturnTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(4);
            bool actual = mbf.GetFlag();
            Assert.True(actual);
        }
        [Fact]
        public void TestConstructorReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(4, false);
            bool actual = mbf.GetFlag();
            Assert.False(actual);
        }
        [Fact]
        public void TestConstructorMinLengthException()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1, false);
            }catch(Exception e)
            {
                bool actual = e.Message.Contains("Length of Flag must be bigger than one");

                Assert.True(actual);
            }
        }
        [Fact]
        public void TestConstructorBigLengthException()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(17179868705, false);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Length of Flag must be lesser than '17179868704'");

                Assert.True(actual);
            }
        }
        [Fact]
        public void TestSetFlagReturnTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(40, false);
            for (ulong i = 0; i < 40; i++)
            {
                mbf.SetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.True(actual);
        }
        [Fact]
        public void TestSetFlagReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(20, false);
            for (ulong i = 0; i < 10; i++)
            {
                mbf.SetFlag(i);
            }
            bool actual = mbf.GetFlag();
            Assert.False(actual);
        }
        [Fact]
        public void TestSetFlagExceedsLengthException()
        {
            try
            {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(30, false);
            mbf.SetFlag(50);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Position must be lesser than length");
                Assert.True(actual);
            }
        }
        [Fact]
        public void TestResetFlagReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(400, true);
            for (ulong i = 0; i < 400; i++)
            {
                mbf.ResetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.False(actual);
        }
        [Fact]
        public void TestResetFlagReturnFalse1()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(400, false);
            for (ulong i = 0; i < 100; i++)
            {
                mbf.ResetFlag(i);
            }
            bool actual = mbf.GetFlag();

            Assert.False(actual);
        }
        [Fact]
        public void TestResetFlagExceedsLengthException()
        {
            try
            {
                IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(200, false);
                mbf.ResetFlag(300);
            }
            catch (Exception e)
            {
                bool actual = e.Message.Contains("Position must be lesser than length");
                Assert.True(actual);
            }
        }     
    }
}
