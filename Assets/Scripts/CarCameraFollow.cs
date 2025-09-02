using UnityEngine;

public class CarCameraFollow : MonoBehaviour
{
    [Header("Target to Follow")]
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
