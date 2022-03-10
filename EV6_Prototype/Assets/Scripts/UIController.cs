using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Category
{
    ECarType = 0,
    EBodyColor = 1,
    ETyre =2
}

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Button carType;
    public Button bodyColor;
    public Button tyre;

    public List<GameObject> content_list = new List<GameObject>();

    public Category currentCategory = Category.ECarType;

    private void Awake()
    {
        if( instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        carType.onClick.AddListener(() => ChangeUI(Category.ECarType));
        bodyColor.onClick.AddListener(() => ChangeUI(Category.EBodyColor));
        tyre.onClick.AddListener(() => ChangeUI(Category.ETyre));

    }


    public void ChangeUI(Category _category)
    {
        currentCategory = _category;
        EV6 ev6 = (EV6)GameManager.Instance.mainCar;

        Debug.Log("UI 클릭했습니다. ");

        if (_category == Category.ECarType)
        {
            for (int i = 0; i < content_list.Count; i++)
            {
                if(content_list[i].GetComponent<ChangeSlot>())
                {
                    content_list[i].GetComponent<ChangeSlot>().UpdateData(i, currentCategory);

                }

                if (i < ev6.car_list.Count)
                {
                    content_list[i].SetActive(true);
                }
                else
                {
                    content_list[i].SetActive(false);
                }
            }

        }
        else if (_category == Category.EBodyColor)
        {
           

            for (int i = 0; i < content_list.Count; i++)
            {
                content_list[i].GetComponent<ChangeSlot>().UpdateData(i, currentCategory);

                if (i < ev6.bodyColor_list.Count)
                {
                    content_list[i].SetActive(true);
                }
                else
                {
                    content_list[i].SetActive(false);
                }
            }
        }
        else if (_category == Category.ETyre)
        {
            
            for (int i = 0; i < content_list.Count; i++)
            {
                content_list[i].GetComponent<ChangeSlot>().UpdateData(i, currentCategory);

                if (i < ev6.tyre_list.Count)
                {
                    content_list[i].SetActive(true);
                }
                else
                {
                    content_list[i].SetActive(false);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
