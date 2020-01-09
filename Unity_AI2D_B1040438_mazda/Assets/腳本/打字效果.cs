using UnityEngine;
using System.Collections;

public class 打字效果 : MonoBehaviour
{
    public string say = "嗨，你好嗎？";

    public float[] values = new float[7];
    public int[] scores = { 100, 80, 90, 30, 40 };

    public Color[] colors = new Color[5];

    private void Start()
    {
        print("第三個字：" + say[2]);
        print("陣列的長度：" + say.Length);

        scores[2] = 60;
        print(scores[2]);

        for (int i = 1; i <= 10; i++)
        {
            //print("數字：" + i);
        }

        for (int i = 0; i < scores.Length; i++)
        {
            //print("分數陣列：" + scores[i]);
        }

        StartCoroutine(Print());
    }

    private IEnumerator Test()
    {
        print("開始!");
        yield return new WaitForSeconds(1);
        print("<color=red>一秒後~</color>");
        yield return new WaitForSeconds(2);
        print("<color=red>兩秒後~</color>");
    }

    private IEnumerator Print()
    {
        for (int i = 0; i < say.Length; i++)
        {
            print("<color=blue>" + say[i] + "</color>");
            yield return new WaitForSeconds(0.5f);
        }
    }
}