using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Blaster : MonoBehaviour
{
    [Header("Settings")]
    public float maxDistance = 100f;
    public Transform muzzlePoint;
    public InputActionProperty fireInput;

    [Header("Visuals")]
    public LineRenderer laserBeam;
    public float laserDuration = 0.1f;

    private bool _hasFired = false;

    void Start()
    {
        laserBeam.enabled = false;
    }

    void Update()
    {
        float triggerValue = fireInput.action.ReadValue<float>();

        if (triggerValue > 0.5f && !_hasFired)
        {
            StartCoroutine(FirePulse());
            _hasFired = true;
        }

        else if (triggerValue < 0.5f)
        {
            _hasFired = false;
        }
    }

    IEnumerator FirePulse()
    {
        laserBeam.enabled = true;
        laserBeam.SetPosition(0, muzzlePoint.position);

        RaycastHit hit;
        if (Physics.Raycast(muzzlePoint.position, muzzlePoint.forward, out hit, maxDistance))
        {
            laserBeam.SetPosition(1, hit.point);

            if (hit.transform.CompareTag("Asteroid"))
            {
                Debug.Log("Asteroid Hit!");

                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            laserBeam.SetPosition(1, muzzlePoint.position + muzzlePoint.forward * maxDistance);
        }

        yield return new WaitForSeconds(laserDuration);

        laserBeam.enabled = false;
    }
}