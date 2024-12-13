using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    private float m_RecoverTimer = 0.0f;//���ձ������ʱ��
    private float m_RecoverInterval = 9.0f;//���ձ������ʱ����
    private bool m_IsPush = false;//�������Ƿ��ӳ�
    private bool m_IsPinKnock = false;//�������Ƿ�ײ���˱�����ƿ
    //private XRInteractorLineVisual m_InteractorLineVisual;//���������Ƿ���ʾ

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
                //���ձ�����
                RecoverBall();
            }
        }
    }

    /// <summary>
    /// ���ձ�����
    /// </summary>
    private void RecoverBall()
    {
        m_IsPush = false;
        //����ػ������������
        BallPool.Instance.RecoverBall(gameObject);
    }

    /// <summary>
    /// ץס������
    /// </summary>
    public void GrabEntered()
    {
        //�����������-1
        BallSpawn.Instance.ReduceCurrentBallCount();
        m_IsPush = false;

        //m_InteractorLineVisual.enabled = false;
    }

    /// <summary>
    /// �ӳ�������
    /// </summary>
    public void GrabExited()
    {
        m_IsPush = true;

        //m_InteractorLineVisual.enabled = true;
    }

    //����������ײʱ�Ļص�����
    private void OnCollisionEnter(Collision collision)
    {
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //    {
    //        //���ű�����ײ���ذ������
    //        AudioManager.Instance.PlayBallKnockAudio();
    //    }
    //    else if (collision.gameObject.layer == LayerMask.NameToLayer("Pin"))
    //    {
    //        if (!m_IsPinKnock)
    //        {
    //            //���ű�����ײ��ƿ������
    //            AudioManager.Instance.PlayPinKnockAudio();
    //            m_IsPinKnock = true;
    //        }

    //    }
    }
}
