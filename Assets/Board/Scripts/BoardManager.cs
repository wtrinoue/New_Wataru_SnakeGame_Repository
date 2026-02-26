using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public int width = 20;
    public int height = 20;

    // 左上の基準位置
    private Vector2 startPos = new Vector2(-4f, 4f);

    // セルのスケール
    private float cellScale = 0.5f;

    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject cell = Instantiate(cellPrefab);

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
    }
}