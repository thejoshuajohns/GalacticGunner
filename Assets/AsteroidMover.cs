using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("MainCamera");

        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.linearVelocity = direction * speed;

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