using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector3 mousePos;
    public Camera mainCamera;
    public int hordeSize = 1;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public float score = 0;
    public TMP_Text scoreText;
    public int timer = 5;
    public TMP_Text timerText;
    private double leftBound = -40.4;
    private double rightBound = 40.4;
    private double upperBound = 22.75;
    private double lowerBound = -22.75;
    public GameSaving saving;
    public float cameraZoom;
    public float minFov;
    public float maxFov;
    [SerializeField] private Flock flock;
    [SerializeField] private Flock flockAnimated;
    private int totalFlock;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(timerCoroutine());
        mainCamera.fieldOfView = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        getMousePos();
        moveTowardMouse();
        moveCamera();
        totalFlock = flock.bunCount + flockAnimated.bunCount;
        zoomCamera();

    }

    private void moveTowardMouse()
    {

        Vector3 velocity = Vector2.zero;
        if (transform.position != mousePos)
        {

            Vector3 newPos = Vector3.SmoothDamp(transform.position, mousePos, ref velocity, 0.15f, 20);
            transform.position = newPos;
            flipSprite();
        }

    }

    private void moveCamera()
    {
        float playerX = transform.position.x;
        float playerY = transform.position.y;
        float cameraX = mainCamera.transform.position.x;
        float cameraY = mainCamera.transform.position.y;
        if (cameraX <= leftBound && playerX <= leftBound && cameraY <= lowerBound && playerY <= lowerBound)
        {

        }
        else if (cameraX <= leftBound && playerX <= leftBound && cameraY >= upperBound && playerY >= upperBound)
        {

        }
        else if (cameraX >= rightBound && playerX>= rightBound && cameraY <= lowerBound && playerY <= lowerBound)
        {

        }
        else if (cameraX >= rightBound && playerX >= rightBound && cameraY >= upperBound && playerY >= upperBound)
        {
             
        }
        else if (cameraX <= leftBound && playerX <= leftBound)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerY, -10);
        }
        else if (cameraX >= rightBound && playerX >= rightBound)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerY, -10);
        }
        else if (cameraY >= upperBound && playerY >= upperBound)
        {
            mainCamera.transform.position = new Vector3(playerX, cameraY, -10);
        }
        else if (cameraY <= lowerBound && playerY <= lowerBound)
        {
            mainCamera.transform.position = new Vector3(playerX, cameraY, -10);
        }
        else
        {
            mainCamera.transform.position = new Vector3(playerX, playerY, -10);
        }
        

    }

    private Vector3 getMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void flipSprite()
    {
        Vector3 currentScale = transform.localScale;
        if (transform.position.x < mousePos.x)
        {

            currentScale.x = -1;

        }
        else
        {
            currentScale.x = 1;
        }
        transform.localScale = currentScale;

        /**Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        if (transform.position.x <= mousePos.x)
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(0, 0, -90);
        }**/
    }

    public void addScore(float add)
    {
        score += add;
        updateScore();
    }

    public void updateScore()
    {
        scoreText.text = ("Score: " + (int)(score));
    }

    IEnumerator timerCoroutine()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            timerText.text = ("Timer: " + timer);
        }
        saving.setScore((int)(score));
        saving.setHighestScore((int)(score));
        saving.SaveData();
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
        
    }

    public void zoomCamera()
    {
        Debug.Log("total flock: " + totalFlock);
        if (mainCamera.orthographicSize <= 4.5)
        mainCamera.orthographicSize = totalFlock * 0.03f + 3f;

    }
}
