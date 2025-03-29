using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingScript : MonoBehaviour
{
    [SerializeField] CircleCollider2D playerCollider; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        // Do something with the collided object (e.g., log its name)
        Debug.Log("Collided with: " + collidedObject.name);
        float playerSize = playerCollider.bounds.size.magnitude;
        float objectSize = collision.bounds.size.magnitude;
        //eat object if player is larger
        if (playerSize > objectSize && collidedObject.tag != "Flock")
        {
            Debug.Log("ate");
            playerCollider.radius = playerCollider.radius + (float)0.25;
            Destroy(collision.gameObject);
        }
    }
}
