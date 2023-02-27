using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button m_Even_Btn;
    public Button m_Odd_Btn;

    public Text m_UserInfo_Text;
    public Text m_Result_Text;

    int m_Money = 1000;     // 유저의 보유 금액
    int m_WinCount = 0;     // 승리 카운트
    int m_LostCount = 0;    // 패배 카운트

    [Header("--- Gameble ---")]
    public Slider m_Gameble_Slider;
    public Text m_Gameble_Text;
    int m_Gameble = 100;        // 배팅 금액 최소 100원

    // Start is called before the first frame update
    void Start()
    {
        if (m_Even_Btn != null)
        {
            m_Even_Btn.onClick.AddListener(EvenBtnClick);
        }

        if(m_Odd_Btn != null)
        {
            m_Odd_Btn.onClick.AddListener(OddBtnClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 배팅 금액 UI 갱신
        if (1.0f <= m_Gameble_Slider.value || m_Money < 100)
            m_Gameble = m_Money;
        else
            m_Gameble = 100 + (int)(m_Gameble_Slider.value * (m_Money - 100));

        if (m_Gameble_Text != null)
            m_Gameble_Text.text = "배팅 : " + m_Gameble;
        // 배팅 금액 UI 갱신

    }

    void EvenBtnClick()     // 짝수 버튼 눌렀을 때 반응 함수
    {
        if (m_Money <= 0)
            return;     // 즉시 함수를 빠져 나가는 명령어

        //Debug.Log("짝수 버튼을 눌렀습니다.");

        //m_Result_Text.text = "짝수 버튼을 눌렀습니다.";
        
        int a_UserSel = 0;                  // 유저가 0, 짝수 선택
        int a_DiceNum = Random.Range(1, 7); // 1 ~ 6 랜덤값 발생 

        string a_StrCom = "짝수";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "홀수";

        // 판정
        if (a_UserSel == (a_DiceNum % 2))   // 맞춘 경우
        {
            m_Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞추셨습니다.";

            m_WinCount++;
            m_Money += (m_Gameble * 2); // 100;
        }
        else // 틀린 경우
        {
            m_Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀리셨습니다.";

            m_LostCount++;
            m_Money -= m_Gameble; //200;

            if (m_Money <= 0)   // 보유 게임 머니가 모두 소진 상태
            {
                m_Money = 0;
                m_Result_Text.text = "Game Over";
            }
        }
        // 판정

        // 유저 정보 UI 갱신
        if (m_UserInfo_Text != null)
            m_UserInfo_Text.text = "유저의 보유 금액 : " + m_Money + " : 승(" + m_WinCount + ")" + " : 패(" + m_LostCount + ")";


    } //void EvenBtnClick()

    void OddBtnClick()      // 홀수 버튼
    {
        if (m_Money <= 0)
            return;     // 즉시 함수를 빠져 나가는 명령어

        //Debug.Log("홀수 버튼을 눌렀습니다.");

        //m_Result_Text.text = "홀수 버튼을 눌렀습니다.";

        int a_UserSel = 1;                  // 유저가 1, 홀수 선택
        int a_DiceNum = Random.Range(1, 7); // 1 ~ 6 랜덤값 발생 

        string a_StrCom = "짝수";
        if ((a_DiceNum % 2) == 1)
            a_StrCom = "홀수";

        // 판정
        if (a_UserSel == (a_DiceNum % 2))   // 맞춘 경우
        {
            m_Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 맞추셨습니다.";

            m_WinCount++;
            m_Money += (m_Gameble * 2); //100;
        }
        else // 틀린 경우
        {
            m_Result_Text.text = "주사위 값은 (" + a_DiceNum + ") (" + a_StrCom + ") 틀리셨습니다.";

            m_LostCount++;
            m_Money -= m_Gameble; //200;

            if( m_Money <= 0)
            {
                m_Money = 0;
                m_Result_Text.text = "Game Over";
            }

        }// 판정

        // 유저 정보 UI 갱신
        if (m_UserInfo_Text != null)
            m_UserInfo_Text.text = "유저의 보유 금액 : " + m_Money + " : 승(" + m_WinCount + ")" + " : 패(" + m_LostCount + ")";

        
    }
}
