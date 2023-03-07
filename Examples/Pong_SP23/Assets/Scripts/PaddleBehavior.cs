using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] KeyCode upButton;
    [SerializeField] KeyCode downButton;

    [SerializeField] float velocity = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (GameBehavior.Instance.CurrentState == State.Play)
        {
            if (Input.GetKey(upButton) && transform.position.y < 3.5f)
            {
                transform.position += new Vector3(
                    0,
                    velocity * Time.deltaTime,
                    0
                );
            }

            else if (Input.GetKey(downButton) && transform.position.y > -3.5f)
            {
                transform.position -= new Vector3(  
                    0,
                    velocity * Time.deltaTime,
                    0
                );
            }
        }
    }
}