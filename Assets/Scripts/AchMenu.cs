/*ϳ�������� ���������� ������� ��� ������ � ���������� Unity*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*�������� ���� ��� ������ ����� Achivments*/
public class AchMenu : MonoBehaviour
{
    /*������ ���� ������ �����*/
    public Text moneyText, total_moneyText;
    public int money;
    public int total_money;
    [SerializeField] int K;//����� ��� ������ ����-����
    private bool SET0, SET1, SET2, SET3, SET4, SET5;//���� ��������� ��������

    public string[] arrayTitles;// ����� ����������
    public Sprite arraySprites;// ����� �������� ��� ���������
    public GameObject button;// ������ ������
    public GameObject content;

    private List<GameObject> list = new List<GameObject>();
    private VerticalLayoutGroup _group;

    /*������� ������� ��������� ��� ������� ������� �����*/
    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        total_money = PlayerPrefs.GetInt("total_money");
        K = PlayerPrefs.GetInt("K");

        SET0 = PlayerPrefs.GetInt("SET0") == 1 ? true : false;
        SET1 = PlayerPrefs.GetInt("SET1") == 1 ? true : false;
        SET2 = PlayerPrefs.GetInt("SET2") == 1 ? true : false;
        SET3 = PlayerPrefs.GetInt("SET3") == 1 ? true : false;
        SET4 = PlayerPrefs.GetInt("SET4") == 1 ? true : false;
        SET5 = PlayerPrefs.GetInt("SET5") == 1 ? true : false;

        RectTransform rectT = content.GetComponent<RectTransform>();
        rectT.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);// ������ ��������� ��� ������
        _group = GetComponent<VerticalLayoutGroup>();
        setAchievs();
        /*�������� ���������� ��������� �� ��������� �� ���������� ���������*/
        if (SET0 == true)
        {
            list[0].GetComponent<Button>().interactable = false;
        }
        if (SET1 == true)
        {
            list[1].GetComponent<Button>().interactable = false;
        }
        if (SET2 == true)
        {
            list[2].GetComponent<Button>().interactable = false;
        }
        if (SET3 == true)
        {
            list[3].GetComponent<Button>().interactable = false;
        }
        if (SET4 == true)
        {
            list[4].GetComponent<Button>().interactable = false;
        }
        if (SET5 == true)
        {
            list[5].GetComponent<Button>().interactable = false;
        }
        StartCoroutine(IdleFarm());
        
    }
    /*�������� ������� ������� ��������*/
    public void RemovedList()
    {
        foreach (var elem in list)
        {
            Destroy(elem);
        }
        list.Clear();
    }
    /*������� ��������� ������ ��� ��������� ���������*/
    void setAchievs()
    {
        RectTransform rectT = content.GetComponent<RectTransform>();//���������� ������ �������
        rectT.transform.localPosition = new Vector3(-360.0f, 10.0f, 0.0f);//������������ ���������� ��������� ������
        RemovedList();
        if (arrayTitles.Length > 0)
        {
            var pr1 = Instantiate(button, transform);// ��������� �������
            var h = pr1.GetComponent<RectTransform>().rect.height;// ����� ������
            var tr = GetComponent<RectTransform>();// ��������� ����� 
            tr.sizeDelta = new Vector2(tr.rect.width, h * arrayTitles.Length);
            Destroy(pr1);
            for(var i = 0; i < arrayTitles.Length; i++)//���� ���������
            {
                var pr = Instantiate(button, transform);
                pr.GetComponentInChildren<Text>().text = arrayTitles[i];//����� ������
                pr.GetComponentInChildren<Image>().sprite = arraySprites;//����� ������
                var i1 = i;
                pr.GetComponent<Button>().onClick.AddListener(() => GetAchievement(i1));// ����������� ������ �� ������
                list.Add(pr);// �������� ���������� �� ������
            }
        }
    }

    /*������� ����������� ��������� ��������*/
    void GetAchievement(int id)
    {
        switch(id)
        {
            case 0:
                if (!SET0 && total_money >= 10)
                {
                    money += 10;
                    K += 1;
                    SET0 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET0", 1);
                    list[0].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
            case 1:
                if (!SET1 && total_money >= 50)
                {
                    money += 50;
                    K += 5;
                    SET1 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET1", 1);
                    list[1].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
            case 2:
                if (!SET2 && total_money >= 100)
                {
                    money += 100;
                    K += 10;
                    SET2 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET2", 1);
                    list[2].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
            case 3:
                if (!SET3 && total_money >= 500)
                {
                    money += 500;
                    K += 50;
                    SET3 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET3", 1);
                    list[3].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
            case 4:
                if (!SET4 && total_money>= 1000)
                {
                    money += 1000;
                    K += 100;
                    SET4 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET4", 1);
                    list[4].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
            case 5:
                if (!SET5 && total_money >= 10000)
                {
                    money += 10000;
                    K += 1000;
                    SET5 = true;
                    PlayerPrefs.SetInt("money", money);
                    PlayerPrefs.SetInt("K", K);
                    PlayerPrefs.SetInt("SET5", 1);
                    list[5].GetComponent<Button>().interactable = false;
                }
                Debug.Log(id);
                break;
        }
    }

    /*������� ����-����*/
    IEnumerator IdleFarm()
    {
        K = PlayerPrefs.GetInt("K");
        yield return new WaitForSeconds(1);
        money+=K;
        PlayerPrefs.SetInt("money", money);
        Debug.Log(K);
        StartCoroutine(IdleFarm());
    }
    /*������� ���������� �� ����� MainMenu*/
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /*������� ��������� ������ ������� ��������� ������ ������ �� ������� �������*/
    void Update()
    {
        total_moneyText.text = total_money.ToString() + " Clics";
        moneyText.text = money.ToString() + " $";
    }
}
