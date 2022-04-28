/*Підключння необхідних бібліотек для роботи з елементами Unity*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Основний клас для роботи сцени Shop*/
public class ShopMenu : MonoBehaviour
{
    /*Основні змінні даного класу*/
    public Text moneyText;
    public Text TSET0;
    public Text TSET1;
    public Text TSET2;
    public Text TSET3;
    public Text TSET4;
    public int money;
    public int K;
    private int FSET0, FSET1, FSET2, FSET3, FSET4;
    public int l = 1;
    public int C;
    private int sum0, sum1, sum2, sum3, sum4;

    /*Функція задання параметрів при кожному запуску сцени*/
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        C = PlayerPrefs.GetInt("C");
        //total_money = PlayerPrefs.GetInt("total_money");
        K = PlayerPrefs.GetInt("K");

        
        FSET0 = PlayerPrefs.GetInt("FSET0");
        FSET1 = PlayerPrefs.GetInt("FSET1");
        FSET2 = PlayerPrefs.GetInt("FSET2");
        FSET3 = PlayerPrefs.GetInt("FSET3");
        FSET4 = PlayerPrefs.GetInt("FSET4");
       

        
        sum0 = (int)(Mathf.Pow(1.2f, FSET0) * 10);
        sum1 = (int)(Mathf.Pow(1.2f, FSET1) * 50);
        sum2 = (int)(Mathf.Pow(1.2f, FSET2) * 100);
        sum3 = (int)(Mathf.Pow(1.2f, FSET3) * 500);
        sum4 = (int)(Mathf.Pow(1.2f, FSET4) * 1000);
        
        StartCoroutine(IdleFarm());
    }

    /*Функція роботи кнопки 1*/
    public void GetShop0()
    {
        float d;
        Debug.Log(sum0);
        if (money >= sum0)
        {
            money -= sum0;
            FSET0 ++;
            C += 1;
            
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("C", C);
            PlayerPrefs.SetInt("FSET0", FSET0);
        }
        d = 10 * Mathf.Pow(1.2f,FSET0);
        sum0 = (int)d;
        Update();
    }
    /*Функція роботи кнопки 2*/
    public void GetShop1()
    {
        float d;
 
        if (money >= sum1)
        {

            money -= sum1;
            FSET1 ++;
            C += 5;
            
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("C", C);
            PlayerPrefs.SetInt("FSET1", FSET1);
            
        }
        d = 50 * Mathf.Pow(1.2f, FSET1);
        sum1 = (int)d;
        Update();
    }
    /*Функція роботи кнопки 3*/
    public void GetShop2()
    {
        float d;

        if (money >= sum2)
        {
            
            
            
            
            money -= sum2;
            C += 10;
            FSET2 ++;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("C", C);
            PlayerPrefs.SetInt("FSET2", FSET2);
            
        }
        d = 100 * Mathf.Pow(1.2f, FSET2);
        sum2 = (int)d;
        Update();
    }
    /*Функція роботи кнопки 4*/
    public void GetShop3()
    {
        float d;

        if (money >= sum3)
        {
            
            money -= sum3;
            C += 50;
            FSET3 ++;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("C", C);
            PlayerPrefs.SetInt("FSET3", FSET3);
            
        }
        d = 500 * Mathf.Pow(1.2f, FSET3);
        sum3 = (int)d;
        Update();
    }
    /*Функція роботи кнопки 5*/
    public void GetShop4()
    {
        float d;

        if (money >= sum4)
        {  
            money -= sum4;
            C += 100;
            FSET4 ++;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("C", C);
            PlayerPrefs.SetInt("FSET4", FSET4);
            
        }
        d = 1000 * Mathf.Pow(1.2f, FSET4);
        sum4 = (int)d;
        Update();
    }

    /*Функція авто-кліків*/
    IEnumerator IdleFarm()
    {
        K = PlayerPrefs.GetInt("K");
        yield return new WaitForSeconds(1);
        money += K;
        PlayerPrefs.SetInt("money", money);
        
        Debug.Log(C);
        Update();
        StartCoroutine(IdleFarm());
    }
    /*Функція повернення до сцени MainMenu*/
    public void ToMenu()
    {
        PlayerPrefs.SetInt("FSET0", FSET0);
        PlayerPrefs.SetInt("FSET1", FSET1);
        PlayerPrefs.SetInt("FSET2", FSET2);
        PlayerPrefs.SetInt("FSET3", FSET3);
        PlayerPrefs.SetInt("FSET4", FSET4);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    /*Функція оновлення виводу кількості заробленої ігрової валюти та вартості покупок*/
    void Update()
    { 
        moneyText.text = money.ToString() + " $";
        
        TSET0.text = sum0.ToString();
        TSET1.text = sum1.ToString();
        TSET2.text = sum2.ToString();
        TSET3.text = sum3.ToString();
        TSET4.text = sum4.ToString();
    }
}
