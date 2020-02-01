using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool gameOver = false;
    public bool gameWon = false;

    public GameObject winText;
    public GameObject gameOverText;
            //Variabler
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }       //Vettefan

    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.Space))     //Om spelet är över och man trycker space...
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //Laddar den om scenen från början
        }

        if(gameWon && Input.GetKeyDown(KeyCode.Space))      //Om man vann spelet och trycker space...
        {
            SceneManager.LoadScene("WinScreen");        //Laddar den Winscreenen
        }
    }
    public void playerDied()        //Om spelaren dör...
    {
        //gameOverText.SetActive(true);       //Sätter den igång Game Over texten
        gameOver = true;        //Och sätter Game Over till true
    }

    public void playerWon()     //Om spelaren vinner..
    {
        Time.timeScale = 0f;        //Pausar all tid
        gameWon = true;     //Och sätter gameWon till true
        SceneManager.LoadScene("WinScreen");        //Laddar den WinScreenen
    }
}
