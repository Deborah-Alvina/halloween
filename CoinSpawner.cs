using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private BoxCollider groundCollider;
    [SerializeField] public int coinAmount = 20;

    public static Vector3 RandomPointInBounds(Bounds bounds, float border = 1f)
    {
        return new Vector3(
            Random.Range(bounds.min.x + border, bounds.max.x - border),
            2.5f,
            Random.Range(bounds.min.z + border, bounds.max.z - border)
        );
    }

    void Start()
    {
        for (int i = 0; i < coinAmount; i++)
        {
            Vector3 startPos = RandomPointInBounds(groundCollider.bounds);
            Instantiate(coinPrefab, startPos, Quaternion.identity);
        }
    }
}