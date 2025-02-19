using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputVector.y = 1;
        }
        //Debug.Log(inputVector);
        OnMove?.Invoke(inputVector);
    }
}
