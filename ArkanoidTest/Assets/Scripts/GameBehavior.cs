using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{ 
    menu,
    inGame,
    gameOver,
    gameWin,
    pouse
}
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior instance;

    private int _scoreGame = 0;
    private int _destroyBlock = 0;
    public Canvas menuCanvas;
    public Canvas pouseCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOver;
    public Canvas gameWin;
    public float timer;
    public bool ispuse;

    public GameState currentGameState = GameState.menu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //StartGame();
        currentGameState = GameState.menu;
    }
    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }
    public void StartGameLII()
    {
        PlayerControllerLevelII.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    void FixedUpdate()
    {
        NullObject();
    }

    void Update()
    {
        Time.timeScale = timer;
        
        if (ispuse == true)
        {
            timer = 0;
        }
        else if (ispuse == false)
        {
            timer = 1f;
        }

        NullObject();
    }

    
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void GameWin()
    {
        SetGameState(GameState.gameWin);
        if (ispuse == false)
        {
            ispuse = true;
        }
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);       
    }
    public void IsPouse()
    {
        SetGameState(GameState.pouse);
        if (ispuse == false)
        {
            ispuse = true;
        }  
    }
    public void NoPouse()
    {
        SetGameState(GameState.inGame);
        if (ispuse == true)
        {
            ispuse = false;
        }
    }
    public void InGame()
    {
        SetGameState(GameState.inGame);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Level2()
    {
        SceneManager.LoadScene(1);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOver.enabled = false;
            gameWin.enabled = false;
            pouseCanvas.enabled = false;
        }
        if (newGameState == GameState.pouse)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOver.enabled = false;
            gameWin.enabled = false;
            pouseCanvas.enabled = true;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOver.enabled = false;
            gameWin.enabled = false;
            pouseCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOver.enabled = true;
            gameWin.enabled = false;
            pouseCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameWin)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOver.enabled = false;
            gameWin.enabled = true;
            pouseCanvas.enabled = false;
        }

        currentGameState = newGameState;
    }

    public int Score
    {
        get { return _scoreGame; }

        set { _scoreGame = value; }
    }

    public int CoundDestroyBlock
    {
        get { return _destroyBlock; }

        set { _destroyBlock = value; }
    }

    void NullObject()
    {
        GameObject go = GameObject.FindWithTag("box");

        if (go == null)
        {
            GameWin();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
