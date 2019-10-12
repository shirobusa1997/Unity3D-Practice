using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
	// クラスメンバ
	public float 		minHeight;
	public float 		maxHeight;
	public GameObject	pivot;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeHeight(){
    	float height = Random.Range(minHeight, maxHeight);
    	pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

	void OnScrollEnd(){
		ChangeHeight();
	}    
}
