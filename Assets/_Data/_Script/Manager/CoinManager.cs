//using UnityEngine;
//using TMPro;
//public class CoinManager : MonoBehaviour
//{
//    public static CoinManager instance;
//    private int coins;
//    [SerializeField] private TextMeshProUGUI coinText;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//    }

//    private void OnGUI()
//    {
//        coinText.text = coins.ToString();
//    }
//    public void ChangeCoins(int amount)
//    {
//        coins += amount;
//        Debug.Log("Coins: " + coins);
//    }
//}
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    [SerializeField] private TextMeshProUGUI coinText;
    private const string COIN_KEY = "PlayerCoins"; // Key for PlayerPrefs

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep CoinManager between scenes
            LoadCoins(); // Load saved coins
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find and assign coinText if not set
        if (coinText == null)
        {
            coinText = GameObject.FindGameObjectWithTag("CoinText")?.GetComponent<TextMeshProUGUI>();
        }
    }

    private void OnGUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coins.ToString();
        }
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
        SaveCoins(); // Save coins whenever changed
        Debug.Log("Coins: " + coins);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(COIN_KEY, coins);
        PlayerPrefs.Save();
    }

    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt(COIN_KEY, 0);
    }

    public int GetCoins()
    {
        return coins;
    }

    // Reset coins (useful for new game)
    public void ResetCoins()
    {
        coins = 0;
        SaveCoins();
    }
}