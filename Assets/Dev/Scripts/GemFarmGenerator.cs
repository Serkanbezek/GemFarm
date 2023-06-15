using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemFarmGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gemPrefabs;
    [SerializeField] private List<Transform> _gemFarmTiles;

    [SerializeField] private Transform _gemFarmTilePrefab;
    [SerializeField] private int _rowNumber;
    [SerializeField] private int _columnNumber;
    [SerializeField] private float _tileSpacingOffset = 1;


    private void Start()
    {
        SpawnRandomGem();
    }


    public void GenerateGemFarm()
    {
        for (int x = 0; x < _gemFarmTiles.Count; x++)
        {
            DestroyImmediate(_gemFarmTiles[x].gameObject);
        }
        _gemFarmTiles.Clear();

        for (int i = 0; i < _columnNumber; i++)
        {
            for (int j = 0; j < _rowNumber; j++)
            {
                Vector3 gemFarmTilePos = new(i * _tileSpacingOffset, 0, j * _tileSpacingOffset);
                Transform gemFarmTile = Instantiate(_gemFarmTilePrefab, gemFarmTilePos, Quaternion.identity);
                gemFarmTile.transform.SetParent(gameObject.transform);
                _gemFarmTiles.Add(gemFarmTile);
                gemFarmTile.name = "GemFarmTile " + _gemFarmTiles.IndexOf(gemFarmTile);
            }
        }
    }

    private void SpawnRandomGem()
    {
        for (int i = 0; i < _gemFarmTiles.Count; i++)
        {
            int gemIndex = Random.Range(0, _gemPrefabs.Count);
            Vector3 gemPos = _gemFarmTiles[i].transform.position;
            gemPos.y += 1;
            GameObject gem = Instantiate(_gemPrefabs[gemIndex], gemPos, Quaternion.identity);
            gem.transform.localScale = new(0, 0, 0);
            gem.transform.SetParent(_gemFarmTiles[i]);
            gem.transform.DOScale(1, 5).SetLink(gem);
        }
    }
}
