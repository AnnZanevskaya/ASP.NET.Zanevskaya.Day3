using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Tests
{
    [TestClass]
    public class PolynomialTest
    {
        [TestMethod]
        public void Equality_OfTwoPolynomials()
        {
            Polynomial first = new Polynomial(5, 7);
            Polynomial second = new Polynomial(5, 7);

            Assert.IsTrue(first.Equals(second));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Equality_OfPolynomialAndNULL()
        {
            Polynomial first = new Polynomial(5, 7);
            Polynomial second = null;

            Assert.IsTrue(first.Equals(second));
        }
        [TestMethod]
        public void NonEquality_OfTwoPolynomials()
        {
            Polynomial first = new Polynomial(5, 7);
            Polynomial second = new Polynomial(3, 7, 8);

            Assert.IsFalse(first.Equals(second));
        }
        [TestMethod]
        public void ResultOfPolynomial()
        {
            Polynomial first = new Polynomial( 5, 7);         
            double expected = first.ResultOfPolynomial(2);
            Assert.AreEqual(19, expected);
        }    
        [TestMethod]
        public void Addition_OfTwoPolynomial()
        {
            Polynomial first = new Polynomial(5, 7);
            Polynomial second = new Polynomial(-5, -7);

            Polynomial result = first + second;
            Assert.AreEqual(0, result.ResultOfPolynomial(1));
        }
         [TestMethod]
        public void Addition_OfPolynomialAndNumber()
        {
            Polynomial first = new Polynomial(5, 7);
            Polynomial result = -5 + first;
            Assert.AreEqual(7, result.ResultOfPolynomial(1));
        }
         [TestMethod]
         [ExpectedException(typeof(ArgumentNullException))]
         public void Addition_OfPolynomialAndNUll()
         {
             Polynomial first = new Polynomial(5, 7);
             Polynomial result = null + first;
             Assert.AreEqual(7, result.ResultOfPolynomial(1));
         }
         [TestMethod]
         public void Reduce_OfTwoPolynomial()
         {
             Polynomial first = new Polynomial(5, 7);
             Polynomial second = new Polynomial(5, 7);

             Polynomial result = first - second;
             Assert.AreEqual(0, result.ResultOfPolynomial(1));
         }
         [TestMethod]
         public void Reduce_OfPolynomialAndNumber()
         {
             Polynomial first = new Polynomial(5, 7);
             Polynomial result = 5 - first;

             Assert.AreEqual(7, result.ResultOfPolynomial(1));
         }
         [TestMethod]
         public void Multiply_OfPolynomialAndNumber()
         {
             Polynomial first = new Polynomial(5, 7);
             Polynomial result = 3 * first;

             Assert.AreEqual(36, result.ResultOfPolynomial(1));
         }
         [TestMethod]
         [ExpectedException(typeof(ArgumentNullException))]
         public void Multiply_OfPolynomialAndNUll()
         {
             Polynomial first = null;

             Polynomial result = 5 * first;
             Assert.AreEqual(7, result.ResultOfPolynomial(1));
         }
        [TestMethod]
        public void GetHashCodeOfTwoSamePolynomials()
         {
             Polynomial first = new Polynomial( 4, 8);
             Polynomial second = first.Clone();

             Assert.AreEqual(first.GetHashCode(), second.GetHashCode());
         }
         [TestMethod]
        public void GetHashCodeOfTwoDifferentPolynomials()
        {
            Polynomial first = new Polynomial(4, 8);
            Polynomial second = new Polynomial();

            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }
    }
}
