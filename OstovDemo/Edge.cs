using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstovDemo
{
    public class Edge
    {
        private Verticle _A;
        private Verticle _B;
        private int weight;

        public Verticle A {get { return _A; } private set{ _A = value; }}

        public Verticle B { get { return _B; } private set { _B = value; } }

        public Edge(Verticle A1, Verticle B1)
        {
            Random rnd = new Random();
            this.weight = rnd.Next() % 50; // maxweigt = 50;
            this.A = A1;
            this.B = B1;
        }

        public Edge(Verticle A1, Verticle B1, int _weight)
        {
            this.weight = _weight;
            this.A = A1;
            this.B = B1;
        }


        public Edge(Edge edge)
        {
            this.weight = edge.GetWeight();
            this.A = edge.A;
            this.B = edge.B;
        }

        public int GetWeight()
        {
            return weight;
        }

        public void SetVerticles(Verticle A, Verticle B)
        {
            
        }

        public override bool Equals(object obj)
        {


            return base.Equals(obj);
        }

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}
