using System;

namespace Aufgabe1
{
    internal class Vector3<T>
    {
        public T x, y, z;

        public delegate T OperationaufT(T a, T b);

        public static OperationaufT FieldAdd;
        public static OperationaufT FieldMul;

        public static Vector3<T> Add(Vector3<T> v1, Vector3<T> v2)
        {
            return new Vector3<T>
            {
                x = FieldAdd(v1.x, v2.x),
                y = FieldAdd(v1.y, v2.y),
                z = FieldAdd(v1.z, v2.z)
            };
        }

        public static Vector3<T> Mul(T scalar, Vector3<T> v)
        {
            return new Vector3<T>
            {
                x = FieldMul(scalar, v.x),
                y = FieldMul(scalar, v.y),
                z = FieldMul(scalar, v.z)
            };
        }
    }

    internal class Program
    {
        private static double DoubleMul(double a, double b)
        {
            return a*b;
        }

        private static double DoubleAdd(double a, double b)
        {
            return a + b;
        }

        private static void Main(string[] args)
        {
            Vector3<double>.FieldAdd = delegate(double a, double b)
            {
                return a + b;
            };

            Vector3<double>.FieldMul = (a, b) => a*b;

            var v1 = new Vector3<double> {x = 1.0, y = 2.0, z = 3.0};
            var v2 = new Vector3<double> {x = 4.0, y = 5.0, z = 6.0};

            var v3 = Vector3<double>.Add(v1, v2);
            var v4 = Vector3<double>.Mul(2.0, v1);


            Console.ReadKey();
        }
    }
}
