using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSlot : MonoBehaviour
{
    public Category currentCategory;
    public int index = 0;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Change);
    }

    public void UpdateData(int _index, Category _category)
    {
        index = _index;
        currentCategory = _category;
        UpdateUI();
    }
    public void UpdateUI()
    {
        Car mainCar = GameManager.Instance.mainCar;

        if (currentCategory == Category.ECarType)
        {
            if(mainCar.carImage_list.Count > index)
            {
                button.GetComponent<Image>().sprite = mainCar.carImage_list[index];
            }
           
        }
        else if (currentCategory == Category.EBodyColor)
        {
            if (mainCar.colorImage_list.Count > index)
            {
                button.GetComponent<Image>().sprite = mainCar.colorImage_list[index];
            }
           

        }
        else if (currentCategory == Category.ETyre)
        {
            if (mainCar.tyreImage_list.Count > index)
            {
                button.GetComponent<Image>().sprite = mainCar.tyreImage_list[index];
            }
            
        }

    }

    public void Change()
    {
        if(currentCategory == Category.ECarType)
        {

        }
        else if (currentCategory == Category.EBodyColor)
        {
            GameManager.Instance.mainCar.SetBodyColor(index);

        }
        else if (currentCategory == Category.ETyre)
        {
            GameManager.Instance.mainCar.SetTyres(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
