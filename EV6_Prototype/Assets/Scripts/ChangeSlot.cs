using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//추가 임시 수정라인
using UnityEngine.EventSystems;
public class ChangeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Category currentCategory;
    public int index = 0;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Change);
        //추가 임시 수정라인
        ScrennShotScript = UICanvas.GetComponent<ScreenShotCamera>();
        if (ScrennShotScript)
            Debug.Log("scriptLoad Sucess");
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
            ////추가 임시 수정라인
            ScrennShotScript.ClickScreenShot();

        }
        else if (currentCategory == Category.ETyre)
        {
            GameManager.Instance.mainCar.SetTyres(index);
            ////추가 임시 수정라인
            ScrennShotScript.ClickScreenShot();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //추가 임시 수정라인
    public GameObject UICanvas;
    public ScreenShotCamera ScrennShotScript;
    int color_num;
    int tire_num;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("hover");
        if (currentCategory == Category.EBodyColor)
            color_num = GameManager.Instance.CurrentColor;
        if (currentCategory == Category.ETyre)
            tire_num = GameManager.Instance.CurrentTyre;
        Change();
        if (currentCategory == Category.EBodyColor)
            GameManager.Instance.mainCar.SetBodyColor(color_num);
        if (currentCategory == Category.ETyre)
            GameManager.Instance.mainCar.SetTyres(tire_num);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("end hover");
        //서브스크린을 초기화 할거라면 여기서 처리
    }
}
