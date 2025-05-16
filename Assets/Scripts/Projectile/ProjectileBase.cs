using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private ObjectPooling _pool;
    private TowerFollow _tFollow;
    private GameObject _target;

    public TowerFollow TFollow { set { _tFollow = value; } get { return _tFollow; } }

    private void Awake()
    {
        _pool = transform.parent.GetComponent<ObjectPooling>();
    }

    private void Update()
    {
        if (_target)
        {
            if (_target.activeInHierarchy)
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            else
                _pool.ReturnObject(gameObject);
        }
        else
            _pool.ReturnObject(gameObject);

        //transform.position += -transform.forward * Time.deltaTime * _speed;
    }


    private void OnEnable()
    {
        _target = _tFollow.Target;
    }

    private void OnDisable()
    {
        //Prevent possible unassigned reference errors
        _target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<AttackerBase>().Health -= _damage;
            _pool.ReturnObject(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
