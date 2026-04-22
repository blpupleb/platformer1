using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public float points = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<HealthComponent>();
        Destroy(this.gameObject);
    }
}
