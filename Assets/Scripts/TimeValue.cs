using UnityEngine;
using UnityEngine.UI;

public class TimeValue : MonoBehaviour
{
    [SerializeField]
    Text myText;
    float time;

    void Update()
    {
        ConvertTime();
    }
    void ConvertTime()
    {
        time += 1 * Time.deltaTime;
        myText.text = string.Format("{0: 0} минут : {1:0} секунд", time / 60, time % 60);// счетчик времени
    }
}
