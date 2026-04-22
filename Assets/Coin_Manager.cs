using UnityEngine;

public class Coin_Manager : MonoBehaviour
{
    public float points = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CoinComponent>().AddPoints(points);
        Destroy(gameObject);
    }
}
