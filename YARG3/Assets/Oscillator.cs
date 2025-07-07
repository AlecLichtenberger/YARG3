using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float pushDistance = 2f;
    public float pushDuration = 0.1f;
    public float returnDuration = 1.0f;
    public float waitTime = 0.5f;

    private Vector3 localDirection;
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        localDirection = transform.up;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Oscillate());
    }

    private System.Collections.IEnumerator Oscillate()
    {
        while (true)
        {
            yield return StartCoroutine(MoveKinematic(localDirection, pushDistance, pushDuration));
            yield return StartCoroutine(MoveKinematic(-localDirection, pushDistance, returnDuration));
            yield return new WaitForSeconds(waitTime);
        }
    }

    private System.Collections.IEnumerator MoveKinematic(Vector3 direction, float distance, float duration)
    {
        Vector3 start = startPosition;
        Vector3 end = start + direction.normalized * distance;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            Vector3 newPos = Vector3.Lerp(start, end, t);
            rb.MovePosition(newPos);
            elapsed += Time.fixedDeltaTime; // Use fixedDeltaTime for physics consistency
            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(end);
        startPosition = end;
    }
}