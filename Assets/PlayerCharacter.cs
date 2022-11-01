using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    private float horzontal;
    public float speed;
    public float jumpingPower;
    public bool isFacingRight = true;
    SuicideScript suicideScript;
    FuzeScript Fuze;
    public bool FinLevel = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        suicideScript = GetComponent<SuicideScript>();
        Fuze = GetComponent<FuzeScript>();
    }
    void Update()
    {
        if(suicideScript.exploded == false)
        {
            horzontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            flip();
        }
        
        if(suicideScript.exploded == true)
        {
            speed = 0;
        }
        else
        {
            speed = 1.8f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            NextLevel();   
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horzontal * speed, rb.velocity.y);
    }

    void NextLevel()
    {
        if(FinLevel == true)
        {
            Debug.Log("level complete");
            Fuze.startFuzeTimer = false;
            SceneManager.LoadScene("Level 1");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Door")
        {
            FinLevel = true;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if(isFacingRight && horzontal < 0f || !isFacingRight && horzontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
