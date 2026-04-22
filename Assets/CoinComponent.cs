using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    private float points;

    public delegate void CoinEventHandler(float currentPoints, float ammountChanged);
    public event CoinEventHandler CoinAmmountsChanged;


    public void AddPoints(float amount)
    {
        points += amount;
        CoinAmmountsChanged?.Invoke(points, amount);
    }
}
