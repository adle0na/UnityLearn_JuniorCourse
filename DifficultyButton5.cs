using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton5 : MonoBehaviour
{
    // 버튼 선언
    private Button button;
    // 게임 매니저 참조
    private GameManager5 gameManager;
    // 난이도 변수
    public int difficulty;

    void Start()
    {
        // 버튼 컴포넌트, 게임 매니저 사용
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager5").GetComponent<GameManager5>();
        // 버튼 클릭시 난이도설정 함수 실행
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        // 게임 매니저에서 난이도값으로 게임 시작
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}
