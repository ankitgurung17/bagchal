[System.Serializable]

public class PlayerModel 
{
    // Start is called before the first frame update
    public int coins;
    public string Player1Name;
    public string Player2Name;
    public string singleplayer; 
    public string singleAIplayer;

    public PlayerModel(Player player) {

        this.Player1Name = player.Player1Name;
        this.Player2Name = player.Player2Name;
        this.singleAIplayer = player.singleAIName;
        this.singleplayer = player.singleplayName;
        this.coins = player.coins;


        


    }
}
