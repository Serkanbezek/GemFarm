using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Transform _gridCellPrefab;

    [SerializeField] private int _rowNumber;
    [SerializeField] private int _columnNumber;
    [SerializeField] private float _gridSpacingOffset = 1;

    [SerializeField] private List<Transform> _gridCells;


    public void GenerateGrid()
    {
        for (int x = 0; x < _gridCells.Count; x++)
        {
            DestroyImmediate(_gridCells[x].gameObject);
        }
        _gridCells.Clear();

        for (int i = 0; i < _columnNumber; i++)
        {
            for (int j = 0; j < _rowNumber; j++)
            {
                Vector3 worldPos = new(i * _gridSpacingOffset, 0, j * _gridSpacingOffset);
                Transform gridCell = Instantiate(_gridCellPrefab, worldPos, Quaternion.identity);
                gridCell.transform.SetParent(gameObject.transform);
                _gridCells.Add(gridCell);
                gridCell.name = "GridCell " + _gridCells.IndexOf(gridCell);
            }
        }
    }
}
