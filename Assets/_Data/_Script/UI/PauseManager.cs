using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    [SerializeField] private TextMeshProUGUI winCoinText;

    public void ShowWinCoins()
    {
        if (CoinManager.instance != null && winCoinText != null)
        {
            int currentCoins = CoinManager.instance.GetCoins();
            winCoinText.text = "Coins: " + currentCoins.ToString();
            Debug.Log("Win Coins displayed: " + currentCoins);
        }
    }

    public void gameWin()
    {
        gameWinUI.SetActive(true);
        ShowWinCoins(); // Tự động hiển thị coins khi thắng
        Time.timeScale = 0; // Tạm dừng game khi thắng
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        ShowWinCoins();
        Time.timeScale = 0; // Tạm dừng game khi thua
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}