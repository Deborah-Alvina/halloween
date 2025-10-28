using UnityEngine;

public class ParentGhostHandler : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float playerSpeed;

    public int points = 0;
    public bool isRotating = false;
    public LogicScript logic;
    private GhostGroundCheck ggc;
    private int totalCoins;

    void Start()
    {
        logic = FindObjectOfType<LogicScript>();
        ggc = FindObjectOfType<GhostGroundCheck>();
        transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
        CoinSpawner spawner = FindObjectOfType<CoinSpawner>();
        if (spawner != null)
        {
            totalCoins = spawner.coinAmount;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isRotating && !ggc.over)
        {
            float moveX = Input.GetAxis("Horizontal") * playerSpeed;
            float moveZ = Input.GetAxis("Vertical") * playerSpeed;
            transform.Translate(new Vector3(moveX, 0, moveZ) * Time.fixedDeltaTime);
        }
    }

    public void IncreasePoints()
    {
        points += 1;
    }

    void Update()
    {
        if (points >= totalCoins)
        {
            logic.youWon();
            isRotating = true;
            transform.Rotate(0, 270f * Time.deltaTime, 0);
        }
    }
}