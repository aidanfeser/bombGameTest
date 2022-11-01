using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    SuicideScript SuicideScript;
    private Vector3 Checkpoint;
    private void Start()
    {
        SuicideScript = FindObjectOfType<SuicideScript>();
        Checkpoint = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SuicideScript.respawnPoint = Checkpoint;
        }
    }
}
