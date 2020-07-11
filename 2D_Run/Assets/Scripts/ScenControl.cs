using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 場景切換
/// </summary>
public class ScenControl : MonoBehaviour
{
    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>
    /// 場景切換
    /// </summary>
    public void ScenceChang()
    {
        SceneManager.LoadScene("選單");
    }
    /// <summary>
    /// 延遲載入
    /// </summary>
    public void DeleyLoad()
    {
        Invoke("ScenceChang", 1f);
    }

    public void DeleyQuit()
    {
        Invoke("Quit", 1f);

    }

}
