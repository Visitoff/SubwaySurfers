using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    Text myText;
    [SerializeField]
    KeyCode bonusTimeButton;
    [SerializeField]
    KeyCode bonusScoreButton;
    int bonusValueTime = 3;
    float time;
    int bonusTime = 3;
    int bonusScoreValue = 3;
    int bonusScoreTime = 3;
    int scoreRate = 1;
    float score;
   

    void Update()
    {
        BonusOfTime();
        BonusX();
    }
    void BonusOfTime()
    {//вывод текста бонусов
        myText.text = string.Format("{0} \r\n \r\n {1}\r\n Ваши очки: {2:0}", bonusValueTime, bonusScoreValue, score);
        time += Time.deltaTime;
        if (Input.GetKeyDown(bonusTimeButton) && bonusValueTime > 0)//замедление времене
        {
            bonusValueTime--;
            time = 0;
            Time.timeScale = 0.5f;
        }
        if (bonusTime <= time)
        {
            Time.timeScale = 1f;
        }
    }
    void BonusX()
    {
        score += scoreRate * Time.deltaTime;
        if (Input.GetKeyDown(bonusScoreButton) && bonusScoreValue >= 1)//удвоение очков
        {
            scoreRate = 2;//модификатор умножения очков 
            time = 0;
            bonusScoreValue--;
            score += scoreRate * Time.deltaTime;
        }
        if (bonusScoreTime <= time)
        {
            scoreRate = 1;
        }
    }
}
