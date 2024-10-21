using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyFps
{
    public class SceneFader : MonoBehaviour
    {
        #region Variables
        //Fader 이미지
        public Image image;

        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            //초기화: 시작시 화면을 검정색으로 시작
            image.color = new Color(0f, 0f, 0f, 1f);
            //FromFade();
        }

        public void FromFade(float delayTime = 0f)
        {            
            //씬 시작시 페이드인 효과
            StartCoroutine(FadeIn(delayTime));
        }

        IEnumerator FadeIn(float delayTime)
        {
            if (delayTime > 0f)
            {
                yield return new WaitForSeconds(delayTime);
            }

            //1초동안 Image의 alphaValue 1 -> 0
            float t = 1f;

            while(t>0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }
        }

        IEnumerator FadeOut(string sceneName)
        {
            //1초동안 image a 0-> 1
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f,0f,0f,a);
                yield return 0f;
            }
            //다음Scene 로드
            SceneManager.LoadScene(sceneName);
        }
        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }
    }
}