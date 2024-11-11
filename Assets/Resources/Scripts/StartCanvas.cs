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
    /// 开始按钮被点击
    /// </summary>
    public void OnStartBtnClick()
    {
        m_LoadingPanel.StartLoad();
    }

    /// <summary>
    /// 进入开始按钮
    /// </summary>
    public void OnStartBtnEnter()
    {
        m_StartBtn_Transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    /// <summary>
    /// 移出开始按钮
    /// </summary>
    public void OnStartBtnExit()
    {
        m_StartBtn_Transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }

    /// <summary>
    /// 退出按钮被点击
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
    /// 进入退出按钮
    /// </summary>
    public void OnExitBtnEnter()
    {
        m_ExitBtn_Transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    /// <summary>
    /// 移出退出按钮
    /// </summary>
    public void OnExitBtnExit()
    {
        m_ExitBtn_Transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}
