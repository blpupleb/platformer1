using UnityEngine;

public class healthpack : MonoBehaviour
{
    public float healingValue = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        collision.GetComponent<HealthComponent>().AddHealth(healingValue);
        Destroy(gameObject);
    }
}
