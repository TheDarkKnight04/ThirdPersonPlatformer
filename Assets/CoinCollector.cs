using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    public UnityEvent OnCoinCollected = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            OnCoinCollected?.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
