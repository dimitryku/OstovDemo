namespace OstovDemo
{
    public enum Condition
    {
        Waiting,
        Checking,
        Accept
    }

    public class Edge
    {
        public Edge(Verticle A, Verticle B, int weight)
        {
            this.weight = weight;
            this.A = A;
            this.B = B;
            condition = Condition.Waiting;
        }

        public Edge(Edge edge)
        {
            weight = edge.weight;
            A = edge.A;
            B = edge.B;
            condition = Condition.Waiting;
        }

        public Verticle A { get; set; }

        public Verticle B { get; set; }

        public int weight { get; set; }

        public Condition condition { get; set; }

        public float weightPosition { get; set; }

        public override bool Equals(object obj)
        {
            var newEdge = obj as Edge;
            if (newEdge == null) return false;
            if (A == newEdge.A && B == newEdge.B || B == newEdge.A && A == newEdge.B)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            var code = weight;
            var i = 1;
            foreach (var c in A.name)
            {
                code += c * i;
                i += 1;
            }

            foreach (var c in B.name)
            {
                code += c * i;
                i += 1;
            }

            return code;
        }

        public override string ToString()
        {
            return A.name + " - " + B.name + " (" + weight + ") ";
        }
    }
}