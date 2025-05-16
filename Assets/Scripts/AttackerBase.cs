using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBase : MonoBehaviour
{
    [SerializeField] private float _health, _speed;
    [SerializeField] private int _value;

    //No set, any modifiers must be applied in the calculation
    public float Value { get { return _value; } }
    public float Health { set { _health = value; } get { return _health; } }
    [SerializeField] private Nodes _nodes;
    private GameObject _nextNode;

    [SerializeField] private Economy _econ;
    [SerializeField] private ObjectPooling _pool;

    private void Start()
    {
        if (_nodes == null)
            _nodes = GameObject.Find("Nodes").GetComponent<Nodes>();
        
        _nextNode = _nodes.NodeList[0];

        _econ = GameObject.Find("GameManager").GetComponent<Economy>();
        _pool = transform.parent.GetComponent<ObjectPooling>();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextNode.transform.position, _speed * Time.deltaTime);

        if (transform.position == _nextNode.transform.position)
        {
            // If the index of the current node is the same as the count of the List minus 1 (does not start at 0) is equal, then we just make the current target the "next" target
            _nextNode = (_nodes.NodeList.IndexOf(_nextNode) != _nodes.NodeList.Count - 1) ? _nodes.NodeList[_nodes.NodeList.IndexOf(_nextNode) + 1] : _nodes.NodeList[_nodes.NodeList.IndexOf(_nextNode)];
        }

        if (_health <= 0)
        {
            _econ.AddMoney(_value);
            _pool.ReturnObject(gameObject);
        }
    }
}