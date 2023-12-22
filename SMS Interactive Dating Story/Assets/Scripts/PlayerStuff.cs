using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    public List<Item> stuff = new List<Item>();
    [SerializeField] private int money = 100000;
    [SerializeField] private UIController uiController;

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
    }

    public void RemoveMoney(int amount)
    {
        if(money - amount < 0)
            return;

        money -= amount;
    }

    public int GetMoney()
    {
        return money;
    }

    // Start is called before the first frame update
    void Start()
    {
        uiController.UpdateMoneyDisplay(money);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
