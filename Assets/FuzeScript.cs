using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FuzeScript : MonoBehaviour
{
    public float FuzeTimer = 1f;
    public float StartFuze = 10f;
    public Slider timerSlider;
    public bool startFuzeTimer = false;
    SuicideScript suicideScript;
    public int FuzeLives = 4;
    public bool RanoutOfTime = false;
    public GameObject goPanal;
    public Image fuze1;
    public Image fuze2;
    public Image fuze3;
    public SpriteRenderer emptyFuze1;
    public SpriteRenderer emptyFuze2;
    public SpriteRenderer emptyFuze3;
    public Image MainFuze;

    public bool GameOver;
    PlayerCharacter character;

    public CameraShake cameraShake;
    public float shakeDurationOnDeath = 0.5f;

    private void Start()
    {
        suicideScript = GetComponent<SuicideScript>();
        character = GetComponent<PlayerCharacter>();
        cameraShake = FindObjectOfType<CameraShake>();
        MainFuze.enabled = false;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Start")
        {
            MainFuze.enabled = true;
            if (startFuzeTimer == true)
            {
                return;
            }
            else
            {
                startFuzeTimer = true;
            }
            
            FuzeTimer = StartFuze;

        }
        if (collision.tag == "Water")
        {
            FuzeTimer = 10f;
            
        }
    }
    
    void Update()
    {
       
        timerSlider.value = FuzeTimer;
        if(startFuzeTimer == true)
        {
            FuzeTimer -= 1 * Time.deltaTime;
        }
        if(FuzeTimer <= 0)
        {
            RanoutOfTime = true;
            if(RanoutOfTime == true)
            {
                FuzeLives--;
                FuzeTimer = 10;
                RanoutOfTime = false;
                
            }
            suicideScript.Explosion();
            suicideScript.countdownTillRespawn();
            suicideScript.StartTimer = true;
            suicideScript.exploded = true;
            startFuzeTimer = false;
            cameraShake.startShake(shakeDurationOnDeath);
            MainFuze.enabled = false;

        }
        if (FuzeLives == 1)
        {
            fuze1.enabled = false;
            emptyFuze1.enabled = true;
            
        }
        if (FuzeLives == 2)
        {
            fuze2.enabled = false;
            emptyFuze2.enabled = true;
        }
        if (FuzeLives == 3)
        {
            fuze3.enabled = false;
            emptyFuze3.enabled = true;
        }
        
        if(FuzeLives <= 0)
        {
            Debug.Log("GAMEOVER");
            goPanal.SetActive(true);
            character.speed = 0f;
            GameOver = true;
        }
    }
    
}
