using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] KeyCode DownKey = KeyCode.DownArrow;
    [SerializeField] KeyCode UpKey = KeyCode.UpArrow;

    [SerializeField] float Speed = 5.0f;
    float _yLimit;

    void Start() {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        
        _yLimit = Utilities.SetYLimit(cam, renderer);
    }
    
    void Update()
    {
        if (GameBehavior.Instance.State == GameBehavior.GameState.Play) {
            if (Input.GetKey(UpKey) && transform.position.y < _yLimit) {
                transform.position += new Vector3(0.0f, Speed * Time.deltaTime, 0.0f);
            }

            if (Input.GetKey(DownKey) && transform.position.y > -_yLimit) {
                transform.position -= new Vector3(0.0f, Speed * Time.deltaTime, 0.0f);
            }
        }
    }
}
