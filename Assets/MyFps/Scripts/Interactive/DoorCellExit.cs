using UnityEngine;

namespace MyFps
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene02";

        private Collider m_Collider;
        private Animator animator;      //문열리는 애니메이터
        public AudioSource creakyDoor;  //문여는 사운드
        public AudioSource bgm01;       //컨트롤할 배경음
        #endregion

        private void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            //1. 문여는 애니메이션
            animator.SetBool("IsOpen", true);
            //2. 문여는 사운드
            creakyDoor.Play();
            //3. 콜라이더 제거
            m_Collider.enabled = false;

            ChangeScene();
        }

        void ChangeScene()
        {
            //씬마무리, .....
            //배경음 제거
            bgm01.Stop();
            //씬 전환
            fader.FadeTo(loadToScene);

        }
    }
}