using System.Collections;
using TMPro;
using UnityEngine;
using StarterAssets;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables

        public GameObject thePlayer;

        public SceneFader fader;

        //Sequence UI
        public TextMeshProUGUI textBox;
        [SerializeField] string sequence01 = "...Where am I?";
        [SerializeField] string sequence02 = "I need get out of here...";

        public AudioSource line01;
        public AudioSource line02;
        #endregion

        private void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //0.플레이 캐릭터움직임 비 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            //thePlayer.SetActive(false);

            //1.페이드인 연출(1초 대기후 페인드인 효과)
            fader.FromFade(4f);  //delayTime + 화면이 보이는 시간(5초)

            //2.화면 하단에 시나리오 텍스트 화면 출력(3초)
            //  (I need get out of here)
            textBox.gameObject.SetActive(true);
            textBox.text = sequence01;
            line01.Play();

            yield return new WaitForSeconds(3f);
            textBox.text = sequence02;
            line02.Play();
            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(false);

            //4.플레이 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            //thePlayer.SetActive(true);
        }
    }
}