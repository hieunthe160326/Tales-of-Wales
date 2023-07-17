using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform mainCameraTransform; // Tham chiếu đến transform của main camera

    private void LateUpdate()
    {
        // Cập nhật vị trí của background dựa trên vị trí hiện tại của main camera
        transform.position = new Vector3(mainCameraTransform.position.x, mainCameraTransform.position.y, transform.position.z);
    }
}
