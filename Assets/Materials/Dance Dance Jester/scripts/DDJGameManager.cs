using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject OpeningScreen;
    public GameObject EndScreen;
    public TextMeshProUGUI endText;

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public GameObject arrow;
    public List<GameObject> allArrowDirections; //list of 4 directional arrows
    public List<GameObject> ArrowList; //list of all 16 base arrows


    public GameObject upLitArrow;
    public GameObject downLitArrow;
    public GameObject leftLitArrow;
    public GameObject rightLitArrow;

    public GameObject currentLitArrow;
    public List<GameObject> LitArrowDirections; //list of 4 lit directional arrows
    public List<GameObject> LitArrowList; //list of all base lit arrows


    public GameObject upCorrectArrow;
    public GameObject downCorrectArrow;
    public GameObject leftCorrectArrow;
    public GameObject rightCorrectArrow;

    public GameObject currentCorrectArrow;
    public List<GameObject> CorrectArrowDirections; //list of 4 correct directional arrows
    public List<GameObject> CorrectArrowList; //list of all base correct arrows


    public GameObject upIncorrectArrow;
    public GameObject downIncorrectArrow;
    public GameObject leftIncorrectArrow;
    public GameObject rightIncorrectArrow;

    public GameObject currentIncorrectArrow;
    public List<GameObject> IncorrectArrowDirections; //list of 4 incorrect directional arrows
    public List<GameObject> IncorrectArrowList; //list of all base incorrect arrows

    public List<Transform> ArrowLocations; //list of transform locations to instantiate base arrow group to

    public List<int> NumberList; //list of 16 numbers representative of directions
    public int directionNumber; //randomly generated number between 1 and 4 for directional arrows
    public int listNumber = 0; //number that increases to progress through the list of arrows

    public bool timerActive = false;
    public bool gameStarted;
    public bool gameOver = false;
    public int totalSeconds;
    public int totalCorrectArrows = 0;
    public int wonStones;

    public Button StartButton;

    public List<GameObject> JesterList;
    public GameObject CurrentJester;
    public GameObject BaseKing;
    public GameObject GunKing;

    //sets out the 4x4 grid of arrows for this game
    private void Awake()
    {
        //creates a list of arrow dirrections
        ArrowSetup();
        StartButton.onClick.AddListener(StartGame);
    }
    //starts the main game function when space is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gameStarted)
        {
            if (NumberList[listNumber] == 0) //if correct
            {
                //shows the player the correct arrow in place of the arrow they hit and proceeds to the next one
                CorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                //replaces visible jester with the one corresponding to the direction pressed
                CurrentJester.SetActive(false);
                JesterList[0].SetActive(true);
                CurrentJester = JesterList[0];

                //shows the base king sprite
                BaseKing.SetActive(true);
                GunKing.SetActive(false);

                totalCorrectArrows += 1;
            }

            else //if incorrect
            {
                //shows the player the incorrect arrow in place of the arrow they hit and proceeds to the next one
                IncorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                //replaces current jester wtih the fearful jester sprite
                CurrentJester.SetActive(false);
                JesterList[4].SetActive(true);
                CurrentJester = JesterList[4];

                //replaces current king with the gun king (beware)
                BaseKing.SetActive(false);
                GunKing.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && gameStarted) //functions same as up
        {
            if (NumberList[listNumber] == 1)
            {
                CorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[1].SetActive(true);
                CurrentJester = JesterList[1];

                BaseKing.SetActive(true);
                GunKing.SetActive(false);

                totalCorrectArrows += 1;
            }

            else
            {
                IncorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[4].SetActive(true);
                CurrentJester = JesterList[4];

                BaseKing.SetActive(false);
                GunKing.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && gameStarted) //functions same as up
        {
            if (NumberList[listNumber] == 2)
            {
                CorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[2].SetActive(true);
                CurrentJester = JesterList[2];

                BaseKing.SetActive(true);
                GunKing.SetActive(false);

                totalCorrectArrows += 1;
            }

            else
            {
                IncorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[4].SetActive(true);
                CurrentJester = JesterList[4];

                BaseKing.SetActive(false);
                GunKing.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && gameStarted) //functions same as up
        {
            if (NumberList[listNumber] == 3)
            {
                CorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[3].SetActive(true);
                CurrentJester = JesterList[3];

                BaseKing.SetActive(true);
                GunKing.SetActive(false);

                totalCorrectArrows += 1;
            }

            else
            {
                IncorrectArrowList[listNumber].SetActive(true);
                listNumber += 1;

                CurrentJester.SetActive(false);
                JesterList[4].SetActive(true);
                CurrentJester = JesterList[4];

                BaseKing.SetActive(false);
                GunKing.SetActive(true);
            }
        }

        if (listNumber == 16 && gameOver == false)
        {
            gameStarted = false;
            EndGame();
        }

        Debug.Log("Game started is " + gameStarted);
        Debug.Log("Total seconds = " + totalSeconds);
    }

    IEnumerator GameTimer()
    {
            while (gameStarted)
            {
                yield return new WaitForSeconds(1f);
                totalSeconds += 1;
            }
    }

    void StartGame()
    {
        if (gameStarted == false && gameOver == false)
        {
            OpeningScreen.SetActive(false);
            gameStarted = true;
            StartCoroutine(GameTimer());
        }
    }

    void EndGame()
    {
        //player gets one stone/point per 2 correct arrows, minus a penalty half the total time
        wonStones = totalCorrectArrows/2 - (totalSeconds/2);

        gameOver = true;

        endText.text = "You win " + wonStones + " stones!";

        EndScreen.SetActive(true);

        GameScoreManager.Instance.AddtoScore(wonStones);
    }

    void ExitGame()
    {
        foreach (GameObject arrow in ArrowList)
        {
            Destroy(arrow);
        }

        foreach (GameObject currentCorrectArrow in CorrectArrowList)
        {
            Destroy(currentCorrectArrow);
        }

        foreach (GameObject currentIncorrectArrow in IncorrectArrowList)
        {
            Destroy(currentIncorrectArrow);
        }
    }

    void ArrowSetup()
    {

        //creates a list of arrow dirrections
        allArrowDirections = new List<GameObject> { upArrow, downArrow, leftArrow, rightArrow };
        LitArrowDirections = new List<GameObject> { upLitArrow, downLitArrow, leftLitArrow, rightLitArrow };
        CorrectArrowDirections = new List<GameObject> { upCorrectArrow, downCorrectArrow, leftCorrectArrow, rightCorrectArrow };
        IncorrectArrowDirections = new List<GameObject> { upIncorrectArrow, downIncorrectArrow, leftIncorrectArrow, rightIncorrectArrow };

        //ArrowLocations list holds empty objects in the locations of the 16 arrows. for every object in the list, instantiates a random arrow in that location and adds it to a list)
        foreach (Transform arrowPlacement in ArrowLocations)
        {
            //generates a random number between 0 and 3 for each number and stores it inside directionNumber, and that inside NumberList. 0=up, 1=down, 2=left, 3=right.
            directionNumber = Random.Range(0, 4);
            NumberList.Add(directionNumber);

            //instantiates each arrow in the corresponding location and adds it to a list
            GameObject arrow = Instantiate((allArrowDirections[directionNumber]), arrowPlacement.position, transform.rotation);
            ArrowList.Add(arrow);

            currentCorrectArrow = Instantiate((CorrectArrowDirections[directionNumber]), arrow.transform.position, transform.rotation);
            currentCorrectArrow.SetActive(false);
            CorrectArrowList.Add(currentCorrectArrow);

            currentIncorrectArrow = Instantiate((IncorrectArrowDirections[directionNumber]), arrow.transform.position, transform.rotation);
            currentIncorrectArrow.SetActive(false);
            IncorrectArrowList.Add(currentIncorrectArrow);
        }
    }


    //below is the script for the attempted timed arrow function, which was cut once rescoped

    //runs the main game loop
    /*IEnumerator GameFunction()
    {
        //goes through the list of each instantiated arrow, checks the number in the direction list and the corresponding dirrection, and instantiates the corresponding lit arrow on top of it
        foreach (GameObject arrow in ArrowList)
        {
            listNumber += 1;

            if (listNumber > ArrowList.Count)
            {
                listNumber = 0;
            }

            if (NumberList[listNumber] == 0)
            {
                LitArrowList[listNumber].SetActive(true);

                timerActive = true;
                StartCoroutine(WaitingOnInput());
                yield return new WaitForSeconds(0.5f);
            }

            if (NumberList[listNumber] == 1)
            {
                LitArrowList[listNumber].SetActive(true);

                timerActive = true;
                StartCoroutine(WaitingOnInput());
                yield return new WaitForSeconds(0.5f);
            }

            if (NumberList[listNumber] == 2)
            {
                LitArrowList[listNumber].SetActive(true);

                timerActive = true;
                StartCoroutine(WaitingOnInput());
                yield return new WaitForSeconds(0.5f);
            }

            if (NumberList[listNumber] == 3)
            {
                LitArrowList[listNumber].SetActive(true);

                timerActive = true;
                StartCoroutine(WaitingOnInput());
                yield return new WaitForSeconds(0.5f);
            }
        }

    }

    //a timer that waits for half a second before returning the "timerActive" boolean as false
    IEnumerator HalfSecondTimer()
    {
        yield return new WaitForSeconds(0.5f);
        timerActive = false;
        yield break;
    }


    IEnumerator WaitingOnInput()
    {
        StartCoroutine(HalfSecondTimer()); //starts the 0.5 second countdown

        while (timerActive)
        {
            //if the current arrow is up
            if (NumberList[listNumber] == 0)
            {
                //if the up key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with correct arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.UpArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    CorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }

                //if any other key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with incorrect arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    IncorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }

            }

            //if the current arrow is down
            if (NumberList[listNumber] == 1)
            {
                //if the down key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with correct arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    CorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }

                //if any other key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with incorrect arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    IncorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }
            }

            //if the current arrow is left
            if (NumberList[listNumber] == 2)
            {
                //if the left key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with correct arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    CorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }

                //if any other key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with incorrect arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    IncorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }
            }

            //if the current arrow is right
            if (NumberList[listNumber] == 3)
            {
                //if the up key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with correct arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    CorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }

                //if any other key is pressed before "timerActive" is returned as false, replace the lit arrow sprite with incorrect arrow sprite
                if (timerActive && Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    LitArrowList[listNumber].SetActive(false);
                    IncorrectArrowList[listNumber].SetActive(true);

                    timerActive = false;
                    yield break;
                }
            }
        }

        //if the time elapses, replace the lit sprite with the incorrect sprite
        if (timerActive == false)
        {
            LitArrowList[listNumber].SetActive(false);
            IncorrectArrowList[listNumber].SetActive(true);
            yield break;
        }
    }*/


}