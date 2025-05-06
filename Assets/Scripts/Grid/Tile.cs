using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColour, _offsetColour, _overrideColour;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TowerManager _towerManager;
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
        //Fix this please
        if (_towerManager.CurrentTower)
        {
            if (_towerManager.CurrentTower.name == "Tower1" || _towerManager.CurrentTower.name == "Tower2")
                Instantiate(_towerManager.CurrentTower, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            else if (_towerManager.CurrentTower.name == "Tower3" || _towerManager.CurrentTower.name == "Tower4")
                Instantiate(_towerManager.CurrentTower, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
        }
        else
            return;
    }
}
