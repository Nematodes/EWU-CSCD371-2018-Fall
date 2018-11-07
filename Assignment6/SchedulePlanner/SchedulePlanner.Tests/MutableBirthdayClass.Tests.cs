using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class MutableBirthdayClassTests
    {
        private MutableBirthdayClass TestMutableBirthdayClass;

        [TestMethod]
        public void Constructor_ValidParameters_FieldsAreSet()
        {
            TestMutableBirthdayClass = new MutableBirthdayClass(0.5, 10, true);

            Assert.IsTrue(TestMutableBirthdayClass.CollisionProbability == 0.5);
            Assert.IsTrue(TestMutableBirthdayClass.CandleCount == 10);
            Assert.IsTrue(TestMutableBirthdayClass.IsCakeReady == true);
        }

        [TestMethod]
        public void Constructor_CollisionProbabilityLargerThan1_CollisionProbabilityIs1()
        {
            TestMutableBirthdayClass = new MutableBirthdayClass(2147000, 10, true);

            Assert.IsTrue(TestMutableBirthdayClass.CollisionProbability == 1);
        }

        [TestMethod]
        public void Constructor_NegativeCollisionProbability_CollisionProbabilityIs0()
        {
            TestMutableBirthdayClass = new MutableBirthdayClass(-2147000, 10, true);

            Assert.IsTrue(TestMutableBirthdayClass.CollisionProbability == 0);
        }

        [TestMethod]
        public void ClassChangedInMethod_OriginalValuesAreChanged()
        {
            TestMutableBirthdayClass = new MutableBirthdayClass(0.5, 10, true);
            ChangeMutableBirthdayClassValues(TestMutableBirthdayClass);

            Assert.IsTrue(TestMutableBirthdayClass.CollisionProbability == 0.1);
            Assert.IsTrue(TestMutableBirthdayClass.CandleCount == 11);
            Assert.IsTrue(TestMutableBirthdayClass.IsCakeReady == false);
        }

        [TestMethod]
        public void ClassChangedInNewInstanceMethod_OriginalValuesAreChanged()
        {
            TestMutableBirthdayClass = new MutableBirthdayClass(0.5, 10, true);
            ChangeMutableBirthdayClassValuesNewInstance(ref TestMutableBirthdayClass);

            Assert.IsTrue(TestMutableBirthdayClass.CollisionProbability == 0.1);
            Assert.IsTrue(TestMutableBirthdayClass.CandleCount == 11);
            Assert.IsTrue(TestMutableBirthdayClass.IsCakeReady == false);
        }

        private void ChangeMutableBirthdayClassValues(MutableBirthdayClass mutableBirthdayClass)
        {
            mutableBirthdayClass.CollisionProbability = 0.1;
            mutableBirthdayClass.CandleCount++;
            mutableBirthdayClass.IsCakeReady = !mutableBirthdayClass.IsCakeReady;
        }

        // A reference must be used. If a reference isn't used, the copy of the reference to mutableBirthdayClass will be overridden and then discarded after the method ends
        private void ChangeMutableBirthdayClassValuesNewInstance(ref MutableBirthdayClass mutableBirthdayClass)
        {
            mutableBirthdayClass = new MutableBirthdayClass(0.1, ++mutableBirthdayClass.CandleCount, !mutableBirthdayClass.IsCakeReady);
        }
    }
}