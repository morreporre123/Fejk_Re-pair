using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public bool gameOver = false;

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
            Time.timeScale = 1f;
        }
    }
    public void playerDied()        //Om spelaren dör...
    {
        gameOver = true;        //Och sätter Game Over till true
        Time.timeScale = 0f;
        gameOverText.SetActive(true);       //Sätter den igång Game Over texten
    }
}
