using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, float>> graph = new Dictionary<string, Dictionary<string, float>>
            {
                ["start"] = new Dictionary<string, float>
                {
                    ["a"] = 6, 
                    ["b"] = 2
                },
                ["a"] = new Dictionary<string, float>
                {
                    ["fin"] = 1
                },
                ["b"] = new Dictionary<string, float>
                {
                    ["a"] = 3,
                    ["fin"] = 5
                }, 
                ["fin"] = new Dictionary<string, float>()
            };

            float infinity = float.PositiveInfinity;
            Dictionary<string, float> costs = new Dictionary<string, float>()
            {
                ["a"] = 6,
                ["b"] = 2,
                ["fin"] = infinity
            };


            Dictionary<string, string> parents = new Dictionary<string, string>()
            {
                ["a"] = "start",
                ["b"] = "start",
                ["fin"] = null
            };

            DijkstraAlgorithm dijkstraAlgorithm = new DijkstraAlgorithm(graph, costs, parents);
            Console.WriteLine($"Minimum path cost = {dijkstraAlgorithm.Search()}");
        }
    }
}