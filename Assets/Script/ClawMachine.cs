using UnityEngine;
using System.Collections;

public class ClawMachine : MonoBehaviour, IMachine
{
    public Transform point1;  // 第一个点的Transform
    public Transform point2;  // 第二个点的Transform
    public LineRenderer lineRenderer;  // LineRenderer组件
    public Transform claw;  // 爪子对象
    public float extendSpeed = 1f;  // 延伸速度
    public Animator ClawAnimator;
    private Vector3 originalPosition;
    private bool extending = false;

    private void Start()
    {
        originalPosition = point1.position;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, originalPosition);
        lineRenderer.SetPosition(1, originalPosition);
    }


    public void Activate(bool isActive)
    {
        if (isActive && !extending)
        {
            ClawAnimator.SetBool("Open", true);
            StartCoroutine(ExtendRope());
        }

    }

    IEnumerator ExtendRope()
    {
        extending = true;
        float t = 0f;
        Vector3 startPos = originalPosition;
        Vector3 endPos = point2.position;

        while (t < 1f )
        {
            t += extendSpeed * Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp(startPos, endPos, t);
            lineRenderer.SetPosition(1, newPosition);

            // 更新爪子的位置，可以根据绳子末端的位置进行调整
            claw.position = newPosition;

            yield return null;
        }
        ClawAnimator.SetBool("Open", false);
        // 等待抓取動畫
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);

        // 返回到原始位置
        StartCoroutine(RetractRope());

    }

    IEnumerator RetractRope()
    {
        float t = 0f;
        Vector3 startPos = lineRenderer.GetPosition(1);
        Vector3 endPos = originalPosition;
        
        while (t < 1f)
        {
            
            t += extendSpeed * Time.deltaTime;
            Vector3 newPosition = Vector3.Lerp(startPos, endPos, t);
            lineRenderer.SetPosition(1, newPosition);

            // 更新爪子的位置
            claw.position = newPosition;

            yield return null;
        }
        // 恢复到原始状态
        ClawAnimator.SetBool("Open", true);
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);
        ClawAnimator.SetBool("Open", false);
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);
        lineRenderer.SetPosition(1, originalPosition);
        extending = false;
    }
}

