using System.Collections.Generic;
using UnityEngine;

public class TowerFollow : MonoBehaviour
{
    [SerializeField] private FiringTowerBase _bFire;
    private List<GameObject> _targetsInRange = new();
    [SerializeField] private GameObject _target;

    public GameObject Target { get { return _target; } }

    void Update()
    {
        //Find closest target
        _target = FindTarget();

        if (_target)
        {
            //Send to FiringTowerBase that we have a target
            _bFire.HasTarget = true;

            //Rotate to look at target on Y axis only
            Vector3 rot = Quaternion.LookRotation(_target.transform.position - transform.position).eulerAngles;
            rot.x = rot.z = 0;
            transform.rotation = Quaternion.Euler(rot);
        }
        else
            _bFire.HasTarget = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }

    private GameObject FindTarget()
    {
        GameObject target = null;
        //First enemy is always closest
        float closestDist = Mathf.Infinity;

        foreach (GameObject item in _targetsInRange)
        {
            //Calculate closest enemy
            if (Vector3.Distance(transform.position, item.transform.position) < closestDist)
            {
                //Set closest distance to distance between the 
                closestDist = Vector3.Distance(transform.position, item.transform.position);
                
                if (item.activeInHierarchy)
                    target = item;
            }
        }

        return target;
    }

    //When enemy is in the sphere trigger, add to List
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            _targetsInRange.Add(other.gameObject);
    }

    //When enemy leaves the sphere trigger, remove from List
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            _targetsInRange.Remove(other.gameObject);
    }
}
