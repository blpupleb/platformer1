using TMPro;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    private float points;
    public CoinComponent coinComp;
    public TextMeshProUGUI coinText;

    public delegate void CoinEventHandler(float currentpoints, float ammountChanged);
    public event CoinEventHandler CoinAmountChanged;

    public void AddPoints(float amount)
    {
        points += amount;
        //Debug.Log(amount);
        CoinAmountChanged?.Invoke(points, amount);
    }  

}
