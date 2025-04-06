using DijkstraRouteOptimizer;


//var graph = new Dictionary<int, List<(int, int)>>()
//{
//    // Each key is a node, and the value is a list of (neighbor, weight)
//    { 0, new List<(int, int)> { (1, 4), (2, 1) } },
//	{ 1, new List<(int, int)> { (3, 1) } },
//	{ 2, new List<(int, int)> { (1, 2), (3, 5) } },
//	{ 3, new List<(int, int)>() } // Node 3 has no outgoing edges
//};


//Graph with Zero-Weight Edges test
//var graph = new Dictionary<int, List<(int, int)>> {
//	{ 0, new List<(int, int)> { (1, 2) } },
//	{ 1, new List<(int, int)>() },
//	{ 2, new List<(int, int)> { (3, 3) } },
//	{ 3, new List<(int, int)>() },
//	{ 4, new List<(int, int)>() }
//};


//Fully connected graph test
//var graph = new Dictionary<int, List<(int, int)>> {
//	{ 0, new List<(int, int)> { (1, 4), (2, 1) } },
//	{ 1, new List<(int, int)> { (3, 1) } },
//	{ 2, new List<(int, int)> { (1, 2), (3, 5) } },
//	{ 3, new List<(int, int)>() }
//};

//Test with 1000 nodes
var graph = GenerateRandomGraph(1000, 1000);
// Run Dijkstra's algorithm from source node 0
var sourceNode = 0;


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


var stopwatch = System.Diagnostics.Stopwatch.StartNew();
var distances = Dijkstra.FindShortestPaths(graph, sourceNode);
stopwatch.Stop();
Console.WriteLine($"Execution time: {stopwatch.ElapsedMilliseconds} ms");

// Display shortest distances
Console.WriteLine($"Shortest distances from source node {sourceNode}:");
foreach (var kvp in distances)
{
	if (kvp.Value == int.MaxValue)
		Console.WriteLine($"To node {kvp.Key} -> Distance: Not reachable");
	else
		Console.WriteLine($"To node {kvp.Key} -> Distance: {kvp.Value}");
}






static Dictionary<int, List<(int, int)>> GenerateRandomGraph(int numNodes, int numEdges)
{
	var rand = new Random();
	var graph = new Dictionary<int, List<(int, int)>>();

	// Initialize empty list for each node
	for (int i = 0; i < numNodes; i++)
		graph[i] = new List<(int, int)>();

	for (int i = 0; i < numNodes - 1; i++)
	{
		graph[i].Add((i + 1, rand.Next(1, 10))); // Connect each node to the next
	}

	return graph;
}



//Console.WriteLine("\nGraph Visual (Simple View):");

//foreach (var node in graph)
//{
//	foreach (var (neighbor, weight) in node.Value)
//	{
//		Console.WriteLine($"{node.Key} --{weight}--> {neighbor}");
//	}

//	// If a node has no outgoing edges
//	if (node.Value.Count == 0)
//		Console.WriteLine($"{node.Key} --x");
//}


// Prevent console from closing immediately
Console.WriteLine("\nPress Enter to exit...");
Console.ReadLine();
