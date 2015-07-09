using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    class Vector<T>
    {
        public T x, y, z;

        public static Vector<T> Add(Vector<T> v1, Vector<T> v2)
        {
            return new Vector<T>()
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y,
                z = v1.z + v2.z
            };
        }

        public static Vector<T> Mul(double scalar, Vector<T> v)
        {
            return new Vector<T>()
            {
                x = scalar*v.x,
                y = scalar*v.y,
                z = scalar*v.z
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector<double> v1 = new Vector<double>() {x = 1.0, y = 2.0, z = 3.0};
            Vector<double> v2 = new Vector<double>() {x = 4.0, y = 5.0, z = 6.0};

            Vector<double> v3 = Vector<double>.Add(v1, v2);
            Vector<double> v4 = Vector<double>.Mul(2.0, v1);

            Console.ReadKey();
        }
    }
}
