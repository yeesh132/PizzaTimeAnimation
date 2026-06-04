using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LookAtIKController : MonoBehaviour
{
    [Header("Target")]
    public Transform lookTarget;

    [Header("Weights")]
    [Range(0f, 1f)] public float targetWeight = 1f;
    [Range(0f, 10f)] public float blendSpeed = 3f;

    [Header("Body Distribution")]
    [Range(0f, 1f)] public float bodyWeight = 0.2f;
    [Range(0f, 1f)] public float headWeight = 0.8f;
    [Range(0f, 1f)] public float eyesWeight = 1f;
    [Range(0f, 1f)] public float clampWeight = 0.5f;

    private Animator animator;
    private float currentWeight;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        lookTarget = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        lookTarget.position = transform.position + transform.forward * 2f + Vector3.up * 1.5f;
    }

    private void Update()
    {
        currentWeight = Mathf.Lerp(
            currentWeight,
            targetWeight,
            blendSpeed * Time.deltaTime
        );
    }

    private void OnAnimatorIK(int layerIndex)
    {
        Debug.Log("IK running");
        if (animator == null)
            return;

        if (lookTarget == null)
        {
            animator.SetLookAtWeight(0f);
            return;
        }

        animator.SetLookAtWeight(
            currentWeight,
            bodyWeight,
            headWeight,
            eyesWeight,
            clampWeight
        );

        animator.SetLookAtPosition(lookTarget.position);
    }

    public void SetTarget(Transform newTarget)
    {
        lookTarget = newTarget;
    }

    public void ClearTarget()
    {
        lookTarget = null;
    }

    public void SetWeight(float weight)
    {
        targetWeight = Mathf.Clamp01(weight);
    }
}
