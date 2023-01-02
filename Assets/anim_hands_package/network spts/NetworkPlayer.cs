using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;

    private PhotonView photonView;

    private Transform headRig;
    private Transform lefthandRig;
    private Transform rightHandRig;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        headRig = rig.transform.Find("Camera Offset/Main Camera");
        Debug.Log("head assigned..." + headRig );
        lefthandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
        Debug.Log("left assigned..." + lefthandRig );
        rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        Debug.Log("Right assigned..." + rightHandRig);

        if (photonView.IsMine)
        {
            foreach ( var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {

            MapPosition(head, headRig);
            MapPosition(leftHand, lefthandRig);
            MapPosition(rightHand, rightHandRig);
            
        }
        

    }

    void MapPosition(Transform target,Transform rigTransform)
    {
        target.SetPositionAndRotation(rigTransform.position, rigTransform.rotation);
    }
}
