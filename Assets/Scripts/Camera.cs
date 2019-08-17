using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターの移動量を取得する。(GetAxis: -1.0〜1.0の間の移動量)
        // Horizontal: 左右のキー
        // Vertical: 上下のキー
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        // キャラクターの向きの調整
        // 右と上のキーを同時に押した場合は両方のベクトルの総和を計算する。(右: 1.0^2 + 左: 1.0^2 = 2)
        // 上のキーのみ押した場合はそのベクトルが出力される(1.0^2 = 1)
        if (direction.sqrMagnitude > 0.01f)
        {
            // forward: ゲームオブジェクトが向いている方向
            Vector3 forward = Vector3.Slerp(
                // 現在の向きからキャラクターの移動量まで
                transform.forward,
                direction,
                1.0f);

            // キャラクターの方向転換
            transform.LookAt(transform.position + forward);
        }

        transform.position = direction + player.transform.position + positionOffset;

        //characterController.Move(direction * moveSpeed * Time.deltaTime);
    }
}
