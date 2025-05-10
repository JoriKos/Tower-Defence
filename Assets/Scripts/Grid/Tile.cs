using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColour, _offsetColour, _overrideColour;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TowerManager _towerManager;
    [SerializeField] private Transform _attachPoint;
    [SerializeField] private GameObject _currentTower;
    [SerializeField] private Economy _econ;
    [SerializeField] private bool _canPlaceOn;
    bool _isOffSet;

    private void Awake()
    {
        _gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        _towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        _econ = GameObject.Find("GameManager").GetComponent<Economy>();
    }

    public void SetColour(bool isOffSet)
    {
        _isOffSet = isOffSet;
        // Add override support
        _renderer.material.color = isOffSet ? _offsetColour : _baseColour;
    }

    private void OnMouseOver()
    {
        _renderer.material.color = Color.yellow;
        _gridManager.SelectedTile = this;
    }

    private void OnMouseExit()
    {
        _gridManager.SelectedTile = null;
        _renderer.material.color = _isOffSet ? _offsetColour : _baseColour;
    }

    private void OnMouseDown() 
    { 
        // Left click -> place currently selected tower
        
        if (Input.GetMouseButtonDown(0))
        {
            if (_towerManager.CurrentTower && !_currentTower && EventSystem.current.IsPointerOverGameObject() == false &&
                _econ.GetMoney() >= _econ.TowerCost[_towerManager.CurrentTower.name])
            {
                _currentTower = Instantiate(_towerManager.CurrentTower, _attachPoint.position, Quaternion.identity);
                _currentTower.name = _towerManager.CurrentTower.name;
                _econ.AddMoney(-_currentTower.GetComponent<TowerBase>().Value);
            }
            else //Replace with error of some kind
                return;
        }
    }
}
