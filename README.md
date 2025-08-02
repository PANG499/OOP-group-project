using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform Player;



   
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -3.52f);
    }
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = target.position;
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int point = 10;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class EnterDialog : MonoBehaviour
{

    public GameObject enterDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //enterDialog.SetActive(true);
        }
    
                
                
                
                
     }







}

using UnityEngine;

public class gameover : MonoBehaviour
{
    public GameObject over;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            over.SetActive(true);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame( )
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      }
}

using UnityEngine;
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA; // Start PointA
    [SerializeField] private Transform pointB; // End PointB
    [SerializeField] private float speed = 2f; // Movement speed of the platform

    private Vector3 targetPos;

    void Start()
    {
        // Platform starts at point A
        transform.position = pointA.position;
        // Set the initial target position to point B
        targetPos = pointB.position;
    }

    void Update()
    {
        // update the platform's position towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            //change the target position to the other point
            if (targetPos == pointB.position)
            {
                targetPos = pointA.position;
            }
            // if the target position is point A, change it to point B
            else
            {
                targetPos = pointB.position;
            }
        }
    }
}
using UnityEngine;
public class PlatformMover : MonoBehaviour
{
    // 
    public Transform pointA;
    public Transform pointB;

    // platform Move Speed
    public float speed = 2.0f;

    // Platform's current target point
    private Transform currentTarget;

    void Start()
    {
        // when the game starts, set the current target to pointB
        currentTarget = pointB;
    }

    void Update()
    {
        // use Vector2.MoveTowards to move the platform towards the current target point
        // transform.position is the current position of the platform
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // check if the platform has reached the current target point
        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            // if the platform has reached the target point, switch the target point
            if (currentTarget == pointB)
            {
                currentTarget = pointA;
            }
            // if the current target is pointA, switch it to pointB
            else
            {
                currentTarget = pointB;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpforce;
    public int dianchi;
    public Text dianchinumber;
    public AudioSource dianchiAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Movement();
    }
    //移动和跳跃
    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float facedircetion = Input.GetAxisRaw("Horizontal");

        if (horizontalmove != 0)
        {
            rb.linearVelocity = new Vector2(horizontalmove * speed *Time.deltaTime, rb.linearVelocity.y);
        }

        if (facedircetion != 0)
        { transform.localScale = new Vector3(facedircetion, 1, 1); }
        
        
        if (Input.GetButton("Jump"))

        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce * Time.deltaTime);
        }
    }
    //收集
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collection") 
        {
            dianchiAudio.Play();
            Destroy(collision.gameObject);dianchi += 1; 
            dianchinumber.text = dianchi.ToString();   
        }
    }

}

using UnityEngine;

public class playermove_2 : MonoBehaviour

{

    // ... 原有的变量 ...

    public float moveSpeed = 7f;

    public float jumpForce = 14f;

    public Transform groundCheck;

    public LayerMask groundLayer;

    public float groundCheckRadius = 0.2f;



    private Rigidbody2D rb;

    private float horizontalMove = 0f;

    private bool isFacingRight = true;

    private bool isGrounded;



    // --- 新增动画变量 ---

    private Animator anim;



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        // --- 新增: 获取Animator组件 ---

        anim = GetComponent<Animator>();

    }



    void Update()

    {

        // --- 更新动画参数: 速度 ---

        // Mathf.Abs取绝对值,因为速度没有负数

        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));



        // --- 更新动画参数: 跳跃和下落 ---

        // 检查是否在下落 (速度Y为负)

        if (rb.linearVelocity.y < -0.1f)

        {

            anim.SetBool("isJumping", false);

            anim.SetBool("isFalling", true);

        }



        // 检查是否在地面

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // 如果在地面上, 那么就不是在下落状态

        if (isGrounded)

        {

            anim.SetBool("isFalling", false);

        }



        // 处理输入

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;



        if (Input.GetButtonDown("Jump") && isGrounded)

        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // --- 更新动画参数: 触发跳跃 ---

            anim.SetBool("isJumping", true);

        }

    }



    void FixedUpdate()

    {

        // 物理移动

        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocity.y);



        // 翻转角色

        if (horizontalMove < 0 && isFacingRight)

        {

            Flip();

        }

        else if (horizontalMove > 0 && !isFacingRight)

        {

            Flip();

        }

    }



    void Flip()

    {

        isFacingRight = !isFacingRight;

        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }



}
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen_move : MonoBehaviour
{
    public string scenname;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            SceneManager.LoadScene(scenname);
        }
    }


}

using UnityEngine;
using UnityEngine.UI;

public class water_collector : MonoBehaviour
{
    private int water = 0;
    [SerializeField] private Text waterText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            Destroy(collision.gameObject);
            water++;
            waterText.text = "water : " + water;
        }
    }
}
