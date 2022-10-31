using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    SuicideScript SuicideScript;
    FuzeScript FuzeScript;

     void Start()
    {
        SuicideScript = FindObjectOfType<SuicideScript>();
        FuzeScript = FindObjectOfType<FuzeScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("hitspike");
            FuzeScript.FuzeLives--;
            SuicideScript.Explosion();
            SuicideScript.countdownTillRespawn();
            SuicideScript.StartTimer = true;
            SuicideScript.exploded = true;
            FuzeScript.startFuzeTimer = false;
            if (FuzeScript == null)
            {
                Debug.Log("null");
            }
        }
    }
}
