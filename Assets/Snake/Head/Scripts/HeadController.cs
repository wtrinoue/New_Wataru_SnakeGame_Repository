using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity 2022.3.50f1
public class HeadController : MonoBehaviour, ICoroutineUpdatable, ISnake
{
    // 現在の進行方向
    private Vector2Int direction = Vector2Int.right;
    private Vector2Int nextDirection = Vector2Int.right;
    private Vector2Int pastDirection = Vector2Int.right;
    private Vector3 pastPos;

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

    public void ManagedCoroutine(float interval)
    {
        Debug.Log("進みました！");
        Move();
    }

    void Update()
    {
        // 上
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2Int.up;
        }
        // 下
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2Int.down;
        }
        // 左
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2Int.left;
        }
        // 右
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2Int.right;
        }
    }

    public void Move()
    {
        if(direction == -pastDirection)
        {
            nextDirection = pastDirection;
        }
        else
        {
            nextDirection = direction;
        }
        // 現在位置を取得
        Vector3 currentPos = transform.position;
        // 現在位置を記録
        pastPos = transform.position;

        // 1マス進む（1ユニット進む想定）
        Vector3 newPos = currentPos + new Vector3(nextDirection.x, nextDirection.y, 0) * 0.5f;

        transform.position = newPos;

        float angle = Mathf.Atan2(nextDirection.y, nextDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        pastDirection = nextDirection;
    }

    public Vector3 GetPastPosition()
    {
        return pastPos;
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public void SetFrontSnake(GameObject frontSnake){}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Headタグが付いているか確認
        if (other.CompareTag("Body"))
        {
            SceneLoader.Instance.SceneLoad("ResultScene");
        }
    }
}