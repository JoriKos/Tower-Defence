using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _health, _speed, _value;

    //No set, any modifiers must be applied in the calculation
    public float Value { get { return _value; } }
    [SerializeField] private Nodes _nodes;
    private GameObject _nextNode;

    private void Awake()
    {
        if (_nodes == null)
            _nodes = GameObject.Find("Nodes").GetComponent<Nodes>();
        
        _nextNode = _nodes.NodeList[0];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextNode.transform.position, _speed * Time.deltaTime);

        if (transform.position == _nextNode.transform.position)
        {
            // If the index of the current node is the same as the count of the List minus 1 (does not start at 0) is equal, then we just make the current target the "next" target
            _nextNode = (_nodes.NodeList.IndexOf(_nextNode) != _nodes.NodeList.Count - 1) ? _nodes.NodeList[_nodes.NodeList.IndexOf(_nextNode) + 1] : _nodes.NodeList[_nodes.NodeList.IndexOf(_nextNode)];
        }
    }
}