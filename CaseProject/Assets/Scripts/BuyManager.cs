using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuyManager : MonoBehaviour
{
    public int moneyCount = 0;
    public TextMeshPro moneyCountTMP;
    private void OnEnable()
    {
        TriggerManager.OnMoneyCollected += IncreaseMoney;
        TriggerManager.OnBuyingDesk += BuyArea;
    }
    private void OnDisable()
    {
        TriggerManager.OnMoneyCollected -= IncreaseMoney;
        TriggerManager.OnBuyingDesk -= BuyArea;
    }
    void BuyArea()
    {
        if (TriggerManager.areaToBuy != null)
        {
            if (moneyCount >= 1)
            {
                TriggerManager.areaToBuy.Buy(1);
                moneyCount -= 1;
            }
        }
    }
    void IncreaseMoney()
    {
        moneyCount += 50;
    }
}
