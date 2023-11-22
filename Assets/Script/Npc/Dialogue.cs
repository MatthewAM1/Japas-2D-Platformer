using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject window;

    public GameObject indicator;

    public TMP_Text dialogueText;

    public List<string> dialogues;

    public float writingSpeed;

    private int index;

    private int charIndex;

    private bool started;

    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    { 
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start dialogue
    public void StartDialogue()
    {
        if (started) return;
        
        started = true;
        //show window
        ToggleWindow(true);
        //hide indicator
        ToggleIndicator(false);
        GetDialogue(0);
        
    }

    private void GetDialogue(int i)
    {
        //start index 
        index = i;
        //reset chara index
        charIndex = 0;
        //clear dialogue
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //end dialogue 
    public void EndDialogue()
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        //hide window
        ToggleWindow(false);

    }

    IEnumerator Writing()
    {

        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[charIndex];
        charIndex++;
        if (charIndex < currentDialogue.Length)
        {
            yield return new WaitForSeconds(writingSpeed);

            StartCoroutine(Writing());
        }
        else
        {
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.Z))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
               GetDialogue(index);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }
        }
    }
}
