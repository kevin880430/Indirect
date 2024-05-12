using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMachine : MonoBehaviour, IMachine
{
    private bool isTriggered = false;
    public Transform targetPosition; // 牆壁移動的目標位置
    public GameObject Wall; // 控制的牆壁物體
    public float speed = 1.0f; // 牆壁移動速度
    private bool movingToB = false; // 控制移動方向
    private Vector3 startPosition; // 牆壁的起始位置

    void Start()
    {
        startPosition = Wall.transform.position; // 在遊戲開始時記錄起始位置
    }

    public void Activate(bool isActive)
    {
        if (!movingToB) // 只有在牆壁不在移動時才允許激活
        {
            isTriggered = isActive;
            movingToB = true; // 開始移動
        }
    }

    void Update()
    {
        if (movingToB)
        {
            Vector3 target = isTriggered ? targetPosition.position : startPosition; // 根據觸發狀態選擇目標位置
            Wall.transform.position = Vector3.MoveTowards(Wall.transform.position, target, speed * Time.deltaTime);

            // 檢查是否到達目標位置
            if (Wall.transform.position == target)
            {
                movingToB = false; // 停止移動
                isTriggered = !isTriggered; // 反轉觸發狀態以準備下一次激活
            }
        }
    }
}
