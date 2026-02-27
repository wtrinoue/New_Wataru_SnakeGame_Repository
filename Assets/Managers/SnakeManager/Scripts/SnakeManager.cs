using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static SnakeManager Instance { get; private set; }
    public GameObject snakeHead;
    public GameObject bodyPrefab;
    private GameObject snakeTail;
    // Start is called before the first frame update
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
        SetSnakeTail(snakeHead);
    }

    public void SetSnakeTail(GameObject snakeTail)
    {
        this.snakeTail = snakeTail;
    }

    public GameObject GetSnakeTail()
    {
        return snakeTail;
    }

    public void GenerateBody(GameObject frontSnake)
    {
        var frontISnake = frontSnake.GetComponent<ISnake>();

        Vector3 pastPosition = frontISnake.GetPastPosition();
        Vector3 currentPosition = frontISnake.GetCurrentPosition();

        // 方向ベクトル
        Vector3 direction = currentPosition - pastPosition;

        Quaternion rotation = Quaternion.identity;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.Euler(0, 0, angle);
        }

        Vector3 generatePosition = new Vector3(pastPosition.x, pastPosition.y, -2);

        GameObject body = Instantiate(
            bodyPrefab,
            generatePosition,
            rotation
        );

        var bodySnake = body.GetComponent<ISnake>();
        bodySnake.SetFrontSnake(frontSnake);

        SetSnakeTail(body);
    }
}
