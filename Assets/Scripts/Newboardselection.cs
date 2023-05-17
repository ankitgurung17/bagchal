using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newboardselection : MonoBehaviour
{
    public Button newboard;
    public Button newboard1;
    
    // Start is called before the first frame update
    private void Start()
    {

        if (Buyitem.isbuy == true) {
            newboard.interactable = true;
        
        }
        if (Buyitem.isbuy1 == true)
        {
            newboard1.interactable = true;

        }
    }
}
