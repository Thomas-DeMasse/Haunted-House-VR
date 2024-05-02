using System.Collections;
using UnityEngine;

public class bat1 : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;
    public Vector3 tempPosition;

    void Start()
    {
        tempPosition = transform.position;

    }

    void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed * Time.fixedDeltaTime;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude * Time.fixedDeltaTime;
        transform.position = tempPosition;
    }
}