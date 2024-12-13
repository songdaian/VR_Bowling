using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static BallPool Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    /// <summary>
    /// ���ձ�����
    /// </summary>
    /// <param name="obj">����������</param>
    public void RecoverBall(GameObject obj)
    {
        obj.transform.parent = transform;
        obj.transform.GetComponent<Rigidbody>().Sleep();
        obj.SetActive(false);
    }

    /// <summary>
    /// �ͷű�����
    /// </summary>
    /// <returns>����������</returns>
    public GameObject GetBall()
    {
        if (transform.childCount > 0)
        {
            GameObject obj = transform.GetChild(0).gameObject;
            obj.transform.parent = null;
            obj.transform.GetComponent<Rigidbody>().WakeUp();

            obj.SetActive(true);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
