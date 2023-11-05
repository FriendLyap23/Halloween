using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void LoadScene(string nameScene) 
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
