using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Awake()
    {
        _target = GameObject.Find("AttackingObject");
    }

    void Update()
    {
        Vector3 rot = Quaternion.LookRotation(_target.transform.position - transform.position).eulerAngles;
        rot.x = rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
