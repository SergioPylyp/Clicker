/*Підключння необхідних бібліотек для роботи з елементами Unity*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*Основний клас для роботи сцени MainMenu*/
public class MainMenu : MonoBehaviour
{
    /*Основні змінні даного класу*/
    [SerializeField] int money;
    public int total_money;
    public Text moneyText;
    public int K;
    [SerializeField] int C;
    /*Функція задання параметрів при кожному запуску сцени*/
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        K = PlayerPrefs.GetInt("K");
        C = PlayerPrefs.GetInt("C");
        StartCoroutine(IdleFarm());//ферма
        
    }
    /*Функція роботи Кнопки на яку ми натискаємо*/
    public void ButtonClick()
    {
        money+=1+C;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }
    /*Функція авто-кліків*/
    IEnumerator IdleFarm()
    {
        K = PlayerPrefs.GetInt("K");
        yield return new WaitForSeconds(1);
        money+=K;
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }
    /*Функція переходу до меню Досягнень*/
    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }
    /*Функція переходу до меню Магазину*/
    public void ToShop()
    {
        SceneManager.LoadScene(2);
    }

    /*Функція оновлення виводу кількості заробленої ігрової валюти*/
    void Update()
    {
        moneyText.text = money.ToString()+" $";
        
    }
}
