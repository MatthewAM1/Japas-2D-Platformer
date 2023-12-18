using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NewDialogue : MonoBehaviour
{

    public GameObject indicator;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private UnityEngine.UI.Image potraitImage;

    [SerializeField] private string[] speaker;
    [SerializeField] [TextArea] private string[] dialogueWords;
    [SerializeField] private Sprite[] potrait;

    private bool dialogueActivated;
    private int step;
    private PlayerController playerController;
    // Start is called before the first frame update

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();

        ToggleIndicator(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueActivated == true)
        {
            if (step >= speaker.Length)
            {
                dialogueCanvas.SetActive(false);
                step = 0;
                playerController.canMove = true; // Izinkan pemain bergerak setelah dialog selesai
            }
            else
            {
                ToggleIndicator(false);
                dialogueCanvas.SetActive(true);
                speakerText.text = speaker[step];
                dialogueText.text = dialogueWords[step];
                potraitImage.sprite = potrait[step];
                step += 1;

                playerController.canMove = false; // Hentikan pemain bergerak saat dialog berlangsung
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogueActivated = true;
            ToggleIndicator(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueActivated = false;
        dialogueCanvas.SetActive(false);
        ToggleIndicator(false);



    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }
}
