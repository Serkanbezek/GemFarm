using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemData : MonoBehaviour
{

    [SerializeField] private string _gemName;

    [SerializeField] private int _gemPrice;

    [SerializeField] private Sprite _gemIcon;



    public int GetGemPrice()
    {
        return _gemPrice;
    }

    public string GetGemName()
    {
        return _gemName;
    }

    public Sprite GetGemIcon()
    {
        return _gemIcon;
    }
}
