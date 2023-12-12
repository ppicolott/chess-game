using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    private float _camDefaultZPos = -10;

    [SerializeField] private Tile _tile;
    [SerializeField] private int _width, _height;
    private Dictionary<Vector2, Tile> _tiles;

    public static GridManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _tiles = new Dictionary<Vector2, Tile>();
    }

    private void Start()
    {
        GenerateGrid();
        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, _camDefaultZPos);
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Tile tile = Instantiate(_tile, new Vector3(i, j), Quaternion.identity);
                tile.name = $"Tile: {i},{j}";

                tile.SetPosition(new Vector2(i, j));

                var isOffset = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0);
                tile.SetColor(isOffset);

                _tiles.Add(new Vector2(i, j), tile);
            }
        }
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
