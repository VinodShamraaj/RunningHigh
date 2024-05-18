using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Use index/scene name
        if(Settings.currentLanguage == 0) {
            SceneManager.LoadSceneAsync(1);
        } 

        if(Settings.currentLanguage == 1) {
            SceneManager.LoadSceneAsync(2);
        }
        
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
