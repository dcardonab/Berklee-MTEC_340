using UnityEngine;

public class PaddleMovement_TitleScene : MonoBehaviour
{
    [SerializeField] static float _movementSpeed = 5.0f;
    [SerializeField] static float _yEdge = 3.75f;
    [SerializeField] int dir;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= _yEdge)
            dir *= -1;

        transform.position += new Vector3(0, _movementSpeed * dir * Time.deltaTime, 0);
    }
}
