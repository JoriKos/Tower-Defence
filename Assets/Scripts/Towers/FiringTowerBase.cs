using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FiringTowerBase : MonoBehaviour
{
    [SerializeField] private Transform _projectileOrigin;
    [SerializeField] private float _fireRate;
    [SerializeField] private string _poolName;
    private ObjectPooling _pPool;
    private bool _hasTarget, _canFire;

    public bool HasTarget { get { return _hasTarget; } set { _hasTarget = value; } }

    private void Awake()
    {
        _canFire = true;
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
        GameObject p = _pPool.GetObstacle();
        Vector3 rot = Quaternion.LookRotation(transform.position - _projectileOrigin.transform.position).eulerAngles;
        p.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rot));
        _canFire = true;
    }
}
