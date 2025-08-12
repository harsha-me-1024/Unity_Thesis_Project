using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private bool lookAtTarget = true;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (!target) return;

        // Smooth damp for stable follow
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / followSpeed);

        // Smooth look at target
        if (lookAtTarget)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
