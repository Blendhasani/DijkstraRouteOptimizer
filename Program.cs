using DijkstraRouteOptimizer;


var graph = new Dictionary<int, List<(int, int)>>()
{
    // Each key is a node, and the value is a list of (neighbor, weight)
    { 0, new List<(int, int)> { (1, 4), (2, 1) } },
	{ 1, new List<(int, int)> { (3, 1) } },
	{ 2, new List<(int, int)> { (1, 2), (3, 5) } },
	{ 3, new List<(int, int)>() } // Node 3 has no outgoing edges
};

// Print the graph structure
Console.WriteLine("Graph Representation (Adjacency List):");
foreach (var node in graph)
{
	Console.Write($"Node {node.Key} -> ");
	foreach (var (neighbor, weight) in node.Value)
		Console.Write($"({neighbor}, {weight}) ");
	Console.WriteLine();
}
Console.WriteLine(); // Empty line for spacing

// Run Dijkstra's algorithm from source node 0
var sourceNode = 0;
var distances = Dijkstra.FindShortestPaths(graph, sourceNode);

// Display shortest distances
Console.WriteLine($"Shortest distances from source node {sourceNode}:");
foreach (var kvp in distances)
{
	Console.WriteLine($"To node {kvp.Key} -> Distance: {kvp.Value}");
}


Console.WriteLine("\nGraph Visual (Simple View):");

foreach (var node in graph)
{
	foreach (var (neighbor, weight) in node.Value)
	{
		Console.WriteLine($"{node.Key} --{weight}--> {neighbor}");
	}

	// If a node has no outgoing edges
	if (node.Value.Count == 0)
		Console.WriteLine($"{node.Key} --x");
}


// Prevent console from closing immediately
Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
