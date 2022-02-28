using UnityEngine;


/// <summary>
/// はこオブジェクトのクラス。
/// </summary>
public class BoxController : MonoBehaviour
{
    private Rigidbody myRig;
    private Rigidbody targetRig;
    [SerializeField] private GameObject nextBox;        // 次のはこオブジェクトをUnity上で設定するための変数。


    // オブジェクト生成時に呼ばれる関数。
    private void Start()
    {
       myRig = this.GetComponent<Rigidbody>();          // Rigidbodyを頻繁に使用するため、負荷軽減の為に保存する。
    }


    // 衝突したときに呼ばれる関数。
    private void OnCollisionEnter(Collision col)
    {
        // 衝突した先もはこオブジェクトなら
        if(col.gameObject.tag == this.gameObject.tag)
        {
            targetRig = col.gameObject.GetComponent<Rigidbody>();

            // はこの衝突処理が2回起きるのを防ぐため、速度の早い方のみ処理を行う。
            if (myRig.velocity.magnitude > targetRig.velocity.magnitude)
            {
                // 次の数字のはこを生成し、衝突先とこのオブジェクトを破棄する。
                Instantiate(nextBox, col.transform.position, new Quaternion(0, 180f, 0, 0));
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}