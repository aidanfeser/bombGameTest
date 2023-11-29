using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGuy : MonoBehaviour
{
    public static bool firstContact;
    public static bool secondContact;
    public static bool thridContact;
    public GameObject Panal;
    public Text textToDisplay;
    public PlayerCharacter character;
    public float textApperanceDuration = 3.0f;
    public GameObject TutGuy1;
    public GameObject TutGuy5;
    public static int contactStateIndex;

    private void Start()
    {
        contactStateIndex = 0;
    }
   
    private void Update()
    {
        Debug.Log(contactStateIndex + "");
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Panal.SetActive(true);
            if(contactStateIndex == 0)
            {
                StartCoroutine(AppearText("Welcome Mr.... Bomb? I would like to introduce you to some... rules. We will start with some basic stuff. For example, you have some fuzes above your head. Use them wisely! You have the one socketed right now and three little ones beside that"));
                

            }
            else if (contactStateIndex == 1)
            {
                StartCoroutine(AppearText("WAIT! I should warn you that there is TNT laying around. Watch out for them. You would not want to waste one of your fuzes. They are important"));
                
            }
            else if (contactStateIndex == 2)
            {
                StartCoroutine(AppearText("Seems to be a path that is blocking you. Well, good thing you are a BOMB, hey? Try pressing (R) to remove it. But be aware you will lose one of your fuzes."));
                TutGuy1.SetActive(true);
                textApperanceDuration = 4.0f;
            }
            else if (contactStateIndex == 3)
            {
                StartCoroutine(AppearText("Oh seems that cost one of your fuzes! You must use them wisely. You only have 3 left. Dont be afraid to blow somthing up if it is blocking your path!"));
                

            }
            else if (contactStateIndex == 4)
            {
                StartCoroutine(AppearText("Nice Job! Alright did you notice that thing right there? Yea so thats a check point if you were to blow up again you will be brought there not back in the forrest.... Okay but moving just past me is FIRE be carful this will light your socketed fuze! at that point you have until it runs out to blow up! Make sure it is worth it okay?"));
               
                textApperanceDuration = 5.0f;
            }
            else if (contactStateIndex == 5)
            {
                StartCoroutine(AppearText("Nice Job! okay now that wall is gone its a stright shot to the EXIT! its a pretty far run though. So keep an eye out for water this will reset your fuze back to the max but it wont put it out. So dont just stop okay?"));
                
            }
            // Increment contactStateIndex for the next trigger
            contactStateIndex += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Handle exit logic
            //currentContactState = ContactState.None;
            
            Panal.SetActive(false);
            gameObject.SetActive(false);
            
        }
    }

    private IEnumerator AppearText(string fullText)
    {
        textToDisplay.text = "";

        float elapsedTime = 0f;

        while (elapsedTime < textApperanceDuration)
        {
            float percentageComplete = elapsedTime / textApperanceDuration;
            int charactersToShow = Mathf.RoundToInt(percentageComplete * fullText.Length);
            textToDisplay.text = fullText.Substring(0, charactersToShow);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textToDisplay.text = fullText;
    }
 
}