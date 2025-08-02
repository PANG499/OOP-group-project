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
