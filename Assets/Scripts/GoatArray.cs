using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GArray();
    }

    // Update is called once per frame
    void Update()
    {
        string[,] arr = new string[5, 5];//declaration of 2D array  

        arr[0, 0] = "";//initialization
        arr[0, 1] = "";
        arr[0, 2] = "";
        arr[0, 3] = "";
        arr[0, 4] = "";


        arr[1, 0] = "";
        arr[1, 1] = "";
        arr[1, 2] = "";
        arr[1, 3] = "";
        arr[1, 4] = "";


        arr[2, 0] = "";
        arr[2, 1] = "";
        arr[2, 2] = "";
        arr[2, 3] = "";
        arr[2, 4] = "";

        arr[3, 0] = "";
        arr[3, 1] = "";
        arr[3, 2] = "";
        arr[3, 3] = "";
        arr[3, 4] = "";

        arr[4, 0] = "";
        arr[4, 1] = "";
        arr[4, 2] = "";
        arr[4, 3] = "";
        arr[4, 4] = "";

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Debug.Log(arr[i, j] + " ");
            }

        }
    }


    void GArray()
    {

        string[,] arr = new string[5, 5];//declaration of 2D array  

        arr[0, 0] = "B";//initialization
        arr[0, 1] = "G";
        arr[0, 2] = "G";
        arr[0, 3] = "G";
        arr[0, 4] = "B";
        

        arr[1, 0] = "G";
        arr[1, 1] = "G";
        arr[1, 2] = "G";
        arr[1, 3] = "G";
        arr[1, 4] = "G";


        arr[2, 0] = "G";
        arr[2, 1] = "G";
        arr[2, 2] = "G";
        arr[2, 3] = "G";
        arr[2, 4] = "G";

        arr[3, 0] = "G";
        arr[3, 1] = "G";
        arr[3, 2] = "G";
        arr[3, 3] = "G";
        arr[3, 4] = "G";

        arr[4, 0] = "B";
        arr[4, 1] = "G";
        arr[4, 2] = "G";
        arr[4, 3] = "G";
        arr[4, 4] = "B";
       


        //traversal  
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Debug.Log(arr[i, j] + " ");
            }

            //Debug.Log("-------------");
            //Console.WriteLine();//new line at each row  
        }
    }
}

    
