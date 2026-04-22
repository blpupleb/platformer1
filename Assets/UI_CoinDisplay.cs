using System;
using TMPro;
using UnityEngine;

public class UI_CoinDisplay : MonoBehaviour
{
    public CoinComponent coinComp;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        coinComp.CoinAmmountsChanged += CoinComp_CoinAmountChanged;
    }

    private void CoinComp_CoinAmountChanged(float currentPoints, float ammountChanged)
    {
        coinText.text = currentPoints.ToString();
    }
}
