namespace Catalog.UnitTests
{
    public class SampleUnitTests
    {
        [Fact]
        public void SampleTest1()
        {
            //Arrange
            var t = 1;
            var z = 1;

            //Act
            t += 5;
            z += 5;

            //Assert
            Assert.Equal(6, t);
            Assert.Equal(6, z);
        }

        [Fact]
        public void SampleTest2()
        {
            //Arrange
            var s1 = "string1";
            var s2 = "string1";

            //Act
            s1 += 'a';
            s2 += "a";

            //Assert
            Assert.Equal("string1a", s2);
            Assert.Equal("string1a", s1);
            Assert.Equal(s1, s2);
        }
    }
}