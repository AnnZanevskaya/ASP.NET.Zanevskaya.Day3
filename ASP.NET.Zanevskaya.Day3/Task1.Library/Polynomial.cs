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
        private int degree = 0;
        public int Degree {
            get 
            {
                return this.coefficients.Length - 1; 
            }    
        }
        public Polynomial()
        {
            coefficients = new double[1];
            coefficients[0] = 1;
        }
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }
        public double ResultOfPolynomial(double variable)
        {          
            double result = 0;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                result += this[i] * Math.Pow(variable, i);
            }
            return result;
        }
        public static Polynomial operator +(Polynomial firstP, Polynomial secondP)
        {
            if ((object)firstP == null) throw new ArgumentNullException("firstP");
            if ((object)secondP == null) throw new ArgumentNullException("secondSP");
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
            if ((object)firstP == null) throw new ArgumentNullException("firstP");
            Polynomial sum = Copy(firstP);
            sum[0] += number;
            return sum;
        }
        public static Polynomial operator +(double number, Polynomial firstP)
        {
            return firstP + number;
        }
        public static Polynomial Add(Polynomial firstP, Polynomial secondP)
        {
            return firstP + secondP;
        }
        public static Polynomial Add(Polynomial firstP, double number)
        {
            return firstP + number;
        }
        public static Polynomial Add(double number, Polynomial firstP)
        {
            return firstP + number;
        }
        public static Polynomial operator -(Polynomial firstP)
        {
            if ((object)firstP == null) throw new ArgumentNullException("firstP");
            Polynomial negativeP = Copy(firstP);
            for (int i = 0; i < negativeP.coefficients.Length; i++)
            {
                negativeP[i] *= -1;
            }
            return negativeP;
        }
        public static Polynomial operator -(Polynomial firstP, Polynomial secondP)
        {
            return firstP + (-secondP);
        }
        public static Polynomial operator -(Polynomial firstP, double number)
        {
            number *= -1;
            return firstP + number;
        }
        public static Polynomial operator -(double number, Polynomial firstP)
        {
            Polynomial sum = Copy(firstP);
            sum[0] = -1 *sum[0];
            return sum + number;
        }
        public static Polynomial Subtract(Polynomial firstP, Polynomial secondP)
        {
            return firstP - secondP;
        }
        public static Polynomial Subtract(Polynomial firstP, double number)
        {
            return firstP - number;
        }
        public static Polynomial Subtract(double number, Polynomial firstP)
        {
            return number - firstP;
        }
        public static Polynomial operator *(Polynomial firstP, double number)
        {
            if ((object)firstP == null) throw new ArgumentNullException("firstP");
            Polynomial sum = Copy(firstP);
            for (int i = 0; i < sum.coefficients.Length; i++)
			{
                sum[i] *= number;
			}
            return sum;
        }
        public static Polynomial operator *(double number, Polynomial firstP)
        {
            return firstP * number;
        }
        public static Polynomial Multiply(Polynomial firstP, double number)
        {
            return firstP * number;
        }
        public static Polynomial Multiply(double number, Polynomial firstP)
        {
            return firstP * number;
        }
        public bool Equals(Polynomial other)
        {
            if ((object)other == null) throw new ArgumentNullException("NULL");
            if (this.coefficients.Length != other.coefficients.Length) return false;
            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (this[i] != other[i]) return false;
            }
            return true;
        }
        public static bool operator ==(Polynomial firstP, Polynomial secondP)
        {    
            return firstP.Equals(secondP);
        }
        public static bool operator ==(Polynomial firstP, double number)
        {
            return firstP.Equals(number);
        }
        public static bool operator ==(double number, Polynomial firstP)
        {
            return firstP.Equals(number);
        }
        public static bool operator !=(Polynomial firstP, Polynomial secondP)
        {
            return !firstP.Equals(secondP);
        }
        public static bool operator !=(Polynomial firstP, double number)
        {
            return !firstP.Equals(number);
        }
        public static bool operator !=(double number, Polynomial firstP)
        {
            return !firstP.Equals(number);
        }
        public override bool Equals(object obj)
        {
            if ((object)obj == null) throw new ArgumentNullException("NULL"); ;
            if (coefficients.Length > 1) return false;
            if (obj.GetType() != typeof(int) && obj.GetType() != typeof(double)) return false;
            if (obj.GetType() == typeof(int) && this.coefficients[0] == (int)obj) return true;
            if (obj.GetType() == typeof(double) && this.coefficients[0] == (double)obj) return true;
            return false;
        }
        public override string ToString()
        {
             string result = null;
             for (int i = 0; i < this.coefficients.Length; i++)
			{
                if (this[i] != 0)
                {
                    result += +this.coefficients[i] + "x^" + i;
                    if (i + 1 < this.coefficients.Length) result += "+";
                }
			}        
           return result;
        }

        //don't sure work's as need :/
        public override int GetHashCode()
        {
            return coefficients.GetHashCode();
        }
        public Polynomial Clone()
        {
            return new Polynomial(this.coefficients);
        }
        object ICloneable.Clone()
        {
            return new Polynomial(this.coefficients);
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
