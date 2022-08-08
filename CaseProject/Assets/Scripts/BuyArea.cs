using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyArea : MonoBehaviour
{
    public Image progressImage;
    //gameobjectler silinecek.
    public GameObject  buyGameObject;
    public float cost,currentMoney,progress;
    public void Buy(int goldAmount)
    {
        currentMoney += goldAmount;
        progress = currentMoney / cost;
        progressImage.fillAmount = progress;
        if (progress >= 1)
        {
            // tag ekle bunun biri enerjiyi artt�rs�n birisi ise yetenekleri g�ncellesin.
            
            //�uanki kodlar �al��mayacak.
            progressImage.fillAmount = 0;


           this.enabled = false;
        }
        this.enabled = true;
    }
}
