using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    [Header("Cutscene Game Object")]
    [SerializeField] private GameObject scene1;
    [SerializeField] private GameObject scene2;
    [SerializeField] private GameObject scene3;
    [SerializeField] private GameObject scene4;
    [SerializeField] private GameObject scene5;
    [SerializeField] private GameObject scene6;
    [SerializeField] private GameObject scene7;
    [SerializeField] private GameObject scene8;
    [SerializeField] private GameObject scene9;

    [Header("Other Variable")]
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private int cutSceneCounter = 1;
    [SerializeField] private GameObject backButton;

    private void Update()
    {
        CountCutScene();
    }

    private void CountCutScene()
    {
        if(cutSceneCounter <= 1)
        {
            cutSceneCounter = 1;
            backButton.gameObject.SetActive(false);
            scene2.gameObject.SetActive(false);
            scene1.gameObject.SetActive(true);
        }
        if(cutSceneCounter == 2)
        {
            scene1.gameObject.SetActive(false);
            scene3.gameObject.SetActive(false);
            backButton.gameObject.SetActive(true);
            scene2.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 3)
        {
            scene2.gameObject.SetActive(false);
            scene4.gameObject.SetActive(false);
            scene3.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 4)
        {
            scene3.gameObject.SetActive(false);
            scene5.gameObject.SetActive(false);
            scene4.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 5)
        {
            scene4.gameObject.SetActive(false);
            scene6.gameObject.SetActive(false);
            scene5.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 6)
        {
            scene5.gameObject.SetActive(false);
            scene7.gameObject.SetActive(false);
            scene6.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 7)
        {
            scene6.gameObject.SetActive(false);
            scene8.gameObject.SetActive(false);
            scene7.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 8)
        {
            scene7.gameObject.SetActive(false);
            scene9.gameObject.SetActive(false);
            scene8.gameObject.SetActive(true);
        }
        if (cutSceneCounter == 9)
        {
            scene8.gameObject.SetActive(false);
            scene9.gameObject.SetActive(true);
        }
        if (cutSceneCounter > 9)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void NextCutScene()
    {
        cutSceneCounter += 1;
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void BackCutScene()
    {
        cutSceneCounter -= 1;
        SoundManager.instance.PlaySound(buttonSound);

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        SoundManager.instance.PlaySound(buttonSound);

    }
}
