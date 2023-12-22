using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;

    public void UpdateMoneyDisplay(int money)
    {
        // format to like Rp. 100,000,000
        string format = string.Format("Rp. {0:N0}", money);
        moneyDisplay.text = format;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
