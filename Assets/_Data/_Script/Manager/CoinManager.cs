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
        }
    }

    private void OnGUI()
    {
        coinText.text = coins.ToString();
    }
    public void ChangeCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }
}
