using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchItem : MonoBehaviour
{
    public Transform generatingPos;
    public GameObject switchPrefab;
    public GameObject Destroysymbol;
    public Transform positionForChild1; // �q����1�I���E���W�ʒu
    public Transform positionForChild2; // �q����2�I���E���W�ʒu

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("COM"))
        {
            // ���ቻPrefab
            GameObject instantiatedPrefab = Instantiate(switchPrefab, generatingPos.position, Quaternion.identity);

            if (instantiatedPrefab.transform.childCount < 2)
            {
                Debug.LogError("Prefab does not contain enough children.");
                return;
            }

            // �l��q�������ݒ葴���E���W�ʒu
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
