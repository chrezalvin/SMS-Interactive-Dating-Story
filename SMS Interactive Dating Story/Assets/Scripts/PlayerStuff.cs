using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    public List<Item> stuff = new List<Item>();
    [SerializeField] private int money = 100000;
    [SerializeField] private UIController uiController;

    [SerializeField] private float maxHeart = 100f;
    [SerializeField] private float currentHeart = 20f;

    [SerializeField] private int startHour = 8;
    [SerializeField] private int endHour = 22;

    private int currentHour = 8;

    public void UpdateHeart(float amount)
    {
        currentHeart += amount;
        currentHeart = Mathf.Clamp(currentHeart, 0f, maxHeart);
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);
    }

    public float GetHeart()
    {
        return currentHeart;
    }

    public void AddItem(Item item)
    {
        stuff.Add(item);
    }

    public void RemoveItem(Item item)
    {
        stuff.Remove(item);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        uiController.UpdateMoneyDisplay(money);
    }

    public void RemoveMoney(int amount)
    {
        if(money - amount < 0)
            return;

        money -= amount;
        uiController.UpdateMoneyDisplay(money);
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddHour(int hour)
    {
        currentHour = Mathf.Clamp(currentHour + hour, startHour, endHour);
    }

    public int GetHour()
    {
        return currentHour;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiController.UpdateMoneyDisplay(money);
        uiController.UpdateHeartDisplay(currentHeart, maxHeart);
        uiController.UpdateTimeDisplay(currentHour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
