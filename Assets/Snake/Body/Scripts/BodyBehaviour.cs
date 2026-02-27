using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBehaviour : MonoBehaviour, ICoroutineUpdatable, ISnake
{
    public GameObject frontObject;   // 前のオブジェクト
    private ISnake frontSnake;
    private Vector3 nextPosition;   // 次に移動する位置
    private Vector3 pastPos;

    void Start()
    {
        if (CoroutineManager.Instance != null)
        {
            CoroutineManager.Instance.Register(this);
        }
        if (frontObject != null)
        {
            frontSnake = frontObject.GetComponent<ISnake>();

            if (frontSnake == null)
            {
                Debug.LogError("ISnake を実装していません");
            }
        }
        // 初期過去位置を現在位置で初期化
        pastPos = transform.position;
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
        Move();
    }

    public void Move()
    {
        if (frontObject == null) return;
        // 前のオブジェクトの現在位置を取得
        nextPosition = frontSnake.GetPastPosition();
        // 現在位置を記録
        pastPos = transform.position;

        // 自分をそこへ移動
        transform.position = new Vector3(nextPosition.x, nextPosition.y, -2);

        Vector3 direction = frontSnake.GetCurrentPosition() - nextPosition;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public Vector3 GetPastPosition()
    {
        return pastPos;
    }

    public Vector3 GetCurrentPosition(){
        return transform.position;
    }

    public void SetFrontSnake(GameObject frontSnake)
    {
        // 前方オブジェクトとインターフェース参照を両方設定する
        this.frontObject = frontSnake;
        this.frontSnake = frontSnake.GetComponent<ISnake>();
    }
}
