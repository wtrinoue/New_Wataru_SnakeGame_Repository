using UnityEngine;

public class AppleManager : MonoBehaviour, ICoroutineUpdatable
{
    [Header("Apple Settings")]
    [SerializeField] private GameObject applePrefab;

    [Header("Board Settings")]
    [SerializeField] private int width = 20;
    [SerializeField] private int height = 20;
    [SerializeField] private int appleCountLimit = 1;

    // BoardManagerと同じ基準
    private Vector2 startPos = new Vector2(-4f, 4f);
    private float cellScale = 0.5f;
    // りんごのカウント
    private int appleCount = 0;
    // シングルトンインスタンス
    public static AppleManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (CoroutineManager.Instance != null)
        {
            CoroutineManager.Instance.Register(this);
        }
    }

    void OnDisable()
    {
        if (CoroutineManager.Instance != null)
        {
            CoroutineManager.Instance.Unregister(this);
        }
    }

    // CoroutineManager から呼ばれる
    public void ManagedCoroutine(float interval)
    {
        SpawnApple();
    }

    private void SpawnApple()
    {
        if (applePrefab == null)
        {
            Debug.LogError("Apple Prefab が設定されていません");
            return;
        }

        if(appleCount >= appleCountLimit) return;

        int randomX = Random.Range(1, width+1);
        int randomY = Random.Range(1, height+1);

        float offset = cellScale;

        Vector3 position = new Vector3(
            startPos.x + randomX * offset,
            startPos.y - randomY * offset,
            -1
        );

        Instantiate(applePrefab, position, Quaternion.identity);
    }

    public void AddAppleCount()
    {
        appleCount += 1;
    }

    public void SubAppleCount()
    {
        appleCount -= 1;
    }
}