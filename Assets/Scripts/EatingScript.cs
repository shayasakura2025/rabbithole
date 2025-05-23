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
    public Flock[] flock;
    public ParticleManager particleManager;
    public SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        flock = FindObjectsOfType<Flock>();
        particleManager = FindObjectOfType<ParticleManager>();
        soundManager = FindObjectOfType<SoundManager>();
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
            particleManager.playEating(this.gameObject.transform.position);
            currentBuns++;
            if(currentBuns >= destroyTreshold)
            {
                soundManager.playEatSound();
                particleManager.playEaten(this.gameObject.transform.position);
                Destroy(this.gameObject.transform.parent.gameObject);
                player.addScore(destroyTreshold);
                if (player.getGameMode() == 1)
                {
                    player.incrementTimer(destroyTreshold);
                    player.updateTimer();
                }
                    
                
                addBunnyBalanceFlock();
                //flock.GetComponent<Flock>().AddBunny();
            }
            else{
                particleManager.playCantEat(this.gameObject.transform.position);
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

    void addBunnyBalanceFlock()
    {
        //grabs animated flock second
        soundManager.playSpawnSound();
        flock[1].AddBunny();
    }
}
