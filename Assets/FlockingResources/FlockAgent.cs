using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class FlockAgent : MonoBehaviour
{

    Flock agentFlock;
    public Collider2D AgentFlock {get { return agentCollider;}}

    Collider2D agentCollider;
    public Collider2D AgentCollider {get {return agentCollider;}}
    //changed
    [SerializeField] GameObject spriteChild;

    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock) {
        agentFlock = flock;
    }

    // Update is called once per frame
    public void Move(Vector2 velocity){
        
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
        Vector3 currentRotation = transform.eulerAngles;
        //ADDED
        //  freezes sprite rotation
        if (spriteChild)
        {
            spriteChild.transform.eulerAngles = new Vector3(currentRotation.x, currentRotation.y, 0);

            Vector3 currentScale = spriteChild.transform.localScale;
            if (transform.position.x < velocity.x)
            {

                currentScale.x = -1;

            }
            else
            {
                currentScale.x = 1;
            }
            spriteChild.transform.localScale = currentScale;
        }
    }

}
