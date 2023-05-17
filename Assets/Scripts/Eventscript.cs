using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventscript: MonoBehaviour
{
    public InputField player1_nme;
    public InputField player2_nme;
    public static string player1;
    public static string player2;

    public InputField singleplayer;
    public InputField singleAIplayer;
    public static string Splayer1;
    public static string SplayerAI;

    public Text ShowTotalCoin;

    public AudioSource Click;


    
    public GameObject isbuyPanel;

    void Start() {

        Player play = new Player();
        play.loadData();

        ShowTotalCoin.text = Game.coins + "";
    }

    public void SinglePlayer_onClick() // Triggers single player mode when pressed.
    {
        Click.Play();


        Debug.Log("You clicked on SINGLEPLAYER Mode");
        Application.LoadLevel("Scenes/SinglePlayer"); // Adds player to the single player playscene.
       
    }
    public void Back_onClick() // Triggers Main Menu mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on MAIN MENU Mode ");
        Application.LoadLevel("Scenes/Menu"); // Adds player to the Main Menu scene.
    }
    public void Settings_onClick() // Triggers settings mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on SETTINGS Mode ");
        Application.LoadLevel("Scenes/Settings"); // Adds player to the settings scene.
    }
    public void MultiPlayer_onClick() // Triggers  Multi-player mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on MULTIPLAYER Mode ");
        Application.LoadLevel("Scenes/MultiPlayer"); // Adds player to the  Multi-player playscene.
    }
    public void Shop_onClick() // Triggers  Multi-player mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on SHOP Mode");
        Application.LoadLevel("Scenes/Shop"); // Adds player to the  Multi-player playscene.
    }
    public void Manual_onClick() // Triggers Manual mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on MANUAL Mode ");
        Application.LoadLevel("Scenes/Manual"); // Adds player to the Manual scene.
    }
    public void BackToPlay_onClick() // Triggers Game Play mode when pressed.
    {

        Click.Play();
        Debug.Log("You clicked on PLAYSCENE Mode");
        Application.LoadLevel("Scenes/PlayScene 1"); // Adds player to the Game Play scene.
    }
    public void Help_onClick() // Triggers Game Play mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on GAME RULES Mode ");
        Application.LoadLevel("Scenes/InformationDesk"); // Adds player to the Game Play scene.
    }
   

    public void BoardSelection_onClick() // Triggers Game board selection for "Multiplayer Mode" when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on BOARDSELECTION Mode");
        get_player_name();
        Application.LoadLevel("Scenes/BoardSelection"); // Adds player to the Game Play scene.
    }
    public void BoardSelection1_onClick() // Triggers Game board selection for "Single-player Mode" when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on BOARDSELECTION1 Mode ");
        get_Singleplayer_name();
        Application.LoadLevel("Scenes/BoardSelection 1"); // Adds player to the Game Play scene.
    }
    public void PaymentTransaction_onClick() // Triggers Game board selection for "Single-player Mode" when pressed.
    {

        Click.Play();
        Debug.Log("You clicked on ONLINE PAYMENT TRANSACTION Mode ");
        Application.LoadLevel("Scenes/PaymentTransaction"); // Adds player to the Game Play scene.
    }

    public void PaymentTransaction1_onClick() // Triggers Game board selection for "Single-player Mode" when pressed.
    {

        Click.Play();
        Debug.Log("You clicked on ONLINE PAYMENT TRANSACTION Mode ");
        Application.LoadLevel("Scenes/PaymentTransaction 1"); // Adds player to the Game Play scene.
    }

    public void Play_onClick()// Triggers "New Game Board" mode when pressed.
    {
      
        if (player1 != "" || player2 != "")
        {
            Click.Play();
            
            Game.isPlayerModeSingle = false;
            Debug.Log("You are playing MULTI-PLAYER MODE on Default Game Board ");
            Application.LoadLevel("Scenes/PlayScene 1"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  
           
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }
    public void Play2_onClick()// Triggers Game Play mode when pressed.
    {
       
        if (player1 != "" || player2 != "")
        {
            Click.Play();
            Game.isPlayerModeSingle = false;
            Debug.Log("You are playing MULTI-PLAYER MODE on $ 30 Game Board ");
            Application.LoadLevel("Scenes/PlayScene 2"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  
            
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }
    public void Play3_onClick()// Triggers Game Play mode when pressed.
    {

        if (player1 != "" || player2 != "")
        {
            Click.Play();
            Game.isPlayerModeSingle = false;
            Debug.Log("You are playing MULTI-PLAYER MODE on $ 60 Game Board ");
            Application.LoadLevel("Scenes/PlayScene 3"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  
           
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }


    public void Play_Single_onClick()// Triggers Game Play mode when pressed.
    {
       

        if (Splayer1 != "" && SplayerAI != "")
        {
            Click.Play();

            Game.isPlayerModeSingle = true;
            Debug.Log("You are playing SINGLE-PLAYER MODE on Defalut Game Board ");
            Application.LoadLevel("Scenes/PlayScene 1"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0. 
            Debug.Log("Check2");
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }
  

    public void Play2_Single_onClick()// Triggers Game Play mode when pressed.
    {
       
        if (SplayerAI != "" && Splayer1 != "")
        {
            Click.Play();
   
            Game.isPlayerModeSingle = true;
            Debug.Log("You are playing SINGLE-PLAYER MODE on $ 30 Game Board ");
            Application.LoadLevel("Scenes/PlayScene 2"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0. 
   
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }
    public void Play3_Single_onClick()// Triggers Game Play mode when pressed.
    {

        if (SplayerAI != "" && Splayer1 != "")
        {
            Click.Play();
            Game.isPlayerModeSingle = true;
            Debug.Log("You are playing SINGLE-PLAYER MODE on $ 60 Game Board ");
            Application.LoadLevel("Scenes/PlayScene 3"); // Adds player to the Game Play scene.
            CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  
           
        }
        Debug.Log("Please!!! Enter Your Name First. ");
    }
   

    public void RePlay_onClick()// Triggers Game Play mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on RE-PLAY Button ");
        Application.LoadLevel("Scenes/PlayScene 1"); // Adds player to the Game Play scene.
        CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  

    }
    public void RePlay1_onClick()// Triggers Game Play mode when pressed.
    {
        Click.Play();
        Debug.Log("You clicked on RE-PLAY Button ");
        Application.LoadLevel("Scenes/PlayScene 2"); // Adds player to the Game Play scene.
        CheckwinCount.DeadGoat = 0;// Making the static value of DeadGoat = 0.  

    }
    public void Restart_onClick() // Triggers single player mode when pressed.
    {
        Click.Play();
        Application.LoadLevel("Scenes/PlayScene"); // Adds player to the Main Menu scene.
    }

    public void get_player_name()
    {
        player1 = player1_nme.text;
        player2 = player2_nme.text;
     

        Debug.Log(player1);
        Player play = new Player();
        play.saveData();
    }
    public void get_Singleplayer_name()
    {
        Splayer1 = singleplayer.text;
        SplayerAI = "Bagchal";

        Debug.Log(Splayer1);
        Player play = new Player();
        play.saveData();
    }
    public void buypanel_onClick()// Triggers Game Play mode when pressed.
    {
       
            Click.Play();
            isbuyPanel.SetActive(true);
            Debug.Log("Please!!! Enter Your Name First. ");
        
    }
}
