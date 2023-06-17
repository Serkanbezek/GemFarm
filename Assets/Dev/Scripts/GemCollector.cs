using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemCollector : MonoBehaviour
{
    public List<GameObject> GemsOnPlayer;

    [SerializeField] private Transform _gemHolder;

    [SerializeField] private float _scaleNeededToCollect;
    [SerializeField] private float _gemJumpPower;
    [SerializeField] private float _gemJumpDuration;
    [SerializeField] private float _spaceBetweenGems;
    [SerializeField] private int _gemJumpNum;

    private Vector3 _newGemTargetPosition = Vector3.zero;


    private void OnTriggerEnter(Collider other)
    {
        GemData gem = other.GetComponent<GemData>();
        if (gem != null)
        {
            CollectGem(other.gameObject);
        }
    }

    private void CollectGem(GameObject gem)
    {
        gem.GetComponent<BoxCollider>().enabled = false;
        gem.transform.DOKill(false);
        gem.transform.GetComponentInParent<GemSpawner>().SpawnRandomGem();
        gem.transform.SetParent(_gemHolder);
        GemsOnPlayer.Add(gem);
        RaiseGemTargetPosition();
        gem.transform.DOLocalJump(_newGemTargetPosition, _gemJumpPower, _gemJumpNum, _gemJumpDuration)
            .SetEase(Ease.Linear).SetLink(gem);
    }

    public void LowerGemTargetPosition()
    {
        _newGemTargetPosition.y -= _spaceBetweenGems;
    }
    private void RaiseGemTargetPosition()
    {
        _newGemTargetPosition.y += _spaceBetweenGems;
    }

}
