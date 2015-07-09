using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    class Vector3
    {
        public double x, y, z;

        public static Vector3 Add(Vector3 v1, Vector3 v2)
        {
            return new Vector3()
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y,
                z = v1.z + v2.z
            };
        }

        public static Vector3 Mul(double scalar, Vector3 v)
        {
            return new Vector3()
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
            Vector3 v1 = new Vector3() {x = 1.0, y = 2.0, z = 3.0};
            Vector3 v2 = new Vector3() {x = 4.0, y = 5.0, z = 6.0};

            Vector3 v3 = Vector3.Add(v1, v2);
            Vector3 v4 = Vector3.Mul(2.0, v1);
        }
    }
}
