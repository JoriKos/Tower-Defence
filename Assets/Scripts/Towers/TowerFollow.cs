using UnityEngine;

public class TowerFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private FiringTowerBase _bFire;

    private void Awake()
    {
        //Rework this
        _target = GameObject.Find("AttackingObject");
    }

    void Update()
    {
        //Look at target on Y axis only
        Vector3 rot = Quaternion.LookRotation(_target.transform.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);

        if (_target)
            _bFire.HasTarget = true;
        else
            _bFire.HasTarget = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
