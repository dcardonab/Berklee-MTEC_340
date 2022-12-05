using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabPickup : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pickup"))
        {
            GameObject.Find("ScoreText").GetComponent<UpdateScore>().Score++;
            SceneManager.LoadScene(0);
        }
    }
}
