using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    
    public Button Tut;

    private void Start()
    {
        // Show the mouse cursor
        Cursor.visible = true;
        // Unlock the cursor so it can move freely
        Cursor.lockState = CursorLockMode.None;
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
}
