using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    
    private void Awake()
    {
        isGameOver = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
   {
        SceneManager.LoadScene("MainMenu");
   }

    public void PlayButton()
   {
        SceneManager.LoadScene("Tutorial 1");
   }

    public void QuitButton()
   {
        Application.Quit();
   }
}
