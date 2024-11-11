using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPanel : MonoBehaviour
{
    Animation m_Animation;
    AsyncOperation m_Ao;
    private void Start()
    {
        m_Animation = GetComponent<Animation>();
        transform.localScale = Vector3.zero;
    }

    /// <summary>
    /// ��ʼ����
    /// </summary>
    public void StartLoad()
    {
        transform.DOScale(Vector3.one, 0.3f).OnComplete(() => {
            StartCoroutine(LoadScene());
        });
    }
    /// <summary>
    /// ������Ϸ����
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadScene()
    {
        m_Animation.Play();
        m_Ao = SceneManager.LoadSceneAsync("GameScene");
        m_Ao.allowSceneActivation = false;

        yield return new WaitForEndOfFrame();
    }
    /// <summary>
    /// ������Ϸ����
    /// </summary>
    public void AllowSceneActive()
    {
        m_Ao.allowSceneActivation = true;
    }
}
