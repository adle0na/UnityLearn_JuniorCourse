using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager5 : MonoBehaviour
{
// public 변수들
#region public variables
    // 게임오버 텍스트 지정 사용 선언
    public TextMeshProUGUI gameOverText;
    // 리스트 배열값의 targets 지정 사용 선언
    public List<GameObject> targets;
    // 점수 텍스트 지정 사용 선언
    public TextMeshProUGUI scoreText;
    // 게임 동작 불변수 선언
    public bool isGameActive;
    // 버튼 지정 사용 선언
    public Button restartButton;
#endregion

// private 변수들
#region private variable
    // 스폰 간격 1초
    private float spawnRate = 1.0f;
    // 점수값
    private int score;
#endregion

// 함수들
#region Functions
    void Start()
    {
        // SpawnTarget코루틴 실행
        StartCoroutine(SpawnTarget());
        // 스코어 0으로 시작
        score = 0;
        // UpdateScore함수 0값으로 실행
        UpdateScore(0);
        // 게임 동작상태 On
        isGameActive = true;
    }
    
    // 게임오버 함수
    public void GameOver()
    {
        // 재시작 버튼, 게임오버 텍스트 켜주고 게임 동작상태 Off
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // SpawnTarget 코루틴 함수
    IEnumerator SpawnTarget()
    {
        // isGameActive가 참일시 반복 동작
        while(isGameActive)
        {
            // 스폰 간격을 딜레이로
            yield return new WaitForSeconds(spawnRate);
            // 배열 랜덤 범위 0 ~ 타켓수 만큼
            int index = Random.Range(0, targets.Count);
            // 소환
            Instantiate(targets[index]);
        }
    }

    // 스코어 업데이트 함수 파라미터는 더할 점수
    public void UpdateScore(int scoreToAdd)
    {
        // 스코어에 더할점수를 더한다
        score += scoreToAdd;
        // 스코어 글자 표시
        scoreText.text = "Score: " + score;
    }
    
    // 재시작 함수
    public void RestartGame()
    {
        // 현재 실행되고 있는 Scene재시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
#endregion
}

