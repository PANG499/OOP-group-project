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
