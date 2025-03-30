using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogue;
    public GameObject dialogueCanvas;
    public string[] dialogueLines;
    private int currentLine = 0;
    public GameSaving saving;
    private bool first = false;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogue != null && dialogueLines.Length != 0 && first == false)
        {
            dialogueCanvas.SetActive(true);
            Debug.Log("hi chat");
            StartCoroutine(dialogueCoroutine());
            first = true;
        }
        Debug.Log("tutorial not active");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dialogueCoroutine()
    {
        while (currentLine < dialogueLines.Length)
        {
            dialogue.text = dialogueLines[currentLine];
            currentLine++;
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(3);
        dialogueCanvas.SetActive(false);
    }
    
}
