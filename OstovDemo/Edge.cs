using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstovDemo
{
    public class Edge
    {

        public Verticle A { get; set; }

        public Verticle B { get; set; }

        public int weight { get; set; }

        public Edge(Verticle A, Verticle B)
        {
            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            this.weight = rnd.Next() % 50; // maxweight = 50;
            this.A = A;
            this.B = B;
        }

        public Edge(Verticle A, Verticle B, int weight)
        {
            this.weight = weight;
            this.A = A;
            this.B = B;
        }

        public Edge(Edge edge)
        {
            this.weight = edge.weight;
            this.A = edge.A;
            this.B = edge.B;
        }

        public override bool Equals(object obj)
        {
            Edge newEdge = obj as Edge;
            if (newEdge == null) return false;
            if ((this.A == newEdge.A && this.B == newEdge.B) || (this.B == newEdge.A && this.A == newEdge.B))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            int code = this.weight;
            int i = 1;
            foreach (Char c in this.A.name) { code += ((int)c * i); i += 1; }
            foreach (Char c in this.B.name) { code += ((int)c * i); i += 1; }
            return code;
        }
    }
}
