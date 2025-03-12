using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{

    [RequireComponent(typeof(ScreenFader))]
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] private ScreenFader _screenFader;
        [SerializeField] private float delay;

        private void Awake()
        {
            _screenFader = GetComponent<ScreenFader>();
        }

        private void Start()
        {
            _screenFader.Fade_On();
        }



        public void Fade_and_Load()
        {
            StartCoroutine(Fade_and_Reload_Routine());
        }

        private IEnumerator Fade_and_Reload_Routine()
        {
            yield return new WaitForSeconds(delay);
            _screenFader.Fade_Off();
            LevelLoader.Load_MainMenu();


            yield return new WaitForSeconds(_screenFader.FadeOn_Duration_);
            Object.Destroy(gameObject);
        }
    }

}