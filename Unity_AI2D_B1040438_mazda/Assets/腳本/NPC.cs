using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum state
    {
        start, notComplete, complete
    }

    public state _state;

    [Header("對話")]
    public string sayStart = "請幫我蒐集十顆鑽石";
    public string sayNotComplete = "還沒找到十顆鑽石";
    public string sayComplete = "謝謝找到鑽石";

    public float speed = 0.1f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    public AudioClip soundSay;

    private AudioSource aud;

    public static NPC count;
    public GameObject final;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        count = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "主角")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "主角")
            SayClose();
    }

    /// <summary>
    /// 對話：打字效果
    /// </summary>
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish)
        {
            _state = state.complete;
            Invoke("END", 3f);
        } 


        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(sayStart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            aud.PlayOneShot(soundSay, 0.6f);
            yield return new WaitForSeconds(speed);
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public void PlayerGet()
    {
        countPlayer++;
    }
    public void END()
    {
        final.SetActive(true);
    }
}
