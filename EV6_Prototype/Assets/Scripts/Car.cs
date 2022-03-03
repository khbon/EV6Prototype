using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    GameObject[] body_array;

    public string tagName;
    public List<GameObject> tyre_list = new List<GameObject>();
    public List<Material> bodyColor_list = new List<Material>();

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
                go.GetComponent<MeshRenderer>().material = bodyColor_list[GameManager.Instance.CurrentColor]; //SkinnedMeshRenderer�� ��� ���� ó�� �ʿ�
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
        Debug.Log("���� Ÿ�̾��? " + _index);
    
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