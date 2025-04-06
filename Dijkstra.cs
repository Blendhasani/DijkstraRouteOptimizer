using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraRouteOptimizer
{
	public static class Dijkstra
	{
		// Method to find the shortest paths from the source node to all other nodes

		public static Dictionary<int, int> FindShortestPaths(Dictionary<int, List<(int neighbor, int weight)>> graph, int source)
		{
			// Initialize distances to all nodes as infinite (int.MaxValue)
			var distances = new Dictionary<int, int>();
			foreach (var node in graph.Keys)
				distances[node] = int.MaxValue;

			// Distance to the source node is 0
			distances[source] = 0;

			// Create a priority queue to hold (distance, node)
			var priorityQueue = new SortedSet<(int distance, int node)>();
			priorityQueue.Add((0, source));

			// Main loop - continue until all reachable nodes are processed
			while (priorityQueue.Any())
			{
				// Get the node with the smallest known distance
				var (currentDist, currentNode) = priorityQueue.First();

				priorityQueue.Remove(priorityQueue.First());

				// Check all neighbors of the current node
				foreach (var (neighbor, weight) in graph[currentNode])
				{
					// Calculate distance to neighbor through the current node
					int newDist = currentDist + weight;

					// If a shorter path is found, update it
					if (newDist < distances[neighbor])
					{
						// Remove the old entry if it exists
						priorityQueue.Remove((distances[neighbor], neighbor));
						
						// Update the distance and re-add the node with the new distance
						distances[neighbor] = newDist;
						priorityQueue.Add((newDist, neighbor));
					}
				}
			}

			// Return the dictionary of shortest distances from source
			return distances;

		}
	}
}
