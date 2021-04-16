using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using DG.Tweening;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public CinemachineVirtualCamera gameplayCamera;
    public CinemachineVirtualCamera menuCamera;

    public GameObject optionPanel;

    public CanvasGroup endPanel;

    public TextMeshProUGUI scoreText, waveText; 
    public RectTransform menuBtn;

    public Animator playerAnim;

    public bool gameStared = false;

    [HideInInspector]
    public bool gameEnded = false;

    

    public void EndGame()
    {
        gameEnded = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

#if UNITY_EDITOR
        Debug.Log("Game Ended");
#endif
        Time.timeScale = 0;
        Sequence seq = DOTween.Sequence();
        seq.Append(endPanel.DOFade(1f, 0.25f)).SetUpdate(true)
            .Append(scoreText.rectTransform.DOAnchorPos(new Vector2(0f, 154f), 1.25f, true).SetEase(Ease.OutCubic)).SetUpdate(true)
            .Append(waveText.rectTransform.DOAnchorPos(new Vector2(0f, -32f), 1.25f, true).SetEase(Ease.OutCirc)).SetUpdate(true)
            .Append(menuBtn.DOAnchorPos(new Vector2(0f, 150f), 1.5f, true).SetEase(Ease.OutCubic)).SetUpdate(true)
            .Append(DOVirtual.Float(0, WordManager.instance.score, 0.5f, (s) => scoreText.text = "final score\n<size=65%> <color=#28b5b5> " + s.ToString("00000"))).SetUpdate(true)
            .Append(DOVirtual.Float(0, WordSpawner.instance.nextWave, 0.5f, (w) => waveText.text = "You Reached\n<size=65%> <color=#28b5b5> wave " + w.ToString("000"))).SetUpdate(true);
    }

    public void Restart()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        gameEnded = false;
        Time.timeScale = 1;
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGameplay()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        optionPanel.SetActive(false);

        playerAnim.SetBool("gameStared", true);

        gameStared = true;

        gameplayCamera.Priority = menuCamera.Priority + 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
