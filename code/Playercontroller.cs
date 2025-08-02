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
