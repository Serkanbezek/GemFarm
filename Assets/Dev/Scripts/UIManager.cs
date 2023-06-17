using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Button _allGemsButton;
    [SerializeField] private Button _scrollMenuCloseButton;
    [SerializeField] private Image _scrollMenu;

    [SerializeField] private TextMeshProUGUI _totalGoldText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ChangeTotalGoldText();
    }

    public void OpenScrollMenu()
    {
        _allGemsButton.gameObject.SetActive(false);
        _scrollMenu.rectTransform.DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.OutBack).SetLink(_scrollMenu.gameObject).OnComplete(() =>
        GameManager.Instance.PauseGame());

    }

    public void CloseScrollMenu()
    {
        GameManager.Instance.ResumeGame();
        _scrollMenu.rectTransform.DOAnchorPos(new Vector2(1100, 0), 0.5f).SetEase(Ease.OutBack).SetLink(_scrollMenu.gameObject);
        _allGemsButton.gameObject.SetActive(true);
    }

    public void IncreaseTotalGold(int increaseAmount)
    {
        PlayerPrefs.SetInt("TotalGold", PlayerPrefs.GetInt("TotalGold") + increaseAmount);
        ChangeTotalGoldText();
    }

    private void ChangeTotalGoldText()
    {
        _totalGoldText.text = PlayerPrefs.GetInt("TotalGold").ToString();
    }

}
