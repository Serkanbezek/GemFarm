using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class GemFarmGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _gemFarmTilePrefab;
    [SerializeField] private List<GameObject> _gemFarmTiles;

    [SerializeField] private int _rowNumber;
    [SerializeField] private int _columnNumber;
    [SerializeField] private float _tileSpacingOffset = 1;



    public void GenerateGemFarm()
    {
        for (int x = 0; x < _gemFarmTiles.Count; x++)
        {
            DestroyImmediate(_gemFarmTiles[x]);
        }
        _gemFarmTiles.Clear();

        for (int i = 0; i < _columnNumber; i++)
        {
            for (int j = 0; j < _rowNumber; j++)
            {
                Vector3 gemFarmTilePos = new(i * _tileSpacingOffset, 0, j * _tileSpacingOffset);
                GameObject gemFarmTile = Instantiate(_gemFarmTilePrefab, gemFarmTilePos, Quaternion.identity);
                gemFarmTile.transform.SetParent(gameObject.transform);
                _gemFarmTiles.Add(gemFarmTile);
                gemFarmTile.name = "GemFarmTile " + _gemFarmTiles.IndexOf(gemFarmTile);
            }
        }
    }
}
