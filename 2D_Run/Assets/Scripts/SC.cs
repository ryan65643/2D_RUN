using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 場景切換
/// </summary>
public class SC : MonoBehaviour
{

    /// <summary>
    /// 場景切換
    /// </summary>
    public void ScenceChang()
    {
        SceneManager.LoadScene("遊戲關卡");
    }
    public void DeleyLoad()
    {
        Invoke("ScenceChang",0.5f);

    } 
}


