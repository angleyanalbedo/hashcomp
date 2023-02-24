namespace Testcomp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine(HashHelper.MD5File("D:\\Image_FIle\\Ms Dos.ova"));
            Assert.Pass();
        }
    }
}