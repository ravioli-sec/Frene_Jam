using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    [SerializeField] string NextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TruePlayer" && !General.isTeleporting)
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
