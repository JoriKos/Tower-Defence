using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] Tile _tilePrefab, _selectedTile;
    public Tile SelectedTile { set { _selectedTile = value; } get { return _selectedTile; } }

    private void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                var newTile = Instantiate(_tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                newTile.name = $"Tile {x} {z}";

                //Spawn as child
                newTile.transform.parent = transform;

                bool isOffSet = (x % 2 == 0 && z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                newTile.SetColour(isOffSet);
            }
        }
    }
}
