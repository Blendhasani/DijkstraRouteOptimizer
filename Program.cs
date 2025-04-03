// See https://aka.ms/new-console-template for more information
using DijkstraRouteOptimizer;

var graph = new Dictionary<int, List<(int, int)>>()
{
	{ 0, new List<(int, int)> { (1, 4), (2, 1) } },
	{ 1, new List<(int, int)> { (3, 1) } },
	{ 2, new List<(int, int)> { (1, 2), (3, 5) } },
	{ 3, new List<(int, int)>() }
};


var distances = Dijkstra.FindShortestPaths(graph, 0);

// Printimi i rezultatit per te treguar se struktura funksionon
foreach (var kvp in distances)
	Console.WriteLine($"Shortest distance from 0 to {kvp.Key} is {kvp.Value}");
Console.ReadLine();

