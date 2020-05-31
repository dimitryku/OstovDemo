using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstovDemo
{
    public class Edge
    {
        private Verticle A, B;
        private int weight;

        public Edge(Verticle _A, Verticle _B)
        {
            Random rnd = new Random();
            weight = rnd.Next() % 50; // maxweigt = 50;
            A = _A;
            B = _B;
        }

        public Edge(Verticle _A, Verticle _B, int _weight)
        {
            weight = _weight;
            A = _A;
            B = _B;
        }


        public Edge(Edge edge)
        {

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
