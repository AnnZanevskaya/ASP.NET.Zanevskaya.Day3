using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private double[] coefficients;
        public Polynomial()
        {
            coefficients = new double[1];
            coefficients[0] = 1;
        }
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        public static Polynomial operator +(Polynomial firstP, Polynomial secondP)
        {
            if (firstP == null) throw new ArgumentNullException("firstP");
            if (secondP == null) throw new ArgumentNullException("secondSP");
            Polynomial sumP, tempP;
            if (firstP.coefficients.Length > secondP.coefficients.Length)
            {
                sumP = Copy(firstP);
                tempP = secondP;
            }
            else
            {
                sumP = Copy(secondP);
                tempP = firstP;
            }
            for (int i = 0; i < tempP.coefficients.Length; i++)
            {
                sumP[i] += tempP[i];
            }
            return sumP;
        }
        public static Polynomial operator +(Polynomial firstP, double number)
        {
            Polynomial sum = Copy(firstP);
            sum[0] += number;
            return sum;
        }
        public static Polynomial Add(Polynomial firstP, Polynomial secondP)
        {
            return firstP + secondP;
        }
        public static Polynomial Add(Polynomial firstP, double number)
        {
            return firstP + number;
        }
        public static Polynomial operator -(Polynomial firstP)
        {
            if (firstP == null) throw new ArgumentNullException("firstP");
            Polynomial negativeP = Copy(firstP);
            for (int i = 0; i < negativeP.coefficients.Length; i++)
            {
                negativeP[i] *= -1;
            }
            return negativeP;
        }
        public static Polynomial operator -(Polynomial firstP, Polynomial secondP)
        {
            if (firstP == null) throw new ArgumentNullException("firstP");
            if (secondP == null) throw new ArgumentNullException("secondSP");
            return firstP + (-secondP);
        }
        public static Polynomial operator -(Polynomial firstP, double number)
        {
            number *= -1;
            return firstP + number;
        }
        public static Polynomial Subtract(Polynomial firstP, Polynomial secondP)
        {
            return firstP - secondP;
        }
        public static Polynomial Subtract(Polynomial firstP, double number)
        {
            return firstP - number;
        }
        public static Polynomial operator *(Polynomial firstP, double number)
        {
            Polynomial sum = Copy(firstP);
            for (int i = 0; i < sum.coefficients.Length; i++)
			{
                sum[i] *= number;
			}
            return sum;
        }
        public static Polynomial Multiply(Polynomial firstP, double number)
        {
            return firstP * number;
        }
        public object Clone()
        {
            return new Polynomial(this.coefficients);
        }
        public bool Equals(Polynomial other)
        {
            if (other == null) return false;
            if (this.coefficients.Length != other.coefficients.Length) return false;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this[i] != other[i]) return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            if (coefficients.Length > 1) return false;
            if (obj.GetType() != typeof(int) && obj.GetType() != typeof(double)) return false;
            if (obj.GetType() == typeof(int) && this.coefficients[0] == (int)obj) return true;
            if (obj.GetType() == typeof(double) && this.coefficients[0] == (double)obj) return true;
            return false;
        }
        public override int GetHashCode()
        {
            return coefficients.GetHashCode();
        }
        private static Polynomial Copy(Polynomial firstP)
        {
            double[] copyCoeff = new double[firstP.coefficients.Length];
            Polynomial copyP = new Polynomial(copyCoeff);
            for (int i = 0; i < firstP.coefficients.Length; i++)
            {
                copyP[i] = firstP[i];
            }
            return copyP;
        }
        private double this[int i]
        {
            get
            {
                if (i > coefficients.Length - 1) throw new ArgumentOutOfRangeException();
                return coefficients[i];
            }
            set
            {
                if (i > coefficients.Length - 1) throw new ArgumentOutOfRangeException();
                coefficients[i] = value;
            }
        
        }
    }
}
