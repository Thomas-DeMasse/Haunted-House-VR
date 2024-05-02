using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSimulator : MonoBehaviour
{
    public CoinInventory coinIn;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (coinIn == null)
        {
            Debug.LogError("coinInventory reference not set for doorSimulator");
        }

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (coinIn.returnCoinsHeld() == 6)
        {
            //transform.Rotate(Vector4.up)
            audioSource.Play(0);
            Destroy(gameObject);
        }

    }
}
