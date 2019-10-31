using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject GameOver = null;
    [SerializeField] private GameObject Victory = null;


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
        #else
            Application.Quit();
        #endif
    }

    public void GoToMainMenu(string sceneName)
    {
        GameOver.gameObject.SetActive(false);
        Victory.gameObject.SetActive(false);
        SceneManager.LoadScene(sceneName);
        GameOver.gameObject.SetActive(false);
        Victory.gameObject.SetActive(false);
    }
}
