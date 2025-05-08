using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColour, _offsetColour, _overrideColour;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TowerManager _towerManager;
    [SerializeField] private Transform _attachPoint;
    bool _isOffSet;

    private void Awake()
    {
        _gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        _towerManager = GameObject.Find("TowerManager").GetComponent<TowerManager>();
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
        if (_towerManager.CurrentTower && EventSystem.current.IsPointerOverGameObject() == false)
            Instantiate(_towerManager.CurrentTower, _attachPoint.position, Quaternion.identity);
        else
            return;
    }
}
