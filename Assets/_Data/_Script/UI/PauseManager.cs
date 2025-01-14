using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    [SerializeField] private TextMeshProUGUI winCoinText;
    public CoinManager CoinManager;

    private AudioManager audioManager;

    protected virtual void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void ShowWinCoins()
    {
        int currentCoins = CoinManager.GetCoins();
        winCoinText.text = currentCoins.ToString();
    }

    public void gameWin()
    {
        gameWinUI.SetActive(true);
        this.ShowWinCoins(); 
        Time.timeScale = 0; 
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        ShowWinCoins();
        Time.timeScale = 0; 
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
        audioManager.PlayMusic(audioManager.background);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}