using UnityEngine;
using UnityEngine.SceneManagement;


// ゲームの基幹クラス。ハコの生成とフラグの管理、リトライ処理を行う。
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private GameObject[] boxPrefabs;           // ハコオブジェクトのPrefabを全て持つ配列。
    private Transform boxParentTransform;           // ハコをまとめる親オブジェクトのTransform。
    [SerializeField] float spawnSpan = 1f;            // ハコが新しく生成される間隔の変数。
    private float currentTime = 0f;         // ハコの生成までのカウント変数。
    public bool inGame = true;          // ゲーム中かを示すフラグ。
    public int score = 0;           // スコア変数。


    private void Start()
    {
        // ハコオブジェクトのPrefab読み込みと、ハコの親オブジェクトのTransform取得を行う。
        boxPrefabs = Resources.LoadAll<GameObject>("Prefabs");
        boxParentTransform = GameObject.Find("Blocks").transform.parent;
    }


    private void Update()
    {
        if (inGame)
        {
            // 前回のハコ生成から一定時間経過したら
            currentTime += Time.deltaTime;
            if (currentTime > spawnSpan)
            {
                // 横方向の座標をランダム化し、その位置にハコを生成する。
                Vector3 spawnPos = new Vector3(Random.Range(-4, 5), 12, 0);
                Instantiate(boxPrefabs[Random.Range(0, 3)], spawnPos, new Quaternion(0, 180f, 0, 0), boxParentTransform);
                currentTime = 0;
            }

            score += 10;
        }
        else
        {
            // Qキーを押すとリトライする。
            if (Input.GetKey(KeyCode.Q))
            {
                Reset();
                SceneManager.LoadScene("GDC");
            }
        }
    }


    // Singleton化しているため、各変数がリセットされなかった時のための保険。
    private void Reset()
    {
        currentTime = 0f;
        score = 0;
        inGame = true;
    }
}