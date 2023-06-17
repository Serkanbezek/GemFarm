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
        SellingArea.GemHasBeenSold += IncreaseCollectedCountAndTotalGold;
    }

    private void OnDisable()
    {
        SellingArea.GemHasBeenSold -= IncreaseCollectedCountAndTotalGold;
    }

    private void Start()
    {
        FillPanelInfo();
    }

    private void FillPanelInfo()
    {
        _gemData = _gemPrefab.GetComponent<GemData>();
        _gemIcon.sprite = _gemData.GetGemIcon();
        _gemTypeText.text = "Gem Type: " + _gemData.GetGemName();
        _gemCountText.text = "Collected Count: " + PlayerPrefs.GetInt(_gemData.GetGemName());

    }

    private void IncreaseCollectedCountAndTotalGold(int gemSalePrice, string soldGemName)
    {
        if (soldGemName == _gemData.GetGemName())
        {
            UIManager.Instance.IncreaseTotalGold(gemSalePrice);
            PlayerPrefs.SetInt(soldGemName, PlayerPrefs.GetInt(soldGemName) + 1);
            _gemCountText.text = "Collected Count: " + PlayerPrefs.GetInt(_gemData.GetGemName());
        }
    }
}
