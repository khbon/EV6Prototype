using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    GameObject[] body_array;

    public string tagName;

    public List<GameObject> car_list = new List<GameObject>();
    public List<GameObject> tyre_list = new List<GameObject>();
    public List<Material> bodyColor_list = new List<Material>();

    public List<Sprite> carImage_list = new List<Sprite>();
    public List<Sprite> colorImage_list = new List<Sprite>();
    public List<Sprite> tyreImage_list = new List<Sprite>();


    // Start is called before the first frame update
    protected virtual void Start()
    {
        body_array = GameObject.FindGameObjectsWithTag(tagName);
        InitGame();
    }
    public void InitGame()
    {
        SetBodyColor(GameManager.Instance.CurrentColor);
        SetTyres(GameManager.Instance.CurrentTyre);
    }
    public virtual void SetBodyColor(int _index)
    {
        GameManager.Instance.CurrentColor = _index;

        foreach (GameObject go in body_array)
        {
            if(go && go.GetComponent<MeshRenderer>())
            {
                go.GetComponent<MeshRenderer>().material = bodyColor_list[GameManager.Instance.CurrentColor]; //SkinnedMeshRenderer일 경우 따로 처리 필요
            }
            else
            {
                Debug.LogError("body array null ref");
            }          
        }

    }
    public virtual void SetTyres(int _index)
    {
        GameManager.Instance.CurrentTyre = _index;
        Debug.Log("현재 타이어는? " + _index);

        foreach (GameObject go in tyre_list)
        {
            if(go)
            {
                go.SetActive(false);
            }
        }

        tyre_list[GameManager.Instance.CurrentTyre].SetActive(true);


    }

  

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetBodyColor(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetBodyColor(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetTyres(0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetTyres(1);
        }

    }
}
