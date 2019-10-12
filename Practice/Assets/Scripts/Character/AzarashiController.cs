using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AzarashiController : MonoBehaviour
{
	// クラスメンバ
	// 対象にアタッチされているRigidBody2Dコンポーネント
	Rigidbody2D  currentRigidbody;
	// 対象にアタッチするアニメーター
	Animator	 currentAnimator;
	// 対象の姿勢(角度)
	float 		 angle;
	// 死亡判定
	bool 		 isDead;

	// 最高高度
	public float maxHeight;
	// 飛び上がる速度
	public float flapVelocity;
	public float relativeVelocity_X;
	public GameObject sprite;

	// 対象の持つRigidbody2Dコンポーネントを取得し、保持します。
	void Awake(){
		currentRigidbody = GetComponent<Rigidbody2D>();
		currentAnimator	 = sprite.GetComponent<Animator>();
	}

	// フレーム更新ごとに実行される処理を定義します。
	void Update(){
		// 最高高度に到達しているかチェックし、到達していれば入力をブロックします。
		if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
		{
			Flap();
		}

		ApplyAngle();

		currentAnimator.SetBool("Is flap", angle >= 0.0f);
	}

	public bool IsDead(){
		return isDead;
	}

	// 対象に加速度を与え、飛び上がらせます。
	public void Flap(){
		// 死亡しているか、重力が働いていない場合、入力を無効にします。
		if (isDead || currentRigidbody.isKinematic) return;

		// 速度パラメータを直接変更し、上方向に加速させます。
		currentRigidbody.velocity = new Vector2(0.0f, flapVelocity);

	}

	void ApplyAngle(){
		float targetAngle;

		if (isDead)
		{
			targetAngle = -90.0f;
		}
		else
		{
			targetAngle = Mathf.Atan2(currentRigidbody.velocity.y, relativeVelocity_X) * Mathf.Rad2Deg;
		}

		angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

		sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
	}

	void OnCollisionEnter2D(Collision2D collision2d){
		if (isDead) return;

		Camera.main.SendMessage("Clash");

		isDead = true;
	}

	public void SetSteerActive(bool active){
		// RigidBodyのオン・オフ
		currentRigidbody.isKinematic = !active;
	}
}