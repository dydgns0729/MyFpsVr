using UnityEngine;

namespace MySample
{
    public class AnimatorBlendTest : MonoBehaviour
    {
        #region Variables
        Animator animator;
        string moveName = "MoveState";
        [SerializeField] float moveSpeed = 5.0f;

        //입력값
        private float moveX;
        private float moveY;
        #endregion
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //앞뒤좌우 입력 처리
            moveX = Input.GetAxis("Horizontal");
            moveY = Input.GetAxis("Vertical");

            //이동: 방향, 속도
            Vector3 dir = new Vector3(moveX, 0f, moveY);

            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

            //AnimatorStateTest();
            AnimationBlendTest();
        }

        void AnimatorStateTest()
        {
            if (moveX == 0f && moveY == 0f)
            {
                //대기
                animator.SetInteger(moveName, 0);
            }
            else if (moveY > 0f)
            {
                //앞방향
                animator.SetInteger(moveName, 1);
            }
            else if (moveY < 0f)
            {
                //뒤방향
                animator.SetInteger(moveName, 2);
            }
            else if (moveX < 0f)
            {
                //왼쪽방향
                animator.SetInteger(moveName, 3);
            }
            else if (moveX > 0f)
            {
                //오른쪽방향
                animator.SetInteger(moveName, 4);
            }
        }

        void AnimationBlendTest()
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }

    }
}