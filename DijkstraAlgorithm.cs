using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class DijkstraAlgorithm
    {
        private Dictionary<string, float> _costs;
        private Dictionary<string, string> _parents;
        private Dictionary<string, Dictionary<string, float>> _graph;
        private List<string> _processedNodes;

        public DijkstraAlgorithm(Dictionary<string, Dictionary<string, float>> graph, Dictionary<string, float> costs, Dictionary<string, string> parents)
        {
            _graph = graph;
            _costs = costs;
            _parents = parents;
            _processedNodes = new List<string>();
        }

        public float Search()
        {
            string lowestCostNode = FindLowestCostNode(_costs);
            while (lowestCostNode != null)
            {
                var cost = _costs[lowestCostNode];
                var neighbors = _graph[lowestCostNode];
                foreach (var node in neighbors.Keys)
                {
                    var newCost = cost + neighbors[node];
                    if (_costs[node] > newCost)
                    {
                        _costs[node] = newCost;
                        _parents[node] = lowestCostNode;
                    }
                }
                
                _processedNodes.Add(lowestCostNode);
                lowestCostNode = FindLowestCostNode(_costs);
            }

            return _costs["fin"];
        }

        private string FindLowestCostNode(Dictionary<string, float> costs)
        {
            float lowestCost = float.PositiveInfinity;
            string lowestNode = null;

            foreach (var node in costs.Keys)
            {
                float cost = costs[node];
                if (cost < lowestCost && !CheckProcessedNode(node))
                {
                    lowestCost = cost;
                    lowestNode = node;
                }
            }

            return lowestNode;
        }

        private bool CheckProcessedNode(string node)
        {
            for (int i = 0; i < _processedNodes.Count; i++)
            {
                if (node == _processedNodes[i])
                    return true;
            }

            return false;
        }
    }
}