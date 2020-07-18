using UnityEngine;
using UnityEngine.UI;

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
    public float speed = 5.5f;
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
    public Text textcoin;
    public Image imahp;
    private float hpmax;
    public AudioSource aud;
    public GameObject gam;
    public Text texttitle;
    public Text textc;
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
                aud.PlayOneShot(SJ);
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
        hp -= 30;
        imahp.fillAmount = hp / hpmax;
        if (hp<=0)
        {
            Dead();
        }
    }
    /// <summary>
    /// 角色吃金幣
    /// </summary>
    private void Eatcoin(Collider2D collision)
    {
        coin++;
        Destroy(collision.gameObject);
        textcoin.text = "COIN:" + coin;
    }
    /// <summary>
    /// 角色死亡
    /// </summary>
    private void Dead()
    {
        if (dead) return;
        speed = 0;
        dead = true;
        Ani.SetTrigger("死亡");
        gam.SetActive(true);
        textc.text = "COIN:" + coin;

    }
    #endregion
    private void Pass()
    {

        gam.SetActive(true);
        texttitle.text = "恭喜過關";
        textc.text = "COIN:" + coin;
        speed = 0;
        rig.velocity = Vector3.zero;
    }
    private void Start()
    {
        hpmax = hp;

    }
    private void Update()
    {
        if (dead) return;
        Slide();
        if (transform.position.y<=-5)
        {
            Dead();
        }
    }
    /// <summary>
    /// 固定更新 一秒50次 有剛體建議用
    /// </summary>
    private void FixedUpdate()
    {
        if (dead) return;
        Move();
        Jump();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
        if (collision.gameObject.name == "懸浮地板" && transform.position.y +1> collision.gameObject.transform.position.y)
        {
            isGround = true;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="coin")
        {
            Eatcoin(collision);
        }

        if (collision.tag == "item")
        {
            Hit();
          
        }
        if (collision.name == "傳送門")
        {
            Pass();

        }
        
    }




}
