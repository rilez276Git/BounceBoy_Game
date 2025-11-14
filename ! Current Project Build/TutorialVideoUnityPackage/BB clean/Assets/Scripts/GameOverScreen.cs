using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

   public void RestartButton() 
   {
		//SceneManager.LoadScene("world1");
   }

   public void ExitButton()
   {
        SceneManager.LoadScene("MainMenu");
   }
}
