using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotCamera : MonoBehaviour
{
    //특정 카메라 (Camera_ScreenShot) 의 위치에서 스크린샷을 찍어주고 UI에 띄어주는 스크립트
    /*
    Canvas에 추가하여, RawImage를 셋팅 해준 후 씬에서 Camera_ScreenShot를 적절한 위치에 배치
    테스트에서는 스페이스바를 통해 스크린샷 촬영
     */

    //[System.Serializable]
    public GameObject mycameraobj; //SetActive용 임시
    public Camera Mycamera;       //보여지는 카메라.
    public RawImage Image;      //스크린샷이 적용될 UI

    int resWidth;
    int resHeight;
    Texture2D screenShot;   //스크린샷 저장용

    // Use this for initialization
    void Start()
    {
        //RawImage해상도에 따라 조절
        resWidth = (int)Image.rectTransform.rect.width; //Screen.width;
        resHeight = (int)Image.rectTransform.rect.height; //Screen.height;
        //string sizeStinrg = "Size = " + resWidth + ", " + resHeight;
        //Debug.Log(sizeStinrg);

        mycameraobj = GameObject.Find("Camera_ScreenShot");
        Mycamera = mycameraobj.GetComponent<Camera>();
        mycameraobj.SetActive(false);

        frame = 0;
        dt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //키보드로 테스트용
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space");
            ClickScreenShot();   
        }
        */
        dt += Time.deltaTime;
        frame++;
        if(dt >= 1.0f)
        {
            dt -= 1.0f;
            string temp_s = "Frame = " + frame.ToString();
            Debug.Log(temp_s);
            frame = 0;
        }
    }

    //이 함수를 불러주면 됨
    public void ClickScreenShot()
    {
        if (mycameraobj)
        {
            mycameraobj.SetActive(true);

            //스크린샷
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            Mycamera.targetTexture = rt;
            screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
            Mycamera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            screenShot.Apply();

            //텍스쳐적용
            Image.texture = screenShot;

            mycameraobj.SetActive(false);
        }
    }

    public int frame;
    public float dt;
}
