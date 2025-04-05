using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    [SerializeField] private int _nodeCount;
    [SerializeField] private List<GameObject> _nodes = new();
    public List<GameObject> NodeList { get; private set; }

    private void Awake()
    {

        for (int i = 0; i < _nodeCount; i++)
        {
            GameObject node = GameObject.Find("Node " + i);
            _nodes.Add(node);
        }
    }
}
