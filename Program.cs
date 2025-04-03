// See https://aka.ms/new-console-template for more information
var graph = new Dictionary<int, List<(int, int)>>()
{
	{ 0, new List<(int, int)> { (1, 4), (2, 1) } },
	{ 1, new List<(int, int)> { (3, 1) } },
	{ 2, new List<(int, int)> { (1, 2), (3, 5) } },
	{ 3, new List<(int, int)>() }
};

// Print the graph
foreach (var node in graph)
{
	Console.Write($"Node {node.Key} -> ");
	foreach (var (neighbor, weight) in node.Value)
		Console.Write($"({neighbor}, {weight}) ");
	Console.WriteLine();
}

Console.ReadLine();

