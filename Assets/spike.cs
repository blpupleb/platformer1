using UnityEngine;

public class sprite : MonoBehaviour
{
    public float damage = 3;

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
       Debug.Log("Trigger Collider");
       collision.GetComponent<HealthComponent>().AddDamage(damage);
       Destroy(collision.gameObject);
    }
}
