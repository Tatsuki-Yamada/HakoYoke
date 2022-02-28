using UnityEngine;


// プレイヤーの上部にのみある、押しつぶされた判定をするオブジェクト。
public class PlayerHitBoxController : MonoBehaviour
{
    [SerializeField] GameObject player;         // プレイヤーに追従するため、Playerオブジェクトを保存する変数。
    [SerializeField] GameObject deadEffect;         // 死亡時のエフェクトを設定する変数。
    private Vector3 offset = new Vector3(0, 0.4f, 0);           // プレイヤーの座標からずらす差分の変数。


    private void Update()
    {
        if (GameManager.Instance.inGame)
        {
            this.transform.position = player.transform.position + offset;
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        // ハコと衝突したとき
        if (other.gameObject.tag == "1" || other.gameObject.tag == "2" || other.gameObject.tag == "3")
        {
            // ゲーム中フラグを消し、死亡エフェクトを生成する。
            GameManager.Instance.inGame = false;
            Instantiate(deadEffect, player.transform.position, new Quaternion(0, 180f, 0, 0));
            Destroy(player);
        }

        // Amazingが出たとき
        if (other.gameObject.tag == "Amazing")
        {
            GameObject.Find("Canvas").GetComponent<TextScript>().Amazing();
            GameManager.Instance.inGame = false;
        }
    }
}