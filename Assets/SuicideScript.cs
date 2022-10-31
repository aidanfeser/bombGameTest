using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SuicideScript : MonoBehaviour
{
    Collider2D[] inExplosionRange;
    [SerializeField] private float explosionRadius = .5f;
    public Vector3 respawnPoint;

    float currentTime = 0f;
    float startingTime = 1.5f;
    public bool StartTimer;
    public bool exploded = false;
    FuzeScript fuze;
     void Start()
    {
        fuze = GetComponent<FuzeScript>();
        respawnPoint = transform.position;
        currentTime = startingTime;
    }

    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(exploded == false)
            {
                Explosion();
                countdownTillRespawn();
                StartTimer = true;
                exploded = true;
                fuze.startFuzeTimer = false;
                if (fuze.FuzeLives == 1)
                {
                    fuze.FuzeLives--;
                }

                if (fuze.FuzeLives == 2)
                {
                    fuze.FuzeLives--;
                }

                if (fuze.FuzeLives == 3)
                {
                    fuze.FuzeLives--;
                }
                if (fuze.FuzeLives == 4)
                {
                    fuze.FuzeLives--;

                }
            }
          
        }
        if (StartTimer == true)
        {
            currentTime -= 1 * Time.deltaTime;

        }
        if (!StartTimer)
        {
            currentTime = startingTime;
        }
        if (currentTime <= 0)
        {
            transform.position = respawnPoint;
            StartTimer = false;
            exploded = false;
        }
        
       
       

    }
    public void countdownTillRespawn()
    {
        currentTime = startingTime;
        
    }
    public void Explosion()
    {
        
        inExplosionRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach(Collider2D hitColliders in inExplosionRange)
        {
            
            if (hitColliders.tag == "Destroy")
            {
               
                Destroy(hitColliders.gameObject);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
