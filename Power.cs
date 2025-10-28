using UnityEngine;

public class Power : MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer powerRenderer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        powerRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ParentGhostHandler gh = other.GetComponent<ParentGhostHandler>();

        if (gh == null && other.transform.parent != null)
        {
            gh = other.transform.parent.GetComponent<ParentGhostHandler>();
        }

        if (gh != null && powerRenderer != null && powerRenderer.enabled)
        {
            gh.IncreasePoints();
            powerRenderer.enabled = false;

            if (audioSource != null)
            {
                audioSource.Play();
                Destroy(gameObject, audioSource.clip.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}