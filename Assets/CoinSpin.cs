using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 100f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
