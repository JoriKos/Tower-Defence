using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;

    private void Awake()
    {
        _target = GameObject.Find("AttackingObject");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        //transform.position += -transform.forward * Time.deltaTime * _speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
