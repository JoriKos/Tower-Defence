using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private Economy _econ;
    
    //No set, any modifiers must be applied in the calculation
    public int Value { get { return _value; } }

    private void Awake()
    {
        _econ = GameObject.Find("GameManager").GetComponent<Economy>();
    }

    private void Start()
    {
        _value = _econ.TowerCost[gameObject.name];
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            _econ.AddMoney(_value);
            Destroy(gameObject);
        }
    }
}
