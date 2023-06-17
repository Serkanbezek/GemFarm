using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoldGemInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject _gemPrefab;

    [SerializeField] private Image _gemIcon;

    [SerializeField] private TextMeshProUGUI _gemTypeText;
    [SerializeField] private TextMeshProUGUI _gemCountText;

    private GemData _gemData;

    private void OnEnable()
    {
        SellingArea.GemHasBeenSold += IncreaseCollectedCount;
    }

    private void OnDisable()
    {
        SellingArea.GemHasBeenSold -= IncreaseCollectedCount;
    }

    private void Start()
    {
        FillPanelInfo();
        _gemData = _gemPrefab.GetComponent<GemData>();
        _gemCountText.text = "Collected Count: " + PlayerPrefs.GetInt(_gemData.GetGemName());
    }

    public void FillPanelInfo()
    {
        GemData gemData = _gemPrefab.GetComponent<GemData>();
        _gemIcon.sprite = gemData.GetGemIcon();
        _gemTypeText.text = "Gem Type: " + gemData.GetGemName();
    }

    private void IncreaseCollectedCount(int gemSalePrice, string soldGemName)
    {
        if (soldGemName == _gemData.GetGemName())
        {
            PlayerPrefs.SetInt(soldGemName, PlayerPrefs.GetInt(soldGemName) + 1);
            _gemCountText.text = "Collected Count: " + PlayerPrefs.GetInt(_gemData.GetGemName());
        }
    }
}
