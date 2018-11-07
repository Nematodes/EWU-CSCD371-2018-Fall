using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignmentSix
{
    [TestClass]
    public class MutableBirthdayStructTests
    {
        private MutableBirthdayStruct TestMutableBirthdayStruct;

        [TestMethod]
        public void Constructor_ValidParameters_FieldsAreSet()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(0.5, 10, true);

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 0.5);
            Assert.IsTrue(TestMutableBirthdayStruct.CandleCount == 10);
            Assert.IsTrue(TestMutableBirthdayStruct.IsCakeReady == true);
        }

        [TestMethod]
        public void Constructor_NoParameters_FieldsAreDefault()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct();

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 0);
            Assert.IsTrue(TestMutableBirthdayStruct.CandleCount == 0);
            Assert.IsTrue(TestMutableBirthdayStruct.IsCakeReady == false);
        }

        [TestMethod]
        public void Constructor_CollisionProbabilityLargerThan1_CollisionProbabilityIs1()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(2147000, 10, true);

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 1);
        }

        [TestMethod]
        public void Constructor_NegativeCollisionProbability_CollisionProbabilityIs0()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(-2147000, 10, true);

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 0);
        }

        [TestMethod]
        public void StructChangedInMethod_OriginalValuesAreUnchanged()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(0.5, 10, true);
            ChangeMutableBirthdayStructValues(TestMutableBirthdayStruct);

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 0.5);
            Assert.IsTrue(TestMutableBirthdayStruct.CandleCount == 10);
            Assert.IsTrue(TestMutableBirthdayStruct.IsCakeReady == true);
        }

        [TestMethod]
        public void StructReferenceChangedInMethod_OriginalValuesAreChanged()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(0.5, 10, true);
            ChangeMutableBirthdayStructReferenceValues(ref TestMutableBirthdayStruct);

            Assert.IsTrue(TestMutableBirthdayStruct.CollisionProbability == 0.1);
            Assert.IsTrue(TestMutableBirthdayStruct.CandleCount == 11);
            Assert.IsTrue(TestMutableBirthdayStruct.IsCakeReady == false);
        }

        [TestMethod]
        public void StructAsIBirthdayChangedInMethod_OriginalValuesAreChanged()
        {
            TestMutableBirthdayStruct = new MutableBirthdayStruct(0.5, 10, true);
            object testMutableBirthdayStructObject = TestMutableBirthdayStruct;
            ChangeIBirthdayValues((IBirthday) testMutableBirthdayStructObject);

            Assert.IsTrue(((MutableBirthdayStruct) testMutableBirthdayStructObject).CollisionProbability == 0.5);
            Assert.IsTrue(((MutableBirthdayStruct) testMutableBirthdayStructObject).CandleCount == 11);
            Assert.IsTrue(((MutableBirthdayStruct) testMutableBirthdayStructObject).IsCakeReady == false);
        }

        private void ChangeMutableBirthdayStructValues(MutableBirthdayStruct mutableBirthdayStruct)
        {
            mutableBirthdayStruct.CollisionProbability = 0.1;
            mutableBirthdayStruct.CandleCount++;
            mutableBirthdayStruct.IsCakeReady = !mutableBirthdayStruct.IsCakeReady;
        }

        private void ChangeMutableBirthdayStructReferenceValues(ref MutableBirthdayStruct mutableBirthdayStruct)
        {
            mutableBirthdayStruct.CollisionProbability = 0.1;
            mutableBirthdayStruct.CandleCount++;
            mutableBirthdayStruct.IsCakeReady = !mutableBirthdayStruct.IsCakeReady;
        }

        private void ChangeIBirthdayValues(IBirthday inputIBirthday)
        {
            inputIBirthday.CandleCount++;
            inputIBirthday.IsCakeReady = !inputIBirthday.IsCakeReady;
        }
    }
}