using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    public Slider heartSlider;
    public TextMeshProUGUI timeDisplay;

    public void UpdateHeartDisplay(float currentHeart, float maxHeart)
    {
        heartSlider.value = currentHeart / maxHeart;
    }

    public void UpdateMoneyDisplay(int money)
    {
        // format to like Rp. 100,000,000
        string format = string.Format("Rp. {0:N0}", money);
        moneyDisplay.text = format;
    }

    public void UpdateTimeDisplay(int hour)
    {
        // format to like 0[hour]:[real world minute] AM/PM
        // get minute from real world
        int minute = System.DateTime.Now.Minute;
        string format = string.Format("{0:00}:{1:00} {2}", hour, minute, hour < 12 ? "AM" : "PM");
        timeDisplay.text = format;
    }

    public void GameOver()
    {

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
