using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShotCamera : MonoBehaviour
{
    //Ư�� ī�޶� (Camera_ScreenShot) �� ��ġ���� ��ũ������ ����ְ� UI�� ����ִ� ��ũ��Ʈ
    /*
    Canvas�� �߰��Ͽ�, RawImage�� ���� ���� �� ������ Camera_ScreenShot�� ������ ��ġ�� ��ġ
    �׽�Ʈ������ �����̽��ٸ� ���� ��ũ���� �Կ�
     */

    //[System.Serializable]
    public GameObject mycameraobj; //SetActive�� �ӽ�
    public Camera Mycamera;       //�������� ī�޶�.
    public RawImage Image;      //��ũ������ ����� UI

    int resWidth;
    int resHeight;
    Texture2D screenShot;   //��ũ���� �����

    // Use this for initialization
    void Start()
    {
        //RawImage�ػ󵵿� ���� ����
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
        //Ű����� �׽�Ʈ��
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

    //�� �Լ��� �ҷ��ָ� ��
    public void ClickScreenShot()
    {
        if (mycameraobj)
        {
            mycameraobj.SetActive(true);

            //��ũ����
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            Mycamera.targetTexture = rt;
            screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Rect rec = new Rect(0, 0, screenShot.width, screenShot.height);
            Mycamera.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            screenShot.Apply();

            //�ؽ�������
            Image.texture = screenShot;

            mycameraobj.SetActive(false);
        }
    }

    public int frame;
    public float dt;
}
