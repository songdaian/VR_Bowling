using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandRightAnimContoller : MonoBehaviour
{
    private Animator m_HandRight_AC;
    // Start is called before the first frame update
    void Start()
    {
        m_HandRight_AC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取右手握把键的值给gripValue
        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.grip, out float gripValue);
        //通过gripValue的值控制右手动作控制器
        m_HandRight_AC.SetFloat("Grab", gripValue);
    }
}
