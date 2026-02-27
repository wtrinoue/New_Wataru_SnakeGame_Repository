using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject wallPrefab;
    public int width = 20;
    public int height = 20;

    // 左上の基準位置
    private Vector2 startPos = new Vector2(-4f, 4f);

    // セルのスケール
    private float cellScale = 0.5f;

    void Start()
    {
        for (int y = 1; y < height + 1; y++)
        {
            for (int x = 1; x < width + 1; x++)
            {
                GenerateBlock(cellPrefab, cellScale, startPos, x, y);
            }
        }

        for (int x = 0; x < width + 2; x++)
        {
            GenerateBlock(wallPrefab, cellScale, startPos, x, 0);
            GenerateBlock(wallPrefab, cellScale, startPos, x, height + 1);
        }

        for (int y = 1; y < height + 2; y++)
        {
            GenerateBlock(wallPrefab, cellScale, startPos, 0, y);
            GenerateBlock(wallPrefab, cellScale, startPos, width + 1, y);
        }
    }

    public void GenerateBlock(GameObject prefab, float cellScale, Vector2 startPos, float x, float y)
    {
        GameObject cell = Instantiate(prefab);

        // スケール設定
        cell.transform.localScale = Vector3.one * cellScale;

        // セルサイズ（scale考慮）
        float offset = cellScale;

        // 左上基準なので y はマイナス方向へ
        Vector2 position = new Vector2(
            startPos.x + x * offset,
            startPos.y - y * offset
        );

        cell.transform.position = position;
    }
}