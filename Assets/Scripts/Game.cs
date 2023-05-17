using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static bool isPlayerModeSingle = true; //true=play with AI, false=play with other player
    public float depthInit = 10, alphaInit = -Mathf.Infinity, betaInit = Mathf.Infinity;

    public AudioSource goatAudio;
    public AudioSource TigerAudio;
    public AudioSource GameOverAudio;
    public AudioSource CoinAudio;
    public static int coins;
    public Text winnerName;

   

    public Text coiny;

    public GameObject gameOverPanel;
    enum PlayerMovesState { TIGER, GOAT }
    bool isGameOver = false;

    public Animator Animation;

    public GameObject TigerObj; //Tiger Object creation.
    public GameObject GoatObj; //Tiger Object creation.
    public GameObject Goat;//Goat Object creation.
    public GameObject hintObjs;//Hint GameObject creation.
    public bool tigerFirstClick = false; //Tiger lai first click gareci matraw hint dekhauna lai.
    public bool tigerSecondClick = false;//Tiger lai Second click gareci matraw move garauna lai..
    
    public bool goatFirstClick = false; //goat lai first  click gareci matraw hint dekhauna lai.
    public bool goatSecondClick = false;//goat lai Second click gareci matraw move garauna lai..


    List<Position> PiecePoints = new List<Position>();// Array list banako tiger Position ko lagi
    List<Moves> hintMoves = new List<Moves>();
    List<GotoPoint> gotomove = new List<GotoPoint>();
    int valOldTigerX = -1, valOldTigerY = -1;
    int valOldGoatX = -1, valOldGoatY = -1;

    string[,] currentGame = new string[5, 5];
    string[,] labelPlaceholder = new string[5, 5];

    PlayerMovesState playerMoveState = PlayerMovesState.GOAT;
    MovLog movLog;
    bool isCountDownFinished = false;
    public Text countDownText;
    public GameObject countDownPanel;
    int countDownTimer = 3;


    void Start()
    {
        Player play = new Player();
        play.loadData();

        init();
        initFinalMoves();

        //# Overall Volume control from settings mode.
        if (VolumeValue.click == true)
        {

            goatAudio.volume = VolumeValue.musicVolume;
            TigerAudio.volume = VolumeValue.musicVolume;
            GameOverAudio.volume = VolumeValue.musicVolume;
        }
        else {

            goatAudio.volume = 0f;
            TigerAudio.volume = 0f;
            GameOverAudio.volume = 0f;



        }
        //# Switching Single & Multi-player Game mode
        if (isPlayerModeSingle)    
        {
            movLog = new MovLog();
            countDownPanel.SetActive(true);
            StartCoroutine(CountDown());
        }
    }
    private IEnumerator CountDown()
    {
        if (!isCountDownFinished)
        {
            yield return new WaitForSeconds(1);
            countDownTimer--;
            countDownText.text = countDownTimer.ToString();
            if (countDownTimer <= 0)
            {
                isCountDownFinished = true;
                countDownPanel.SetActive(false);
            }
            StartCoroutine(CountDown());
        }
    }

    private void init()
    {   
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                currentGame[i, j] = ""; //
            }
        }

        currentGame[0, 0] = "B"; //Tiger static position on index(0,0). 
        currentGame[0, 4] = "B"; //Tiger static position on index(0,0). 
        currentGame[4, 0] = "B"; //Tiger static position on index(0,0). 
        currentGame[4, 4] = "B"; //Tiger static position on index(0,0). 

        //<--Putting Nodes-index in ArrayList-->//

        labelPlaceholder[0, 0] = "N1";
        labelPlaceholder[0, 1] = "N2";
        labelPlaceholder[0, 2] = "N3";
        labelPlaceholder[0, 3] = "N4";
        labelPlaceholder[0, 4] = "N5";

        labelPlaceholder[1, 0] = "N6";
        labelPlaceholder[1, 1] = "N7";
        labelPlaceholder[1, 2] = "N8";
        labelPlaceholder[1, 3] = "N9";
        labelPlaceholder[1, 4] = "N10";

        labelPlaceholder[2, 0] = "N11";
        labelPlaceholder[2, 1] = "N12";
        labelPlaceholder[2, 2] = "N13";
        labelPlaceholder[2, 3] = "N14";
        labelPlaceholder[2, 4] = "N15";

        labelPlaceholder[3, 0] = "N16";
        labelPlaceholder[3, 1] = "N17";
        labelPlaceholder[3, 2] = "N18";
        labelPlaceholder[3, 3] = "N19";
        labelPlaceholder[3, 4] = "N20";

        labelPlaceholder[4, 0] = "N21";
        labelPlaceholder[4, 1] = "N22";
        labelPlaceholder[4, 2] = "N23";
        labelPlaceholder[4, 3] = "N24";
        labelPlaceholder[4, 4] = "N25";

        initTigerMoves(); //Calling initTigerMoves Method. 
    }


    private void initTigerMoves() // Creating possible Tiger Go To Moves from the Static position.
    {
        //For static Tiger position (0 ,0)
        {
            List<Moves> moveLists = new List<Moves>(); //creating array list for Moves.
            moveLists.Add(new Moves(0, 1));
            moveLists.Add(new Moves(1, 0));
            moveLists.Add(new Moves(1, 1));
            PiecePoints.Add(new Position(0, 0, moveLists));

        }

        //For static Tiger position (0 ,4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 3));
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(1, 4));
            PiecePoints.Add(new Position(0, 4, moveLists));
        }

        //For static Tiger position (4 ,0)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 0));
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(4, 1));
            PiecePoints.Add(new Position(4, 0, moveLists));
        }
        //For static Tiger position (4, 4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 4));
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(4, 3));
            PiecePoints.Add(new Position(4, 4, moveLists));
        }
        //if Tiger is in position (0, 1)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 0));
            moveLists.Add(new Moves(0, 2));
            moveLists.Add(new Moves(1, 1));
            PiecePoints.Add(new Position(0, 1, moveLists));
        }
        //if Tiger is in position (0,2)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 1));
            moveLists.Add(new Moves(0, 3));
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(1, 2));
            moveLists.Add(new Moves(1, 3));

            PiecePoints.Add(new Position(0, 2, moveLists));
        }
        //if Tiger is in position (0,3)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 2));
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(0, 4));

            PiecePoints.Add(new Position(0, 3, moveLists));
        }
        //if Tiger is in position (1,0)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 0));
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(2, 0));

            PiecePoints.Add(new Position(1, 0, moveLists));
        }
        //if Tiger is in position (1,1)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 0));
            moveLists.Add(new Moves(0, 1));
            moveLists.Add(new Moves(0, 2));
            moveLists.Add(new Moves(1, 0));
            moveLists.Add(new Moves(1, 2));
            moveLists.Add(new Moves(2, 0));
            moveLists.Add(new Moves(2, 1));
            moveLists.Add(new Moves(2, 2));

            PiecePoints.Add(new Position(1, 1, moveLists));
        }

        //if Tiger is in position (1,2)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 2));
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(2, 2));

            PiecePoints.Add(new Position(1, 2, moveLists));
        }
        //if Tiger is in position (1,3)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 2));
            moveLists.Add(new Moves(0, 3));
            moveLists.Add(new Moves(0, 4));
            moveLists.Add(new Moves(1, 2));
            moveLists.Add(new Moves(1, 4));
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(2, 3));
            moveLists.Add(new Moves(2, 4));

            PiecePoints.Add(new Position(1, 3, moveLists));
        }
        //if Tiger is in position (1,4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(0, 4));
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(2, 4));

            PiecePoints.Add(new Position(1, 4, moveLists));
        }
        //if Tiger is in position (2,0)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(1, 0));
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(2, 1));
            moveLists.Add(new Moves(3, 0));
            moveLists.Add(new Moves(3, 1));

            PiecePoints.Add(new Position(2, 0, moveLists));
        }
        //if Tiger is in position (2,1)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(2, 0));
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(3, 1));
            PiecePoints.Add(new Position(2, 1, moveLists));
        }
        //if Tiger is in position (2,2)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(1, 1));
            moveLists.Add(new Moves(1, 2));
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(2, 1));
            moveLists.Add(new Moves(2, 3));
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(3, 2));
            moveLists.Add(new Moves(3, 3));
            PiecePoints.Add(new Position(2, 2, moveLists));
        }
        //if Tiger is in position (2, 3)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(2, 4));
            moveLists.Add(new Moves(3, 3));
            PiecePoints.Add(new Position(2, 3, moveLists));
        }
        //if Tiger is in position (2,4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(1, 3));
            moveLists.Add(new Moves(1, 4));
            moveLists.Add(new Moves(2, 3));
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(3, 4));
            PiecePoints.Add(new Position(2, 4, moveLists));
        }
        //if Tiger is in position (3,0)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(2, 0));
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(4, 0));
            PiecePoints.Add(new Position(3, 0, moveLists));
        }
        //if Tiger is in position (3,1)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(2, 0));
            moveLists.Add(new Moves(2, 1));
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(3, 0));
            moveLists.Add(new Moves(3, 2));
            moveLists.Add(new Moves(4, 0));
            moveLists.Add(new Moves(4, 1));
            moveLists.Add(new Moves(4, 2));
            PiecePoints.Add(new Position(3, 1, moveLists));
        }
        //if Tiger is in position (3,2)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(4, 2));
            PiecePoints.Add(new Position(3, 2, moveLists));
        }
        //if Tiger is in position (3,3)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(2, 2));
            moveLists.Add(new Moves(2, 3));
            moveLists.Add(new Moves(2, 4));
            moveLists.Add(new Moves(3, 2));
            moveLists.Add(new Moves(3, 4));
            moveLists.Add(new Moves(4, 2));
            moveLists.Add(new Moves(4, 3));
            moveLists.Add(new Moves(4, 4));
            PiecePoints.Add(new Position(3, 3, moveLists));
        }
        //if Tiger is in position (3,4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(2, 4));
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(4, 4));
            PiecePoints.Add(new Position(3, 4, moveLists));
        }
        //if Tiger is in position (4,0)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 0));
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(4, 1));
            PiecePoints.Add(new Position(4, 0, moveLists));
        }
        //if Tiger is in position (4,1)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(4, 0));
            moveLists.Add(new Moves(4, 2));
            PiecePoints.Add(new Position(4, 1, moveLists));
        }
        //if Tiger is in position (4,2)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 1));
            moveLists.Add(new Moves(3, 2));
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(4, 1));
            moveLists.Add(new Moves(4, 3));
            PiecePoints.Add(new Position(4, 2, moveLists));
        }
        //if Tiger is in position (4,3)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(4, 2));
            moveLists.Add(new Moves(4, 4));
            PiecePoints.Add(new Position(4, 3, moveLists));
        }
        //if Tiger is in position (4,4)
        {
            List<Moves> moveLists = new List<Moves>();
            moveLists.Add(new Moves(3, 3));
            moveLists.Add(new Moves(3, 4));
            moveLists.Add(new Moves(4, 3));
            PiecePoints.Add(new Position(4, 4, moveLists));
        }
    }

    private void initFinalMoves() {//If Tiger is in the position to kill the goat 


        //Baghchal ko Game-board lai Horizintal line (L1,L2,L3,L4,L5) mah rakheraw GotoPoint Decide gareko.

        //BaghHorizontalLine:L1 
        gotomove.Add(new GotoPoint(0, 0, 0, 1, 0, 2));
        gotomove.Add(new GotoPoint(0, 1, 0, 2, 0, 3));
        gotomove.Add(new GotoPoint(0, 2, 0, 3, 0, 4));
        gotomove.Add(new GotoPoint(0, 4, 0, 3, 0, 2));
        gotomove.Add(new GotoPoint(0, 3, 0, 2, 0, 1));
        gotomove.Add(new GotoPoint(0, 2, 0, 1, 0, 0));



        //BaghHorizontalLine:L2 
        gotomove.Add(new GotoPoint(1, 0, 1, 1, 1, 2));
        gotomove.Add(new GotoPoint(1, 1, 1, 2, 1, 3));
        gotomove.Add(new GotoPoint(1, 2, 1, 3, 1, 4));
        gotomove.Add(new GotoPoint(1, 4, 1, 3, 1, 2));
        gotomove.Add(new GotoPoint(1, 3, 1, 2, 1, 1));
        gotomove.Add(new GotoPoint(1, 2, 1, 1, 1, 0));



        //BaghHorizontalLine:L3 
        gotomove.Add(new GotoPoint(2, 0, 2, 1, 2, 2));
        gotomove.Add(new GotoPoint(2, 1, 2, 2, 2, 3));
        gotomove.Add(new GotoPoint(2, 2, 2, 3, 2, 4));
        gotomove.Add(new GotoPoint(2, 4, 2, 3, 2, 2));
        gotomove.Add(new GotoPoint(2, 3, 2, 2, 2, 1));
        gotomove.Add(new GotoPoint(2, 2, 2, 1, 2, 0));

        //BaghHorizontalLine:L4 
        gotomove.Add(new GotoPoint(3, 0, 3, 1, 3, 2));
        gotomove.Add(new GotoPoint(3, 1, 3, 2, 3, 3));
        gotomove.Add(new GotoPoint(3, 2, 3, 3, 3, 4));
        gotomove.Add(new GotoPoint(3, 4, 3, 3, 3, 2));
        gotomove.Add(new GotoPoint(3, 3, 3, 2, 3, 1));
        gotomove.Add(new GotoPoint(3, 2, 3, 1, 3, 0));

        //BaghHorizontalLine:L5 
        gotomove.Add(new GotoPoint(4, 0, 4, 1, 4, 2));
        gotomove.Add(new GotoPoint(4, 1, 4, 2, 4, 3));
        gotomove.Add(new GotoPoint(4, 2, 4, 3, 4, 4));
        gotomove.Add(new GotoPoint(4, 4, 4, 3, 4, 2));
        gotomove.Add(new GotoPoint(4, 3, 4, 2, 4, 1));
        gotomove.Add(new GotoPoint(4, 2, 4, 1, 4, 0));


        //Baghchal ko Game-board lai vertical line (R1,R2,R3,R4,R5) mah rakheraw GotoPoint Decide gareko.

        //BaghVerticalLine:R1 
        gotomove.Add(new GotoPoint(0, 0, 1, 0, 2, 0));
        gotomove.Add(new GotoPoint(1, 0, 2, 0, 3, 0));
        gotomove.Add(new GotoPoint(2, 0, 3, 0, 4, 0));
        gotomove.Add(new GotoPoint(4, 0, 3, 0, 2, 0));
        gotomove.Add(new GotoPoint(3, 0, 2, 0, 1, 0));
        gotomove.Add(new GotoPoint(2, 0, 1, 0, 0, 0));

        //BaghVerticalLine:R2 
        gotomove.Add(new GotoPoint(0, 1, 1, 1, 2, 1));
        gotomove.Add(new GotoPoint(1, 1, 2, 1, 3, 1));
        gotomove.Add(new GotoPoint(2, 1, 3, 1, 4, 1));
        gotomove.Add(new GotoPoint(4, 1, 3, 1, 2, 1));
        gotomove.Add(new GotoPoint(3, 1, 2, 1, 1, 1));
        gotomove.Add(new GotoPoint(2, 1, 1, 1, 0, 1));

        //BaghVerticalLine:R3 
        gotomove.Add(new GotoPoint(0, 2, 1, 2, 2, 2));
        gotomove.Add(new GotoPoint(1, 2, 2, 2, 3, 2));
        gotomove.Add(new GotoPoint(2, 2, 3, 2, 4, 2));
        gotomove.Add(new GotoPoint(4, 2, 3, 2, 2, 2));
        gotomove.Add(new GotoPoint(3, 2, 2, 2, 1, 2));
        gotomove.Add(new GotoPoint(2, 2, 1, 2, 0, 2));

        //BaghVerticalLine:R4
        gotomove.Add(new GotoPoint(0, 3, 1, 3, 2, 3));
        gotomove.Add(new GotoPoint(1, 3, 2, 3, 3, 3));
        gotomove.Add(new GotoPoint(2, 3, 3, 3, 4, 3));
        gotomove.Add(new GotoPoint(4, 3, 3, 3, 2, 3));
        gotomove.Add(new GotoPoint(3, 3, 2, 3, 1, 3));
        gotomove.Add(new GotoPoint(2, 3, 1, 3, 0, 3));

        //BaghVerticalLine:R5 
        gotomove.Add(new GotoPoint(0, 4, 1, 4, 2, 4));
        gotomove.Add(new GotoPoint(1, 4, 2, 4, 3, 4));
        gotomove.Add(new GotoPoint(2, 4, 3, 4, 4, 4));
        gotomove.Add(new GotoPoint(4, 4, 3, 4, 2, 4));
        gotomove.Add(new GotoPoint(3, 4, 2, 4, 1, 4));
        gotomove.Add(new GotoPoint(2, 4, 1, 4, 0, 4));


        //Baghchal ko Game-board lai Diagonal line mah rakheraw GotoPoint Decide gareko.

        //FixedBaghDiagonalLineMove: 
        gotomove.Add(new GotoPoint(0, 0, 1, 1, 2, 2));
        gotomove.Add(new GotoPoint(0, 4, 1, 3, 2, 2));
        gotomove.Add(new GotoPoint(4, 0, 3, 1, 2, 2));
        gotomove.Add(new GotoPoint(4, 4, 3, 3, 2, 2));

        //BaghDiagonalLineMove(2,0): 
        gotomove.Add(new GotoPoint(2, 0, 1, 1, 0, 3));
        gotomove.Add(new GotoPoint(2, 0, 3, 1, 4, 2));


        //BaghDiagonalLineMove(0,2): 
        gotomove.Add(new GotoPoint(0, 2, 1, 1, 2, 0));
        gotomove.Add(new GotoPoint(0, 2, 1, 3, 2, 4));

        //BaghDiagonalLineMove(4,2): 
        gotomove.Add(new GotoPoint(4, 2, 3, 1, 2, 0));
        gotomove.Add(new GotoPoint(4, 2, 3, 3, 2, 4));

        //BaghDiagonalLineMove(2,4): 
        gotomove.Add(new GotoPoint(2, 4, 1, 3, 0, 2));
        gotomove.Add(new GotoPoint(2, 4, 3, 3, 4, 2));

        //BaghDiagonalLineMove(1,3) & (3,1): 
        gotomove.Add(new GotoPoint(1, 3, 2, 2, 3, 1));
        gotomove.Add(new GotoPoint(3, 1, 2, 2, 1, 3));

        //BaghDiagonalLineMove(1,1) & (3,3): 
        gotomove.Add(new GotoPoint(1, 1, 2, 2, 3, 3));
        gotomove.Add(new GotoPoint(3, 3, 2, 2, 1, 1));

        /*//BaghDiagonalLineMove(2,1) & (3,3): 
        gotomove.Add(new GotoPoint(1, 1, 2, 2, 3, 3));
        gotomove.Add(new GotoPoint(3, 3, 2, 2, 1, 1));*/

        //BaghDiagonalLineMove(2,2): 
        gotomove.Add(new GotoPoint(2, 2, 1, 1, 0, 0));
        gotomove.Add(new GotoPoint(2, 2, 3, 1, 4, 0));
        gotomove.Add(new GotoPoint(2, 2, 1, 3, 0, 4));
        gotomove.Add(new GotoPoint(2, 2, 3, 3, 4, 4));
    } 

    class Position
    {
        int x; //creating variable node x  //
        int y; //creating variable node y //
        public List<Moves> moves = new List<Moves>();// creating (MOVES) Array-List: To Move From Previous Node To New Node.// 
        public Position(int _x, int _y, List<Moves> _moves)
        {
            this.x = _x;
            this.y = _y;
            this.moves = _moves;
        }

        public bool isPosition(int x, int y)// Creating boolean value to check the tiger or goat position. 
        {
            if (this.x == x && this.y == y) // actual position x & y lai check gareko 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Moves // Creating Moves class.
    {
        public int x;
        public int y;

        public Moves(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }
    }

    class GotoPoint { //Creating the class holding the go to moves for Tiger While killing Goat.

        public int TigerX, TigerY; // Creating int Variable for initial Tiger X & Y Node  
        public int GoatX, GoatY;  // Creating int Variable for Goat X & Y  

        public int FinalTigerX, FinalTigerY; // Creating int Variable for Final Tiger X & Y Node

        public GotoPoint(int TigerX, int TigerY, int GoatX, int GoatY, int FinalTigerX, int FinalTigerY) {

            this.TigerX = TigerX;
            this.TigerY = TigerY;
            this.GoatX = GoatX;
            this.GoatY = GoatY;

            this.FinalTigerX = FinalTigerX;
            this.FinalTigerY = FinalTigerY;
        }

    }

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                string label = labelPlaceholder[i, j];
                if (currentGame[i, j] == "B" && label != null)//checks if there is Tiger on the particular node, if yes then
                {
                    Transform go_ = TigerObj.transform.Find(label);
                    go_.gameObject.SetActive(true);//shows Tiger gameobject on the node
                }
                else if (currentGame[i, j] == "G" && label != null)//checks if there is Goat on the particular node
                {
                    Transform go_ = Goat.transform.Find(label);
                    go_.gameObject.SetActive(true);//shows Goat gameobject on the node
                }
                else if (currentGame[i, j] == "" && label != null)//checks if there is Neither Tiger/Goat on the particular node
                {
                    Transform goat = Goat.transform.Find(label);
                    Transform tiger = TigerObj.transform.Find(label);
                    goat.gameObject.SetActive(false);//shows no gameobject the node
                    tiger.gameObject.SetActive(false);//shows no gameobject the node
                }
            }
        }
        hint();// Calling hint method.
        checkGoat(); // Calling checkGoat method.
        checkTiger(); // Calling checkTiger method.
        checkAndStartTigerAI();
    }

    private void checkGoat(){// Checking If Tiger Complete the crieteria To Win The Game
        if (!isGameOver)//Checking if the Game is not over.
        {
            if (CheckwinCount.DeadGoat >= CheckwinCount.MaxDeadGoat)
            { //checking If The deadgoat is greater or equals to MaxDeadGoat, Tiger Wins Game. 
                
                gameOverPanel.SetActive(true);//depictes a new Gameover panel on playScene.
                isGameOver = true;
                coins = coins + 10;// Adding Coins to winner by +10, After everytime winning the game.

                Player play = new Player();
                play.saveData();


                coiny.text = coins.ToString();//
                CoinAudio.Play(); //plays coin collecting audio after winning it.

                
                winnerName.text = Eventscript.player1;
                winnerName.text = Eventscript.Splayer1;


                Debug.Log(Eventscript.player1);
                Debug.Log(Eventscript.Splayer1);
            }
           
           
        }
    }

    private void checkTiger()// Checking If Goat Complete the crieteria To Win The Game
    {
        if (!isGameOver)//Checking if the Game is not over.
        {
            if (CheckwinCount.DeadGoat >= CheckwinCount.MaxDeadGoat)
            {
                gameOverPanel.SetActive(true);
                isGameOver = true;
                coins = coins + 10;
                coiny.text = coins.ToString();
               
                winnerName.text = Eventscript.player2;
                winnerName.text = Eventscript.SplayerAI;
            }

            Player play = new Player();
            play.saveData();
        }

    }

    private int[] getArrayNo(string label) //creating method to assign the values to Tiger & goat for moving to particular point.
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (labelPlaceholder[i, j] == label)
                {
                    int[] val = { i, j };// pushing the (i,j) value through val Array.
                    return val;
                }
            }
        }
        return null;
    }

    public void hint() //Creating Class hint() for showing goto hint to tiger Possible position.
    {
        for (int i = 0; i < hintObjs.transform.childCount; i++) 
        {
            hintObjs.transform.GetChild(i).Find("hint").gameObject.SetActive(false);// child hint Disabled.
        }

        foreach (Moves hint in hintMoves) //
        {
            hintObjs.transform.Find(labelPlaceholder[hint.x, hint.y]).Find("hint").gameObject.SetActive(true); // child hint enabled.
        }
    }

    public void setNewPoint(string label) //creating new method setNewPoint to move the pieces turn by turn.
    {
        if (isGameOver) { return; } // if the game is over. 

        if (playerMoveState == PlayerMovesState.GOAT) //Checks if It's Goat Turn. If yes, then enters to GOAT moving code.
        {
            tigerFirstClick = false; //Keeping tigerFirstClick =  "False" to make the intial stage of tiger
            tigerSecondClick = false; //Keeping tigerSecondClick = "False" to make the 

            if (CheckwinCount.DeadGoat <= CheckwinCount.MaxDeadGoat && CheckwinCount.CurrentGoat < CheckwinCount.TotalGoat)
            { //checking the 
                int[] val = getArrayNo(label);
                if (val != null && currentGame[val[0], val[1]] == "")
                {
                    currentGame[val[0], val[1]] = "G";
                    playerMoveState = PlayerMovesState.TIGER;
                    CheckwinCount.CurrentGoat++;
                   goatAudio.Play();
                }

            }
            else if (CheckwinCount.CurrentGoat > CheckwinCount.TotalGoat)
            {
                //firstClick 
                if (!goatFirstClick)
                {
                    int[] val = getArrayNo(label);
                    if (val != null)
                    {
                        int x = val[0], y = val[1];
                        if (currentGame[x, y] == "G")
                        {
                            valOldGoatX = x;
                            valOldGoatY = y;
                            goatFirstClick = true;
                        }
                        Transform goat_ = GoatObj.transform.Find(label);
                        if (goat_ != null)
                        {
                            goat_.GetComponent<Animator>().SetInteger("GState", 1);
                        }
                    }
                }
                //SecondClick 
                else if (!goatSecondClick)
                {
                    int[] val = getArrayNo(label);

                    if (val != null)
                    {
                        int x = val[0], y = val[1];
                        /* if (valOldGoatX = x && valOldGoatY = y)
                         {
                             goatFirstClick = false;
                             return;
                         }*/

                        if (getHitPointsForGoat(valOldGoatX, valOldGoatY, x, y))
                        {
                            currentGame[valOldGoatX, valOldGoatY] = "";
                            currentGame[x, y] = "G";
                            playerMoveState = PlayerMovesState.TIGER;
                            goatFirstClick = false;
                            goatSecondClick = false;

                        }
                        else
                        {
                            Debug.Log("CANT MOVE");
                            goatFirstClick = false;
                            goatSecondClick = false;
                        }

                    }
                }
            }
        }
        else if (playerMoveState == PlayerMovesState.TIGER)
        {
            //first click
            if (!tigerFirstClick)
            {
                int[] val = getArrayNo(label);
                if (val != null)
                {
                    int x = val[0], y = val[1];

                    if (currentGame[x, y] == "B")
                    {//yedi Bagh vhayemah
                        valOldTigerX = x;
                        valOldTigerY = y;

                        //--> Animation
                        Transform back_ = TigerObj.transform.Find(label).Find("back_");
                        if (back_ != null)
                        {
                            back_.gameObject.SetActive(true);
                        }

                        Transform tiger_ = TigerObj.transform.Find(label);
                        if (tiger_ != null)
                        {
                            tiger_.GetComponent<Animator>().SetInteger("state", 1);
                        }


                        tigerFirstClick = true;//true banauni
                        foreach (Position positionList in PiecePoints)
                        {
                            if (positionList.isPosition(x, y))
                            {
                                hintMoves = positionList.moves;
                                break;
                            }
                        }

                        List<Moves> buffer = new List<Moves>();//Temporary moves list banako taaaki Bagh vhako thaumah Hint nadhekheyos bhaneraw.
                        foreach (Moves moves in hintMoves)
                        {
                            if (currentGame[moves.x, moves.y] != "B")
                            {
                                buffer.Add(moves);// Bagh navhako thaumah Hint add garxa.
                            }

                            if (currentGame[moves.x, moves.y] != "G")
                            {
                                buffer.Add(moves);// Goat navhako thaumah Hint add garxa.

                            }
                            TigerAudio.Play();
                        }
                        hintMoves = buffer; // Add vhako Hint lai (hintMoves) mah add garxa.
                    }
                }
            }
            else
            {
                //second click
                if (!tigerSecondClick)
                {
                    int[] val = getArrayNo(label);
                    int x = val[0], y = val[1];

                    if (valOldTigerX == x && valOldTigerY == y)
                    {
                        Transform tiger_ = TigerObj.transform.Find(label);
                        if (tiger_ != null)
                        {
                            tiger_.GetComponent<Animator>().SetInteger("state", 0);// Tiger piece ko animation lai stop garxaw.
                        }
                        hintMoves.Clear();//Hint lai clear garxhaw.
                        tigerFirstClick = false;// Tiger ko first click lai disable garchaw.
                        return;
                    }

                    if (currentGame[x, y] == "B")
                    {
                        Debug.Log("Can't move here..");
                        return;
                    }

                    if (isInsideHint(x, y))
                    {
                        //valOldTigerX, valOldTigerY
                        //x, y -> hint -->Goat

                        if (currentGame[x, y] == "G")
                        {
                            int[] finalVal = getNextPointForTiger(valOldTigerX, valOldTigerY, x, y);
                            if (finalVal != null)
                            {

                                if (currentGame[finalVal[0], finalVal[1]] != "B" && currentGame[finalVal[0], finalVal[1]] != "G")
                                {
                                    tigerSecondClick = true;//true banauni
                                    currentGame[x, y] = "";
                                    currentGame[finalVal[0], finalVal[1]] = "B";
                                    CheckwinCount.DeadGoat++;
                                   GameOverAudio.Play();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            //Debug.Log(currentGame[x, y] + " -- " + x + " " + y + ":: <--" + finalVal);
                        }
                        else
                        {
                            tigerSecondClick = true;//true banauni
                            currentGame[x, y] = "B";
                            //Debug.Log(currentGame[x, y] + " -- " + x + " " + y + ":: ");
                        }
                        currentGame[valOldTigerX, valOldTigerY] = "";

                        hintMoves.Clear();
                        playerMoveState = PlayerMovesState.GOAT;
                    }

                }
            }
        }
    }


    bool isInsideHint(int x, int y) {
        for (int i=0; i<hintMoves.Count; i++) {
            if (hintMoves[i].x == x && hintMoves[i].y == y) {
                return true;
            }
        }
        return false;
    }

    public bool getHitPointsForGoat(int x, int y, int nextPointX, int nextPointY)
    {
        foreach(Position p in PiecePoints)
        {
            if(p.isPosition(x, y))
            {
                foreach(Moves m in p.moves)
                {
                    if(currentGame[nextPointX, nextPointY] == "" && m.x == nextPointX && m.y == nextPointY)
                    {
                        return true;
                    }
                }
                
            }
        }
        return false;
    }

    public int[] getNextPointForTiger(int x, int y, int gX, int gY){
        foreach(GotoPoint gotoPoint in gotomove)
        {
            if(gotoPoint.TigerX == x && gotoPoint.TigerY == y && gotoPoint.GoatX == gX && gotoPoint.GoatY == gY)
            {
                return new int[] { gotoPoint.FinalTigerX, gotoPoint.FinalTigerY };
            }
        }
        return null;
    }
    //AI for Tiger
    private void checkAndStartTigerAI()
    {
        if (isPlayerModeSingle && playerMoveState == PlayerMovesState.GOAT)
        {
            //StartCoroutine(InitGoatAI());
            InitGoatAI();
        }
    }

    private void InitGoatAI()
    {
        float data = alphaBeta(getCurrentNodes(), depthInit, alphaInit, betaInit, true); //Retrace all 
        string[,] cBoard = movLog.findMove(currentGame, data);
        if (cBoard != null) { currentGame = cBoard; }
        playerMoveState = PlayerMovesState.TIGER;
        tigerFirstClick = false;
        tigerSecondClick = false;
    }

    private List<Node> getCurrentNodes()
    {
        List<Node> currentNode = new List<Node>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (currentGame[i, j] == "B")
                {
                    Node node = new Node(i, j);
                    currentNode.Add(node);
                }
            }
        }
        return currentNode;
    }

    private float alphaBeta(List<Node> nodes, float depth, float alpha, float beta, bool maximizingPlayer)
    {
        if (depth == 0 || isTerminalState(nodes))
        {
            return getHeuresticValue(currentGame); //get heustric value
        }

        if (maximizingPlayer)
        {
            float val = -1000; //Min val
            foreach (Node node in nodes)
            {
                val = max(val, alphaBeta(node.generateChild(currentGame), depth - 1, alpha, beta, false));
                alpha = max(alpha, val);
                if (alpha >= beta)
                    break;
            }
            return val;
        }
        else
        {
            float val = 1000; //Max val
            foreach (Node node in nodes)
            {
                val = min(val, alphaBeta(node.generateChild(currentGame), depth - 1, alpha, beta, true));
                beta = min(beta, val);
                if (alpha >= beta)
                    break;
            }
            return val;
        }
    }

    private float min(float val, float newVal)
    {
        if (val < newVal) { return val; }
        return newVal;
    }

    private float max(float val, float newVal)
    {
        if (val > newVal) { return val; }
        return newVal;
    }

    private int getHeuresticValue(string[,] cBoard)
    {
        //create hurestic data
        int hdata = 0;
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (cBoard[x, y] == "B")
                {
                    hdata = 1;
                }
                else
                {
                    hdata = 0;
                }
            }
        }
        return hdata;
    }

    private bool isTerminalState(List<Node> nodes)
    {
        return true;
    }

    class Node
    {
        public int x, y;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public List<Node> generateChild(string[,] currentBoard)
        {
            //create board from current board
            List<Node> nodes = new List<Node>();
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (currentBoard[x, y] == "B")
                    {
                        nodes.Add(new Node(x, y));
                    }
                }
            }
            return nodes;
        }
    }
}

   

        
