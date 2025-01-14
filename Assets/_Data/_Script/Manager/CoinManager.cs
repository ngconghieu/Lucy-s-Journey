using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coins;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI WinText;
    [SerializeField] private TextMeshProUGUI FailText;



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
        FailText.text = coins.ToString();
        WinText.text = coins.ToString();
    }
    public void ChangeCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }
    public int GetCoins()
    {
        return coins;
    }

}
