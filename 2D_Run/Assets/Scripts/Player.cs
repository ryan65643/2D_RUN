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
    [Header("速度"), Range(0, 1000)]
    public int speed = 4;
    [Header("血量")]
    public float hp = 100;
    [Header("金幣數量")]
    public int coin;
    [Header("跳躍高度"), Range(0, 1000)]
    public int hight = 200;
    [Header("角色動畫")]
    public Animator Ani;
    public AudioClip SJ;
    public AudioClip SS;
    public AudioClip SH;
    public bool dead;
    public CapsuleCollider2D cc2D;
    public Rigidbody2D rig;
    public bool isGround;
    #endregion


    #region 方法
    private void Move()
    {
        if (rig.velocity.magnitude < 10)
        {
            rig.AddForce(new Vector2(speed, 0));
        }
    }
    /// <summary>
    /// 角色跳躍
    /// </summary>
    private void Jump()
    {
        bool key = Input.GetKey(KeyCode.LeftAlt);
        Ani.SetBool("跳躍開關", !isGround);
        if (isGround)
        {
            if (key)
            {
                rig.AddForce(new Vector2(0, hight));
                isGround = false;
            }

        }
    }
    /// <summary>
    /// 角色滑行
    /// </summary>
    private void Slide()
    {
        bool key = Input.GetKey(KeyCode.LeftControl);
        Ani.SetBool("滑行開關", key);
        if (key)
        {
            cc2D.offset = new Vector2(-0.3369139f, -0.4f);
            cc2D.size = new Vector2(4.638223f, 6f);
        }
        else
        {
            cc2D.offset = new Vector2(-0.3369139f, -0.4360113f);
            cc2D.size = new Vector2(4.638223f, 6.112195f);
        }
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
        Slide();
    }
    /// <summary>
    /// 固定更新 一秒50次 有剛體建議用
    /// </summary>
    private void FixedUpdate()
    {
        Move();
        Jump();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }

        if (collision.gameObject.name == "懸浮地板")
        {
            isGround = true;
        }

    }




}
