using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEvent : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator camAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

            isCutsceneOn = true;
            camAnim.SetBool("cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);

        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
        camAnim.SetBool("cutscene1", false);
        Destroy(gameObject);

    }
}
