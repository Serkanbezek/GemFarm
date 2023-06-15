using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SellingArea : MonoBehaviour
{
    public static event Action<int, string, Sprite> GemHasBeenSold;

    [SerializeField] private float _sellingDelay;

    private Coroutine _sellingCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        GemCollector gemCollector = other.GetComponent<GemCollector>();
        if (gemCollector != null && gemCollector.GemsOnPlayer.Count > 0)
        {
            _sellingCoroutine = StartCoroutine(SellGemsCoroutine(gemCollector));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GemCollector gemCollector = other.GetComponent<GemCollector>();
        if (gemCollector != null)
        {
            if (_sellingCoroutine != null)
            {
                StopCoroutine(_sellingCoroutine);
            }
        }
    }

    private IEnumerator SellGemsCoroutine(GemCollector gemCollector)
    {
        for (int i = gemCollector.GemsOnPlayer.Count - 1; i >= 0; i--)
        {
            GameObject gemToSell = gemCollector.GemsOnPlayer[i];
            gemCollector.GemsOnPlayer.Remove(gemToSell);
            gemToSell.transform.SetParent(null);
            GemData gemToSellData = gemToSell.GetComponent<GemData>();
            int gemSalePrice = Mathf.RoundToInt(gemToSellData.GetGemPrice() + gemToSell.transform.localScale.x * 100);
            string gemName = gemToSellData.GetGemName();
            Sprite gemIcon = gemToSellData.GetGemIcon();
            GemHasBeenSold?.Invoke(gemSalePrice, gemName, gemIcon);
            Destroy(gemToSell, 0.05f);
            yield return new WaitForSeconds(_sellingDelay);
        }
    }

}
