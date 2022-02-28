using UnityEngine;


// プレイヤーオブジェクト。
public class PlayerScript : MonoBehaviour
{
    private Rigidbody myRig;            // 移動するためのRigidbody変数。
    private float movePower = 1f;           // 移動量を設定する変数。
    public bool ableToJump = true;         // ジャンプ可能かを示すフラグ。

    void Start()
    {
        myRig = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 左移動。
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRig.AddForce(-10f * movePower, 0, 0);
        }

        // 右移動。
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRig.AddForce(10f * movePower, 0, 0);
        }

        // ジャンプ。
        if (ableToJump) 
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRig.AddForce(0, 260f, 0);
                ableToJump = false;
            }
        }
    }
}