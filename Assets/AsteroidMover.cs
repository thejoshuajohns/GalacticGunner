using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float maxSpeed = 20f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("MainCamera");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Rigidbody rb = GetComponent<Rigidbody>();

            int currentScore = GameManager.Instance.score;

            float bonusSpeed = currentScore / 50f;

            float finalSpeed = Mathf.Clamp(baseSpeed + bonusSpeed, baseSpeed, maxSpeed);

            rb.linearVelocity = direction * finalSpeed;

            rb.angularVelocity = Random.insideUnitSphere * 2f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}