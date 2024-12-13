using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    private float m_RecoverTimer = 0.0f;//回收保龄球计时器
    private float m_RecoverInterval = 9.0f;//回收保龄球的时间间隔
    private bool m_IsPush = false;//保龄球是否被扔出
    private bool m_IsPinKnock = false;//保龄球是否撞击了保龄球瓶
    //private XRInteractorLineVisual m_InteractorLineVisual;//控制射线是否显示

    private void Start()
    {
        //m_InteractorLineVisual = GameObject.Find("RightHand Controller").GetComponent<XRInteractorLineVisual>();
    }

    private void Update()
    {
        if (m_IsPush)
        {
            m_RecoverTimer += Time.deltaTime;
            if (m_RecoverTimer > m_RecoverInterval)
            {
                m_RecoverTimer = 0.0f;
                m_IsPush = false;
                m_IsPinKnock = false;
                //回收保龄球
                RecoverBall();
            }
        }
    }

    /// <summary>
    /// 回收保龄球
    /// </summary>
    private void RecoverBall()
    {
        m_IsPush = false;
        //缓冲池回收这个保龄球
        BallPool.Instance.RecoverBall(gameObject);
    }

    /// <summary>
    /// 抓住保龄球
    /// </summary>
    public void GrabEntered()
    {
        //保龄球的数量-1
        BallSpawn.Instance.ReduceCurrentBallCount();
        m_IsPush = false;

        //m_InteractorLineVisual.enabled = false;
    }

    /// <summary>
    /// 扔出保龄球
    /// </summary>
    public void GrabExited()
    {
        m_IsPush = true;

        //m_InteractorLineVisual.enabled = true;
    }

    //保龄球发生碰撞时的回调方法
    private void OnCollisionEnter(Collision collision)
    {
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        //播放保龄球撞击地板的声音
    //        AudioManager.Instance.PlayBallKnockAudio();
    //    }
    //    else if (collision.gameObject.layer == LayerMask.NameToLayer("Pin"))
    //    {
    //        if (!m_IsPinKnock)
    //        {
    //            //播放保龄球撞击瓶的声音
    //            AudioManager.Instance.PlayPinKnockAudio();
    //            m_IsPinKnock = true;
    //        }

    //    }
    }
}
