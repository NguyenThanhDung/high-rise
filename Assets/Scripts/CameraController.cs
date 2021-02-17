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
            float verticalRotation = (Input.GetAxis("Mouse Y") * (-this.rotateSpeed) * Time.deltaTime);
            this.transform.Rotate(this.transform.right, verticalRotation, Space.World);
            float horizontalRotation = Input.GetAxis("Mouse X") * this.rotateSpeed * Time.deltaTime;
            this.transform.Rotate(Vector3.up, horizontalRotation, Space.World);
        }
    }
}
