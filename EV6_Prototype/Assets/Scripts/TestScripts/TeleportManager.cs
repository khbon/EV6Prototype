using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportManager : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset actionAsset;

    [SerializeField]
    private XRRayInteractor rayInteractor;

    [SerializeField]
    private TeleportationProvider provider;

    private InputAction _thumbstick;
    bool _isActive = false;

    public GameObject targetPoint; 




    // Start is called before the first frame update
    void Start()
    {
        /*
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnteleportActivate;


        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        //var thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        //thumbstick.Enable();

        _thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        _thumbstick.Enable();
        */

        var activate_l = actionAsset.FindActionMap("XRI LeftHand").FindAction("Select");
        activate_l.Enable();
        activate_l.performed += OnTeleport;

        var activate_r = actionAsset.FindActionMap("XRI RightHand").FindAction("Select");
        activate_r.Enable();
        activate_r.performed += OnTeleport;

        var onMenu = actionAsset.FindActionMap("XRI LeftHand").FindAction("On Menu");
        onMenu.Enable();
        onMenu.performed += OnMenu;

        var telportActive = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Active");
        telportActive.Enable();
        telportActive.performed += TeleportActive;

        //targetPoint = GameManager.Instance.startPosition;
        //Teleport();
      
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!_isActive)
        {
            return;
        }
        if (_thumbstick.triggered)
            return;

        if(!rayInteractor.GetCurrentRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;

            return;
        }

        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point,

        };

        provider.QueueTeleportRequest(request);

        */

        RaycastHit hit;
        ///Physics.Raycast(transform.position, transform.forward, out hit);
        //Debug.DrawRay(transform.position, transform.forward * 100f, Color.red, 1);
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit);
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.red, 1);

        if(hit.collider && hit.collider.tag == "TeleportPoint")
        {
            if(targetPoint && targetPoint != hit.collider.gameObject)
                targetPoint.GetComponent<TeleporterAnim>().StopHighlight();

            targetPoint = hit.collider.gameObject;
            Debug.Log("충돌 오브젝트는? " + targetPoint.ToString());
            if(_isActive)
            {
                if (!targetPoint.GetComponent<TeleporterAnim>().m_Highlighted)
                {
                    targetPoint.GetComponent<TeleporterAnim>().StartHighlight();
                }
            }
            
            
        }
        else
        {
            if(targetPoint&& targetPoint.GetComponent<TeleporterAnim>())
            {
                targetPoint.GetComponent<TeleporterAnim>().StopHighlight();
                targetPoint = null;

            }
         
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C 눌렸다.");
            //C를 눌렀을 때 
            TeleportRequest request = new TeleportRequest()
            {
                destinationPosition = targetPoint.transform.position,

            };
            provider.QueueTeleportRequest(request);
        }


    }
    public void TeleportActive(InputAction.CallbackContext context)
    {
        
        _isActive = !_isActive;
        Debug.Log("오른쪽 썸스틱 눌러서 활성화" + _isActive);
        if (!_isActive)
            Teleport();
    }
    public void OnMenu(InputAction.CallbackContext context)
    {
        Debug.Log("메뉴버튼 눌렀어");
        UIController.instance.gameObject.SetActive(!UIController.instance.gameObject.activeSelf);

        //if (UIController.instance.gameObject.activeSelf)
        //{
        //    Debug.Log("이쪽??");
        //    UIController.instance.gameObject.SetActive(!UIController.instance.gameObject.activeSelf);
        //}
        //else
        //{
        //    Debug.Log("이쪽??222");

        //}
    }
    public void Teleport()
    {
        if (!targetPoint)
            return;
      
        Vector3 dir = GameManager.Instance.mainCar.transform.position - targetPoint.GetComponent<TeleporterAnim>().anchor.transform.position;
        dir.y = 0;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);


        Debug.Log("트리거 눌렸다.");
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = targetPoint.GetComponent<TeleporterAnim>().anchor.transform.position,
            destinationRotation = rot

        };
        provider.QueueTeleportRequest(request);

        gameObject.transform.rotation = rot;
    }
    public void OnTeleport(InputAction.CallbackContext context)
    {
        if (!targetPoint)
            return;
        if (!_isActive)
            return;
        Vector3 dir = GameManager.Instance.mainCar.transform.position - targetPoint.GetComponent<TeleporterAnim>().anchor.transform.position;
        dir.y = 0;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);


        Debug.Log("트리거 눌렸다.");
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = targetPoint.GetComponent<TeleporterAnim>().anchor.transform.position,
            destinationRotation = rot

        };
        provider.QueueTeleportRequest(request);

        gameObject.transform.rotation = rot;

    }
    private void OnteleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;

    }
}
