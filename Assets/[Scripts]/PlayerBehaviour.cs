using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 2/0f;
    public Boundary boundaries;
    public float verticalPosition;
    public Camera camera;

    void Start()
    {
        camera = Camera.main;
    }


    void Update()
    {
        //ConventionalInput();
        Move();
        MobileInput();
    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            transform.position = camera.ScreenToWorldPoint(touch.position);
        }
    }
    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }

    public void Move()
    {
        float clampledPosition = Mathf.Clamp(transform.position.x, boundaries.min, boundaries.max);
        transform.position = new Vector2(clampledPosition, verticalPosition);
    }
}
