using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class playermotor : MonoBehaviour
{
    Vector2 direction;
    public float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
       
    }

    // Update is called once per frame
   private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }
    void OnMove(InputValue value)
    {
       //Debug.Log("Move");
       //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();
        
    }
}
