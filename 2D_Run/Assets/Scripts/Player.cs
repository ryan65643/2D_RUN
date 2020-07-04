using UnityEngine;

public class Player : MonoBehaviour
{


    /*
     * 
     * 多行註解
     * 
     * // 單行註解
     */

    #region 區域註解
    [Header("速度"), Range(100, 1000)]
    public int speed = 100;
    [Header("血量")]
    public float hp = 100;
    [Header("金幣數量")]
    public int coin;
    [Header("跳躍高度")]
    public int hight = 400;
    public AudioClip SJ;
    public AudioClip SS;
    public AudioClip SH;
    public bool dead;

    #endregion

    #region 方法
    /// <summary>
    /// 角色跳躍
    /// </summary>
    private void Jump()
    {
        print("1");
    }
    /// <summary>
    /// 角色滑行
    /// </summary>
    private void Slide()
    {
        print("12");
    }
    /// <summary>
    /// 角色碰撞
    /// </summary>
    private void Hit()
    {

    }
    /// <summary>
    /// 角色吃金幣
    /// </summary>
    private void Eatcoin()
    {

    }
    /// <summary>
    /// 角色死亡
    /// </summary>
    private void Dead()
    {

    }
    #endregion
    private void Start()
    {
        
    }
    private void Update()
    {
        print(Random.Range(0f,1f));
    }

}
