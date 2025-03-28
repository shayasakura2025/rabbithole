using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 mousePos;
    public GameObject camera;
    private int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveTowardMouse();
        moveCamera();
    }

    private void moveTowardMouse()
    {
        Vector3 velocity = Vector2.zero;
        if (transform.position != mousePos)
        {
            Vector3 newPos = Vector3.SmoothDamp(transform.position, mousePos, ref velocity, 0.1f, 20);
            transform.position = newPos;
        }
    }

    private void moveCamera()
    {
        float playerX = this.transform.position.x;
        float playerY = this.transform.position.y;
        camera.transform.position = new Vector3(playerX, playerY, -10);
    }
}
