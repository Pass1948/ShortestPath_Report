namespace ShortestPath_Report
{
    internal class Program
    {
        const int INF = 99999;
        static void Main(string[] args)
        {
            int[,] graph = new int[8, 8]
            {
                {   0,   3,   4, INF,   4, INF, INF, INF},
                {   3,   0, INF,   7, INF,   9,   7, INF},
                {   4, INF,   0, INF,   3,   2, INF, INF},
                { INF,   7, INF,   0, INF,   3, INF, INF},
                {   4, INF,   3, INF,   0, INF,   8,   4},
                { INF,   9,   2,   3, INF,   0,   9,   3},
                { INF,   7, INF, INF,   8,   9,   0, INF},
                { INF, INF, INF, INF,   4,   3, INF,   0}
            };

            int[] distance;
            int[] path;
            Dijkstra.ShortestPath(in graph, 0, out distance, out path);
            Console.WriteLine("<Dijkstra>");
            PrintDijkstra(distance, path);

            Console.WriteLine();
        }

        private static void PrintDijkstra(int[] distance, int[] path)
        {
            Console.Write("Vertex");
            Console.Write("\t");
            Console.Write("dist");
            Console.Write("\t");
            Console.WriteLine("path");

            for (int i = 0; i < distance.Length; i++)
            {
                Console.Write("{0,3}", i);
                Console.Write("\t");
                if (distance[i] >= INF)
                    Console.Write("INF");
                else
                    Console.Write("{0,3}", distance[i]);
                Console.Write("\t");
                if (path[i] < 0)
                    Console.WriteLine("  X ");
                else
                    Console.WriteLine("{0,3}", path[i]);
            }
        }
    }
}