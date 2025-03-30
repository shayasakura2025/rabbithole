using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EatingScript : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerCollider; 
    public int destroyTreshold;
    public int currentBuns;
    public Player player;
    
    [SerializeField] Flock flock;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
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
        if (collidedObject.tag == "Flock")
        {
            Debug.Log("in");
            // playerCollider.radius = playerCollider.radius + (float)0.25;
            currentBuns++;
            if(currentBuns >= destroyTreshold)
            {
                Destroy(this.gameObject.transform.parent.gameObject);
                player.addScore(destroyTreshold);
                flock.GetComponent<Flock>().AddBunny();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        Debug.Log("Exited by: " + collidedObject.name);
        if (collidedObject.tag == "Flock")
        {
            Debug.Log("out");
            // playerCollider.radius = playerCollider.radius + (float)0.25;
            currentBuns--;
        }
    }
}
