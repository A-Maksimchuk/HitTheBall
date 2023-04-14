using System;
using HitTheBall.SceneManagement;
using TMPro;
using UnityEngine;
using Zenject;

namespace HitTheBall.Infrastructure
{
    public class Boot : MonoBehaviour
    {
        public static bool IsLoadingCompleteCorrectly { get; private set; }
        [SerializeField] private TextMeshProUGUI loadingProgressLog;
        private SceneManager _sceneManager;
        
        [Inject]
        private void Init(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        private async void Start()
        {
            loadingProgressLog.text = "Loading Game";
            IsLoadingCompleteCorrectly = true;
            await _sceneManager.LoadGameScene();
        }
    }
}
