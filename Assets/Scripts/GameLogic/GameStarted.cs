using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameStarted : MonoBehaviour
{
    public UnityAction GameIsStarted;
    
    [SerializeField] private Animator _playerAnimation;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Spawner _spawner;

    [SerializeField] private List<TMP_Text> _playerInfoText;

    [SerializeField] private Transform _heartList;

    [SerializeField] private Animation _cameraAnimation;

    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _shopPanel;

    [SerializeField] private Abilities _abilities;
    
    [SerializeField] private GameObject _pause;
    public void StartGame()
    {
        PlayerStartAnimation();
        PlayerMovingStart();
        EnemyMovingStart();
        GameIsStarted?.Invoke();
        DisplayHearts();
        DisplayText();
        CloseAllPanels();
        _abilities.OnGameStarted();
    }

    public void DisplayHearts()
    {
        for (int i = 0; i < _heartList.childCount; i++)
        {
            _heartList.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }

    private void DisplayText()
    {
        foreach (var text in _playerInfoText)
        {
            text.alpha = 1;
        }
        _pause.SetActive(true);
    }

    private void CloseAllPanels()
    {
        if (_settingsPanel.activeSelf == true || _shopPanel.activeSelf == true)
        {
            _settingsPanel.SetActive(false);
            _shopPanel.SetActive(false);
        }
    }

    private void PlayerStartAnimation()
    {
        _playerTransform.rotation = new Quaternion(0, 0, 0,0);
        _playerAnimation.SetBool("GameStarted",true);
        _cameraAnimation.Play("CameraMoveToPosition");
    }

    private void PlayerMovingStart()
    {
        _playerInput.enabled = true;
    }

    private void EnemyMovingStart()
    {
        _spawner.enabled = true;
    }
}
