/*ϳ�������� ���������� ������� ��� ������ � ���������� Unity*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*�������� ���� ��� ������ ����� MainMenu*/
public class MainMenu : MonoBehaviour
{
    /*������ ���� ������ �����*/
    [SerializeField] int money;
    public int total_money;
    public Text moneyText;
    public int K;
    [SerializeField] int C;
    /*������� ������� ��������� ��� ������� ������� �����*/
    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        K = PlayerPrefs.GetInt("K");
        C = PlayerPrefs.GetInt("C");
        StartCoroutine(IdleFarm());//�����
        
    }
    /*������� ������ ������ �� ��� �� ���������*/
    public void ButtonClick()
    {
        money+=1+C;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }
    /*������� ����-����*/
    IEnumerator IdleFarm()
    {
        K = PlayerPrefs.GetInt("K");
        yield return new WaitForSeconds(1);
        money+=K;
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }
    /*������� �������� �� ���� ���������*/
    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }
    /*������� �������� �� ���� ��������*/
    public void ToShop()
    {
        SceneManager.LoadScene(2);
    }

    /*������� ��������� ������ ������� ��������� ������ ������*/
    void Update()
    {
        moneyText.text = money.ToString()+" $";
        
    }
}
