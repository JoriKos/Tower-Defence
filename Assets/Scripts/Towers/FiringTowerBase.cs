using System;
using System.Collections;
using UnityEngine;

public class FiringTowerBase : MonoBehaviour
{
    [SerializeField] private Transform _projectileOrigin;
    [SerializeField] private float _fireRate;
    [SerializeField] private string _poolName;
    [SerializeField] private TowerFollow _tFollow;
    private ObjectPooling _pPool;
    private bool _hasTarget, _canFire;

    public bool HasTarget { get { return _hasTarget; } set { _hasTarget = value; } }

    private void Awake()
    {
        _canFire = true;
        //This is stupid but otherwise we can't assign the object pooling
        _pPool = GameObject.Find(_poolName).GetComponent<ObjectPooling>();
    }

    private void Update()
    {
        if (_hasTarget && _canFire)
        {
            StartCoroutine(Fire());
            _canFire = false;
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(_fireRate);
        
        //Get object from pool, set false to avoid "no target assigned" errors as that's done later
        GameObject p = _pPool.GetObject(false);

        //If possible, find a way to have no GetComponent here
        //Separate targeter entirely, take it from TowerFollow.cs and move it to its own script
        ProjectileBase b = p.GetComponent<ProjectileBase>();

        //Set the TowerFollow (keeps track of Target) to be that of this tower
        b.TFollow = _tFollow;

        //Set position to origin and set rotation towards target
        Vector3 rot = Quaternion.LookRotation(transform.position - _projectileOrigin.transform.position).eulerAngles;
        p.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot));
        _canFire = true;

        //Set projectile active
        p.SetActive(true);
    }
}
