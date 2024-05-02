using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinInventory : MonoBehaviour
{
    public int coinsHeld;
    public Text coinCounter;

    // Start is called before the first frame update
    void Start()
    {
        coinsHeld = 0;
        coinCounter.text = "Test";
        print("The variable is:" + coinsHeld);
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = coinsHeld.ToString() + "/6 coins collected";
        //coinCounter.text = coinsHeld.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsHeld++;
            print("The variable is:" + coinsHeld);
            Destroy(other.gameObject);
        }
    }

    public int returnCoinsHeld()
    {
        return coinsHeld;
    }
}
