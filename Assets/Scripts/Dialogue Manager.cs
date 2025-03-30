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
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogue != null && dialogueLines.Length != 0 && first == true)
        {
            dialogueCanvas.SetActive(true);
            Debug.Log("hi chat");
            dialogue.text = dialogueLines[0];
            // StartCoroutine(dialogueCoroutine());
            first = false;
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
            yield return new WaitForSeconds(2);
            currentLine++;
            dialogue.text = dialogueLines[currentLine];
        }
        yield return new WaitForSeconds(3);
        dialogueCanvas.SetActive(false);
    }
    
}
