using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportController : TeleportationAnchor
{
    public GameObject rightHand;
    public GameObject point;
    public TeleportationProvider provider;
    [SerializeField]
    public TeleportRequest tele = new TeleportRequest();
    protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        base.GenerateTeleportRequest(interactor, raycastHit, ref teleportRequest);

        Debug.Log("���� �������� üũ" + interactor.ToString() + "  �ڷ���Ʈ ������Ʈ : " + teleportRequest.matchOrientation.ToString());
        //if (m_TeleportAnchorTransform == null)
        //    return false;
        //teleportAnchorTransform.position = teleportRequest.destinationPosition;
        teleportRequest.destinationPosition = point.transform.position;
        //teleportRequest.destinationRotation = teleportAnchorTransform.rotation;
     
        Debug.Log("22 ���� �������� üũ" + interactor.ToString() + "  �ڷ���Ʈ ������Ʈ : " + teleportRequest.ToString());
        return true;
    }

    public void Teleport()
    {
        IXRInteractor a = rightHand.GetComponent<XRRayInteractor>();
        RaycastHit hit;
        TeleportRequest req = new TeleportRequest();
        Physics.Raycast(transform.position, transform.forward, out hit);

        GenerateTeleportRequest(a, hit, ref tele);


    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Q Ű�� ���Ƚ�.");
            Teleport();


        }
    }

}
