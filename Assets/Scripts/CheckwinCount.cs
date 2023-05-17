using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckwinCount : MonoBehaviour
{
    public static int MaxDeadGoat = 5;
    public static int DeadGoat = 0;
    public static int TotalGoat = 20;
    public static int CurrentGoat = 0;

    Text winCount;
    // Start is called before the first frame update
    void Start()
    {
        winCount = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        winCount.text = " DeadGoat:  " + DeadGoat.ToString() + "\n No. Of Goats Left:  " + (TotalGoat - DeadGoat); 
        // winCount.text = " Game Won By Tiger:  " + GameWonByTiger.ToString();
        //winCount.text = " Game Won By Tiger:  " + GameWonByGoat.ToString();
    }
    
}
