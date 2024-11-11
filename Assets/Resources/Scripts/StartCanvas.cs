using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartCanvas : MonoBehaviour
{
    private Transform m_StartBtn_Transform;
    private Transform m_ExitBtn_Transform;
    private LoadingPanel m_LoadingPanel;

    // Start is called before the first frame update
    void Start()
    {
        m_StartBtn_Transform = transform.Find("StartPanel/StartButton");
        m_ExitBtn_Transform = transform.Find("StartPanel/ExitButton");
        m_LoadingPanel = transform.GetComponentInChildren<LoadingPanel>();
    }

    /// <summary>
    /// ��ʼ��ť�����
    /// </summary>
    public void OnStartBtnClick()
    {
        m_LoadingPanel.StartLoad();
    }

    /// <summary>
    /// ���뿪ʼ��ť
    /// </summary>
    public void OnStartBtnEnter()
    {
        m_StartBtn_Transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    /// <summary>
    /// �Ƴ���ʼ��ť
    /// </summary>
    public void OnStartBtnExit()
    {
        m_StartBtn_Transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }

    /// <summary>
    /// �˳���ť�����
    /// </summary>
    public void OnExitBtnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    /// <summary>
    /// �����˳���ť
    /// </summary>
    public void OnExitBtnEnter()
    {
        m_ExitBtn_Transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    /// <summary>
    /// �Ƴ��˳���ť
    /// </summary>
    public void OnExitBtnExit()
    {
        m_ExitBtn_Transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}
