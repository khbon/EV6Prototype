using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Car mainCar;

    private int currentColor = 0;
    public int CurrentColor { get; set; }

    private int currentTyre = 0;
    
    public int CurrentTyre { get; set; }


    public GameObject startPosition; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        InitContents();
    }
    public void InitContents()
    {

    }

    public void StartPosition()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
