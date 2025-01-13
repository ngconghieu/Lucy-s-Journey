using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalCoinText;

    private void Start()
    {
        if (CoinManager.instance != null)
        {
            int finalCoins = CoinManager.instance.GetCoins();
            finalCoinText.text = "Final Coins: " + finalCoins.ToString();
        }
    }
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
