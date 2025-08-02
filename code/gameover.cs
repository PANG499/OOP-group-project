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
