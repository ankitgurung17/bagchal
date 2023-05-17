using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public string Player1Name;
    public string Player2Name;
    public int coins;
    public string singleplayName;
    public string singleAIName;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveData() {
        coins = Game.coins;
        Player1Name = Eventscript.player1;
        Player2Name = Eventscript.player2;
        singleplayName = Eventscript.Splayer1;
        singleAIName = Eventscript.SplayerAI;
        PlayerSaveLoad.savePlayerData(this);
        Debug.Log("Player data saved");
    
    }

    public void loadData()
    {
        PlayerModel playerModel = PlayerSaveLoad.loadPlayerData();
        if (playerModel != null)
        {
            
            this.Player1Name = playerModel.Player1Name;
            this.Player2Name = playerModel.Player2Name;
            this.singleAIName = playerModel.singleAIplayer;
            this.singleplayName = playerModel.singleplayer;
            coins = playerModel.coins;

            Game.coins = coins;
            Eventscript.player1 = Player1Name;
            Eventscript.player2 = Player2Name;
            Eventscript.Splayer1 = singleplayName;
            Eventscript.SplayerAI = singleAIName;
            Debug.Log("Player data loaded..");
            Debug.Log("Player1Name: " + Player1Name);
            Debug.Log("Player2Name: " + Player2Name);
            Debug.Log("SinglePlayer1Name: " + singleplayName);
            Debug.Log("SinglePlayerAIName: " + singleAIName);
            Debug.Log("Coins: " + coins);

        }
        else
        {
            Debug.LogError("ERROR no player model found..");
        }
    }
}
