using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private CoinCollector[] coins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coins = FindObjectsByType<CoinCollector>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (CoinCollector coin in coins)
        {
            coin.OnCoinCollected.AddListener(IncrementScore);
        }
    }


    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
