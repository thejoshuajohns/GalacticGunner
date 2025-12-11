using UnityEngine;

public class BreachZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            GameManager.Instance.LoseLife();

            Destroy(other.gameObject);
        }
    }
}