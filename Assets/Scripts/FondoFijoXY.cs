using UnityEngine;

public class FondoFijoXY : MonoBehaviour
{
    public Transform cam;

    void LateUpdate()
    {
        transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);
    }
}