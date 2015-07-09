using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aufgabe2
{
    internal class Program
    {
        private const int Vertexcount = 5000000;
        private static vertexS[] _verticesS;
        private static vertexC[] _verticesC;
        private static vertexS[] _verticesSp;
        private static vertexC[] _verticesCp;
        private static readonly Random Rnd = new Random();

        private static double _test1Time;
        private static double _test2Time;
        private static double _test3Time;
        private static double _test4Time;

        private static void Main(string[] args)
        {
            _verticesS = new vertexS[Vertexcount];
            _verticesC = new vertexC[Vertexcount];

            _verticesSp = new vertexS[Vertexcount];
            _verticesCp = new vertexC[Vertexcount];

            var watch = new Stopwatch();
            watch.Start();
            InitStructs();
            watch.Stop();
            _test1Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitClasses();
            watch.Stop();
            _test2Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitStructsParallel();
            watch.Stop();
            _test3Time = watch.ElapsedMilliseconds;
            watch.Reset();

            watch.Start();
            InitClassesParallel();
            watch.Stop();
            _test4Time = watch.ElapsedMilliseconds;
            watch.Reset();


            Console.WriteLine("Building " + Vertexcount + " struct based vertices took " + _test1Time + " milliseconds.");
            Console.WriteLine("Building " + Vertexcount + " class based vertices took " + _test2Time + " milliseconds.");

            Console.WriteLine("Structs were " + _test2Time/_test1Time + " times faster.");

            Console.WriteLine("");

            Console.WriteLine("Building " + Vertexcount + " struct based vertices took " + _test3Time + " milliseconds. (Parallel)");
            Console.WriteLine("Building " + Vertexcount + " class based vertices took " + _test4Time + " milliseconds. (Parallel)");

            Console.WriteLine("Structs were " + _test4Time / _test3Time + " times faster.");

            Console.ReadKey();
        }

        private static void InitStructs()
        {
            for (var i = 0; i < Vertexcount; i++)
            {
                _verticesS[i].normal.x = (float)Rnd.NextDouble();
                _verticesS[i].normal.y = (float)Rnd.NextDouble();
                _verticesS[i].normal.z = (float)Rnd.NextDouble();

                _verticesS[i].position.x = (float)Rnd.NextDouble();
                _verticesS[i].position.y = (float)Rnd.NextDouble();
                _verticesS[i].position.z = (float)Rnd.NextDouble();

                _verticesS[i].texcoord.u = (float)Rnd.NextDouble();
                _verticesS[i].texcoord.v = (float)Rnd.NextDouble();
            }
        }
        private static void InitStructsParallel()
        {
            Parallel.For(0, Vertexcount, i =>
            {
                _verticesSp[i].normal.x = (float)Rnd.NextDouble();
                _verticesSp[i].normal.y = (float)Rnd.NextDouble();
                _verticesSp[i].normal.z = (float)Rnd.NextDouble();

                _verticesSp[i].position.x = (float)Rnd.NextDouble();
                _verticesSp[i].position.y = (float)Rnd.NextDouble();
                _verticesSp[i].position.z = (float)Rnd.NextDouble();

                _verticesSp[i].texcoord.u = (float)Rnd.NextDouble();
                _verticesSp[i].texcoord.v = (float)Rnd.NextDouble();
            });
        }

        private static void InitClasses()
        {
            for (var i = 0; i < Vertexcount; i++)
            {
                _verticesC[i] = new vertexC();

                _verticesC[i].normal = new vector3C();
                _verticesC[i].normal.x = (float)Rnd.NextDouble();
                _verticesC[i].normal.y = (float)Rnd.NextDouble();
                _verticesC[i].normal.z = (float)Rnd.NextDouble();

                _verticesC[i].position = new vector3C();
                _verticesC[i].position.x = (float)Rnd.NextDouble();
                _verticesC[i].position.y = (float)Rnd.NextDouble();
                _verticesC[i].position.z = (float)Rnd.NextDouble();

                _verticesC[i].texcoord = new uv2C();
                _verticesC[i].texcoord.u = (float)Rnd.NextDouble();
                _verticesC[i].texcoord.v = (float)Rnd.NextDouble();
            }
        }
        private static void InitClassesParallel()
        {
            Parallel.For(0, Vertexcount, i =>
            {
                _verticesCp[i] = new vertexC();

                _verticesCp[i].normal = new vector3C();
                _verticesCp[i].normal.x = (float) Rnd.NextDouble();
                _verticesCp[i].normal.y = (float) Rnd.NextDouble();
                _verticesCp[i].normal.z = (float) Rnd.NextDouble();

                _verticesCp[i].position = new vector3C();
                _verticesCp[i].position.x = (float) Rnd.NextDouble();
                _verticesCp[i].position.y = (float) Rnd.NextDouble();
                _verticesCp[i].position.z = (float) Rnd.NextDouble();

                _verticesCp[i].texcoord = new uv2C();
                _verticesCp[i].texcoord.u = (float) Rnd.NextDouble();
                _verticesCp[i].texcoord.v = (float) Rnd.NextDouble();
            });
        }

        public static float ReadClasses(vertexC[] vc)
        {
            float calc = 0;

            for (int i = 0; i < vc.Length; i++)
            {
                var cal = (vc[i].position.x + vc[i].position.x + vc[i].position.x) / 3;
                calc = (cal + calc) / 2;
            }

            return calc;
        }
        public static float ReadStructs(vertexS[] vs)
        {
            float calc = 0;

            for (int i = 0; i < vs.Length; i++)
            {
                var cal = (vs[i].position.x + vs[i].position.x + vs[i].position.x) / 3;
                calc = (cal + calc) / 2;
            }

            return calc;
        }


        public struct uv2S
        {
            public float u;
            public float v;
        }

        public struct vector3S
        {
            public float x;
            public float y;
            public float z;
        }

        public struct vertexS
        {
            public vector3S position;
            public vector3S normal;
            public uv2S texcoord;
        }

        public class uv2C
        {
            public float u;
            public float v;
        }

        public class vector3C
        {
            public float x;
            public float y;
            public float z;
        }

        public class vertexC
        {
            public vector3C position;
            public vector3C normal;
            public uv2C texcoord;
        }
    }
}
