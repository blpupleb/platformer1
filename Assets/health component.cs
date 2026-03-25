using UnityEngine;

public class health : MonoBehaviour
{
    private float Health = 20;
    public float maxHealth = 20;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void AddDamage(float damage)
    {
        Health -= damage;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
