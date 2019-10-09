using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
	// クラスメンバ宣言
	public float speed = 1.0f;		// オブジェクトをスクロールさせるスピード
	public float startPosition ;	// 
	public float endPosition;		// 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 毎フレームごとにポジションを少しずつ移動させます。
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // スクロールが目標ポイントまで到達したかをチェックします。
        if (transform.position.x <= endPosition) ScrollEnd();
    }

    void ScrollEnd()
    {
    	// スクロールする距離分を戻します。
    	transform.Translate(-1 * (endPosition - startPosition), 0, 0);

    	// 同じGameObjectにアタッチされているコンポーネントにメッセージ通知を行います。
    	// DontRequireReceiverオプションにより、受信側メソッドが存在しない場合でも、エラーをパスします。
    	SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
