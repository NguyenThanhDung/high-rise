using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 100f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            Rotate(mouseX, mouseY);
        }
    }

    private void Rotate(float mouseX, float mouseY)
    {
        float horizontalRotation = mouseX * this.rotateSpeed * Time.deltaTime;
        this.transform.Rotate(Vector3.up, horizontalRotation, Space.World);
        float verticalRotation = mouseY * (-this.rotateSpeed) * Time.deltaTime;
        this.transform.Rotate(this.transform.right, verticalRotation, Space.World);
    }
}
