using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyitem : MonoBehaviour
{
   
    public static bool isbuy = false;
    public static bool isbuy1 = false;
    public Text islock;
    public Text islock1;




    // Start is called before the first frame update
    public void Unlock_onClick()// Triggers Game Play mode when pressed.
    {
        if (isbuy == false && Game.coins >= 30)
        {
            Game.coins = Game.coins - 30;
            isbuy = true;


            islock.text = "Un-Locked";



            Debug.Log(".....Congrats!! You got your New $30 Game Board....");

            Player play = new Player();
            play.saveData();
        }
        else
        {
            Debug.Log(".....SORRY!! You Don't have enough coins to buy the game board....");
        }
    }
    public void Unlock1_onClick()// Triggers Game Play mode when pressed.
    {
        if (isbuy1 == false && Game.coins >= 60)
        {
            Game.coins = Game.coins - 60;
            isbuy1 = true;

            islock1.text = "Un-Locked";

            Debug.Log(".....Congrats!! You got your New $60 Game Board....");

            Player play = new Player();
            play.saveData();
        }
        else
        {

            Debug.Log(".....SORRY!! You Don't have enough coins to buy the game board....");
        }

    }
   
}
