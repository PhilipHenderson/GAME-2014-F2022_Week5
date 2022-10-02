using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 2/0f;
    public Boundary boundaries;
    public float verticalPosition;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        float y = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);
        float clampledPosition = Mathf.Clamp(transform.position.x, boundaries.min, boundaries.max);
        transform.position = new Vector2(clampledPosition, verticalPosition);
    }
}
