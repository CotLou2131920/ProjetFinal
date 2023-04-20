using BiblioCalculatrice;
namespace TestCalcul
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {
            double x = 45;
            double y = 55;
            double expected = 100;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Addition(x, y);

            Assert.AreEqual(expected, rep);
        }

        [TestMethod]
        public void TestSous()
        {
            int x = 55;
            int y = 45;
            double expected = 10;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Soustraction(x, y);

            Assert.AreEqual(expected, rep);
        }

        [TestMethod]
        public void TestMethodMult()
        {
            int x = 4;
            int y = 5;
            double expected = 20;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Multiplier(x, y);

            Assert.AreEqual(expected, rep);
        }
        [TestMethod]
        public void TestMethodDiv()
        {
            int x = 20;
            int y = 5;
            double expected = 4;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Diviser(x, y);

            Assert.AreEqual(expected, rep);
        }
        [TestMethod]
        public void TestMethodExp()
        {
            int x = 2;
            int y = 5;
            double expected = 32;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Exposant(x, y);

            Assert.AreEqual(expected, rep);
        }
        [TestMethod]
        public void TestMethodLog()
        {
            int x = 4;
            int y = 2;
            double expected = 2;
            Calculatrice calcul = new Calculatrice();

            double rep = calcul.Log(x, y);

            Assert.AreEqual(expected, rep);
        }
    }
}