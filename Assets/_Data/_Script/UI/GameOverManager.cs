using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void replay()
    {
        //string lastLevel = PlayerPrefs.GetString("LastLevel", "DefaultLevelName");
        //SceneManager.LoadScene(lastLevel);
        SceneManager.LoadScene(2);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }


}
