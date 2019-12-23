using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{


    private static gameController instance;


    [Header("Bool")]
    private bool _gameOver = false;

    [Header("Int")]
    private int _score = 1;
    public int score;

    [Header("Floats")]




    [Header("GameObject")]
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject gameOverMenu;




    [Header("Text")]
    public Text scoreText;




    public void Awake()
    {

        if (instance != null)
            Destroy(gameObject);
    }

    private void Start()
    {
        _score = score;
    }

    private void Update()
    {


        if (_gameOver)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true); 
            _gameOver = false;
        }

        //scoreText.text = _score.ToString();

        if (Time.timeScale == 1)
            pauseButton.SetActive(true);          
        else if (Time.timeScale == 0)
            pauseButton.SetActive(false);

    }




    public static gameController Instance
    {
        get
        {
            instance = FindObjectOfType<gameController>();

            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "GameController";
                instance = go.AddComponent<gameController>();

            }
            return instance;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        resumeButton.SetActive(true);

    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        resumeButton.SetActive(false);
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(1);
        _gameOver = false;
        Time.timeScale = 1;

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        _gameOver = false;
        Time.timeScale = 1f;

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");

    }


    public bool GameOver
    {
        get
        {
            return _gameOver;
        }
        set
        {
            _gameOver = value;
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }





}
