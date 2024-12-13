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
    /// 回收保龄球
    /// </summary>
    /// <param name="obj">保龄球物体</param>
    public void RecoverBall(GameObject obj)
    {
        obj.transform.parent = transform;
        obj.transform.GetComponent<Rigidbody>().Sleep();
        obj.SetActive(false);
    }

    /// <summary>
    /// 释放保龄球
    /// </summary>
    /// <returns>保龄球物体</returns>
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
