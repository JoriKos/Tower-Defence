using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject _objectPool;
    [SerializeField] private Queue<GameObject> _objectPooler = new();
    public Queue<GameObject> ObjectPooler { get { return _objectPooler; } }
    [SerializeField] private int _poolStartSize;
    [SerializeField] private bool _activeOnStart = false;
    public int PoolStartSize { get { return _poolStartSize; } }

    // Game starts, create pool
    private void Awake()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            GameObject obstacle = Instantiate(_objectPool);
            obstacle.transform.parent = transform;
            _objectPooler.Enqueue(obstacle);
            obstacle.SetActive(_activeOnStart);
        }
    }

    // Enable object. If no object is available, spawn a new one
    public GameObject GetObstacle(bool setActiveImmediately = true)
    {
        if (_objectPooler.Count > 0)
        {
            GameObject obstacle = _objectPooler.Dequeue();
            obstacle.SetActive(setActiveImmediately);
            return obstacle;
        }
        else
        {
            GameObject obstacle = Instantiate(_objectPool);
            obstacle.transform.parent = transform;
            _objectPooler.Enqueue(obstacle);
            obstacle.SetActive(setActiveImmediately);
            return obstacle;
        }
    }

    //Zet object terug in de queue
    public void ReturnObstacle(GameObject collison)
    {
        _objectPooler.Enqueue(collison);
        collison.SetActive(false);
    }
}