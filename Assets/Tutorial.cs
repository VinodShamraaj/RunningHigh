using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public void PlayGame()
    {
        // Use index/scene name
        SceneManager.LoadSceneAsync(3);
    }
}
