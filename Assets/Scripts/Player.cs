using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // 歩く速度
    public float moveSpeed = 5f;

    // 回転速度
    public float rotationSpeed = 360f;

    // キャラクターコントローラー
    CharacterController characterController;

    // アニメーションコントローラー
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // キャラクターコントローラーを取得する
        characterController = GetComponent<CharacterController>();

        // アニメーションコントローラーを取得する
        animator = GetComponentInChildren<Animator>();
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

        // キャクターの移動
        characterController.Move(direction * moveSpeed * Time.deltaTime);

        // アニメーション設定
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        // ドットを取ったら終了
        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dot")
        {
            // オブジェクトを削除する
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
