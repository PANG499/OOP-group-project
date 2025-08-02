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