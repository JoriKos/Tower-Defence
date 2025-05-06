using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private List<GameObject> _towers = new();
    [SerializeField] private GameObject _currentTower;

    public GameObject CurrentTower { private set { /* do nothing */ } get { return _currentTower; } }

    public void SetTower(GameObject tower)
    {
        _currentTower = tower;
    }
}
