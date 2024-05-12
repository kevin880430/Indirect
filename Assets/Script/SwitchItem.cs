using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItem : MonoBehaviour
{
    public Transform generatingPos;
    public GameObject switchPrefab;
    public GameObject Destroysymbol;
    public Transform positionForChild1; // 子物件1的世界座標位置
    public Transform positionForChild2; // 子物件2的世界座標位置

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("COM"))
        {
            // 實例化Prefab
            GameObject instantiatedPrefab = Instantiate(switchPrefab, generatingPos.position, Quaternion.identity);

            if (instantiatedPrefab.transform.childCount < 2)
            {
                Debug.LogError("Prefab does not contain enough children.");
                return;
            }

            // 獲取子物件並設定其世界座標位置
            Transform child1 = instantiatedPrefab.transform.GetChild(0);
            child1.position = positionForChild1.position;

            Transform child2 = instantiatedPrefab.transform.GetChild(1);
            child2.position = positionForChild2.position;

            Destroy(Destroysymbol);
            Destroy(gameObject);
            //Destroy(gameObject); // Uncomment if you want to destroy the GameObject on collision.
        }
    }
}
