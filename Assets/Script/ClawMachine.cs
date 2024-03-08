using UnityEngine;
using System.Collections;

//IMachineインターフェースを継承
public class ClawMachine : MonoBehaviour, IMachine
{
    //ひもが伸びる開始点
    public Transform startPosition;
    //ひもが伸びる終了点
    public Transform endPosition;
    // LineRendererコンポーネント
    public LineRenderer lineRenderer;
    //アームの位置
    public Transform claw;
    //ひもが伸びる速度
    public float extendSpeed = 1.5f;
    //アームのアニメーター
    public Animator ClawAnimator;
    //ひもが伸びているかどうかのフラグ
    private bool extending = false;

    private void Start()
    {
        //LineRendererの初期化、開始点と終了点の定義
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition.position);
        lineRenderer.SetPosition(1, startPosition.position);
    }

    public void Activate(bool isActive)
    {
        //ひもが伸びる時反応はしない
        if (isActive && !extending)
        {
            //アームのアニメを再生
            ClawAnimator.SetBool("Open", true);
            //ひもを伸ばす
            StartCoroutine(ExtendRope());
        }
    }

    //ひもを伸ばすコルーチン
    IEnumerator ExtendRope()
    {
        //ひもが伸びる時フラグon
        extending = true;
        //伸びるタイマーを初期化
        float t = 0f;
        //開始、終了点をベクトルに格納
        Vector3 startPos = startPosition.position;
        Vector3 endPos = endPosition.position;

        //タイマーが1になるまでひもを伸ばす
        while (t < 1f )
        {
            //タイマーを伸びる速度によって更新する
            t += extendSpeed * Time.deltaTime;
            //Lerp関数を使用してひもを滑らかに伸ばす
            Vector3 newPosition = Vector3.Lerp(startPos, endPos, t);
            //LineRendererの終点を更新する
            lineRenderer.SetPosition(1, newPosition);
            //アームの位置を更新する(ひもと共に)
            claw.position = newPosition;
            //1フレームを待つ再開
            yield return null;
        }
        //ひもが設定した場所に伸ばしたらアームを開く、ものをキャッチ
        ClawAnimator.SetBool("Open", false);
        //キャッチのアニメション再生する時間を待つ
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);
        //アニメション終わったら最初の位置に戻る
        StartCoroutine(RetractRope());

    }
    //ひもを回収するコルーチン
    IEnumerator RetractRope()
    {
        //伸びるタイマーを初期化
        float t = 0f;
        //ひもを回収するため線描画の開始点と終了点を逆にする
        Vector3 startPos = endPosition.position;
        Vector3 endPos = startPosition.position;
        
        while (t < 1f)
        {
            //タイマーを伸びる速度によって更新する
            t += extendSpeed * Time.deltaTime;
            //Lerp関数を使用してひもを滑らかに回収する
            Vector3 newPosition = Vector3.Lerp(startPos, endPos, t);
            //LineRendererの終点を更新する
            lineRenderer.SetPosition(1, newPosition);
            //アームの位置を更新する(ひもと共に)
            claw.position = newPosition;
            //1フレームを待つ再開
            yield return null;
        }
        //回収終わったら、アームを開く
        ClawAnimator.SetBool("Open", true);
        //アニメション分の時間を待つ
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);
        //アームが閉じる
        ClawAnimator.SetBool("Open", false);
        //アニメション分の時間を待つ
        yield return new WaitForSeconds(ClawAnimator.GetCurrentAnimatorStateInfo(0).length);
        //終了点を初期化
        lineRenderer.SetPosition(1, endPos);
        //伸びるフラグをoff
        extending = false;
    }
}

