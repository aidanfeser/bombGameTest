using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    FuzeScript fuze;
    public TextMesh Text1;
    public TextMesh Text2;
    public Image Arrow1;

     void Start()
    {
        fuze = GetComponent<FuzeScript>();
    }
     void Update()
    {
        if (fuze != null) 
        {
            Text1.text = "Keep An Eye On How Many Fuzes You Have Left";

        }
    }
}
