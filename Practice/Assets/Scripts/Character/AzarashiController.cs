using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarashiCOntroller : MonoBehaviour
{
	// クラスメンバ
	// 対象にアタッチされているRigidBody2Dコンポーネント
	Rigidbody2D currentRigidbody;					

	// 最高高度
	public float maxHeight;
	// 飛び上がる速度
	public float flapVelocity;

	// 対象の持つRigidbody2Dコンポーネントを取得し、保持します。
	void Awake(){
		currentRigidbody = GetComponent<Rigidbody2D>();
	}

	// フレーム更新ごとに実行される処理を定義します。
	void Update(){
		// 最高高度に到達しているかチェックし、到達していれば入力をブロックします。
		if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
		{
			Flap();
		}
	}

	// 対象に加速度を与え、飛び上がらせます。
	public void Flap(){
		// 速度パラメータを直接変更し、上方向に加速させます。
		currentRigidbody = new Vector2(0.0f, flapVelocity);
		
	}	
}