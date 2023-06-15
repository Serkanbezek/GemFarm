using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gemPrefabs;

    private int _timeToReachFullScale = 5;


    private void Start()
    {
        SpawnRandomGem();
    }


    public void SpawnRandomGem()
    {
        int gemIndex = Random.Range(0, _gemPrefabs.Count);
        Vector3 gemPos = transform.position;
        gemPos.y += 1;
        GameObject gem = Instantiate(_gemPrefabs[gemIndex], gemPos, Quaternion.identity);
        gem.transform.localScale = Vector3.zero;
        StartCoroutine(MakeTheGemCollectable(gem, _timeToReachFullScale / 4));
        gem.transform.SetParent(transform);
        gem.transform.DOScale(1, _timeToReachFullScale).SetEase(Ease.Linear);

    }

    private IEnumerator MakeTheGemCollectable(GameObject gem, float timeRequiredToBeCollectable)
    {
        yield return new WaitForSeconds(timeRequiredToBeCollectable);
        gem.GetComponent<BoxCollider>().enabled = true;
    }

}
