using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

namespace Snake
{
    public class snk_GameManager : MonoBehaviour
    {



        //game loop
        private float _frequency = 5;
        private Coroutine _gameLoopCoroutine;

        //singleton
        public static snk_GameManager Instance { get; private set; }

        //events
        public event Action OnTick;
        public event Action OnFruitGathered;
        public event Action<PlayerInfo> OnGameOver;

        public TileBase fruitTile;
        [Header("References")]
        [SerializeField] private snk_MainText mainUIText;

        [Header("Parameters")]
        [SerializeField] private int fruitCount = 3;

        private List<snk_SnakeCharacter> snakes = new();

        bool GameOver = false;

        //Tilemap


        //game manager
        void Awake()
        {
            //singleton
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

        }

        private IEnumerator Start()
        {
            //feedbacks fruits
            OnFruitGathered += () => PostProcessController.instance.E_ExposureFlash.play();
            OnFruitGathered += () => PostProcessController.instance.E_ScreenDistortion.play();
            OnGameOver += (PlayerInfo winner) => PostProcessController.instance.FadeOut.play();

            PostProcessController.instance.FadeIn.play();

            //spawn fruits
            for (int i = 0; i < fruitCount; i++) spawnNewFruit();

            //countdown
            for (int i = 3; i > 0; i--)
            {
                mainUIText.setText(i.ToString());

                yield return new WaitForSeconds(.7f);

                PostProcessController.instance.E_ScreenDistortion.play();
                PostProcessController.instance.E_ExposureFlash.play();

            }
            mainUIText.setText("");
            PostProcessController.instance.E_ScreenDistortion.play();
            PostProcessController.instance.E_ExposureFlash.play();

            //lancement du jeu
            _gameLoopCoroutine = StartCoroutine(Loop());

        }

        public void InvokeOnFruitGathered()
        {
            OnFruitGathered?.Invoke();
            _frequency += 0.3f;
            spawnNewFruit();
        }

        private void spawnNewFruit()
        {
            snk_TilemapHandler.Instance.SetTileAt(snk_TilemapHandler.Instance.freeTiles[UnityEngine.Random.Range(0, snk_TilemapHandler.Instance.freeTiles.Count - 1)], fruitTile);
        }

        private IEnumerator Loop()
        {
            while (enabled)
            {
                yield return new WaitForSeconds(1f / _frequency);
                OnTick?.Invoke();
            }
        }

        public void RegisterSnake(snk_SnakeCharacter snake)
        {
            snakes.Add(snake);
        }
        public void UnRegisterSnake(snk_SnakeCharacter snake)
        {
            snakes.Remove(snake);
            if (snakes.Count <= 1)
            {
                triggerGameOver(snakes[0]._PlayerInfo);
            }
        }

        private void triggerGameOver(PlayerInfo WinerPlayerInfo)
        {
            GameOver = true;
            StopCoroutine(_gameLoopCoroutine);
            OnGameOver?.Invoke(WinerPlayerInfo);
        }

        private void Update()
        {
            if (GameOver)
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}