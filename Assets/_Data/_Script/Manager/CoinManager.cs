using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    [SerializeField] private TextMeshProUGUI coinText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }
    }

    public void ChangeCoins(int amount)
    {
        coins += amount;
        UpdateCoinText();
        Debug.Log("Coins: " + coins);
    }

    public int GetCoins()
    {
        return coins;
    }
}