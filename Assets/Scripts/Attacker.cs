using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _health, _speed;
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
            _nextNode = _nodes.NodeList[_nodes.NodeList.IndexOf(_nextNode) + 1];
        }
    }
}
