using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        //문열기
        public GameObject theDoor;

        //오디오 재생
        public AudioSource doorBang;
        public AudioSource bgm01;//메인씬 1번 배경음
        public AudioSource bgm02;//적 등장 배경음

        //Enemy(Robot) 활성화
        public GameObject theRobot;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        //트리거 작동시 플레이
        IEnumerator PlaySequence()
        {
            //문열기
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문열기 사운드, 배경음 멈추기
            bgm01.Stop();
            doorBang.Play();

            //Enemy 등장
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            //적등장 사운드
            bgm02.Play();

            RobotController robot = theRobot.transform.GetComponent<RobotController>();
            if (robot != null)
            {
                robot.SetState(RobotState.R_Walk);
            }

            //트리거 제거
            Destroy(this.gameObject);
        }
    }
}