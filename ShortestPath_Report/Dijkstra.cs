using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath_Report
{
    internal class Dijkstra
    {
        const int INF = 99999;      // 단절을 상수로 구현 // 99999는 오버플로우를 방지하기위해 설정한 값

        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        // distance는 거리(가중치)
        {
            //============초기화============
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
            }
            //=============================

            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;                            // 가장 작은값은 가진 정점으로 갱신하기위한 변수
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] && distance[j] < minCost) // 방문하지않았으면서 가장 거리가 짧은곳
                    {
                        next = j;                             // 방문 갱신
                        minCost = distance[j];                // 가중치 갱신
                    }
                }
                if (next < 0)
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // distance[j] : 목적지까지 직접 연결된 거리
                    // distance[next] : 탐색중인 정점까지 거리 (해당정점->next : 거치는정점까지 거리)
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리 (next->j : 거치는정점부터 목적지까지 거리)
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
