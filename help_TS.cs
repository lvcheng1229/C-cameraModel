using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help_TS : MonoBehaviour
{
    float lastX, lastY;

    float yaw = -90.0f;
    float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastX = Input.mousePosition.x;
        lastY = Input.mousePosition.y;
    }
    float speed = 6f;
    // Update is called once per frame
    void Update()
    {
        objectTranslate();
        objectRotate();
    }
    void objectTranslate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 offset = new Vector3(-x, 0, -y);
        transform.Translate(Vector3.Lerp(new Vector3(0, 0, 0), offset, Time.deltaTime * speed));
    }
    void objectRotate()
    {
        float curx = Input.mousePosition.x;
        float cury = Input.mousePosition.y;
        float xoffset = curx - lastX;lastX = curx;
        float yoffset = cury - lastY;lastY = cury;

        float sensitivity = 0.05f;
        xoffset *= sensitivity;
        yoffset *= sensitivity;

        yaw += xoffset;
        pitch += yoffset;

        if (pitch > 89.0f)
            pitch = 89.0f;
        if (pitch < -89.0f)
            pitch = -89.0f;

        Vector3 front;
        float pi = 3.1415926535f;
        //pitch
        front.x =Mathf.Cos(pitch / 180 * pi);
        front.y = Mathf.Sin(pitch / 180 * pi);
        front.z = Mathf.Cos(pitch / 180 * pi);
        //yaw
        front.x *= Mathf.Cos(yaw / 180 * pi);
        front.z *= Mathf.Sin(yaw / 180 * pi);

        transform.rotation = Quaternion.LookRotation(-front);
    }
}
