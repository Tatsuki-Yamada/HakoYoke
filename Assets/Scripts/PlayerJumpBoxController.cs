using UnityEngine;


// プレイヤーが地面に付いている判定をするオブジェクト。
public class PlayerJumpBoxController : MonoBehaviour
{
    [SerializeField] GameObject player;         // プレイヤーに追従するため、Playerオブジェクトを保存する変数。
    private PlayerScript playerScript;          // Playerスクリプトの変数を操作する頻度が高いため、負荷軽減のために保存する変数。
    private Vector3 offset = new Vector3(0, -0.3f, 0);          // プレイヤーの座標からずらす差分の変数。


    void Start()
    {
        Application.targetFrameRate = 90;           // フレームレート固定
        playerScript = player.GetComponent<PlayerScript>();
    }


    void Update()
    {
        if (GameManager.Instance.inGame)
        {
            this.transform.position = player.transform.position + offset;
        }
    }


    void OnTriggerEnter (Collider other)
    {
        // 接触したオブジェクトがハコか床なら
        if (other.gameObject.tag == "1" || other.gameObject.tag == "2" || other.gameObject.tag == "3" || other.gameObject.tag == "StageFloor")
        {
            playerScript.ableToJump = true;
        }
    }
}