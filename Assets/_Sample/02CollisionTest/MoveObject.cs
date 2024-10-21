using UnityEngine;

namespace MySample
{
    public class MoveObject : MonoBehaviour
    {
        #region Variables
        Rigidbody rb;

        //이동관련 변수
        [SerializeField] float movePower = 5f;
        private float moveX;

        //색 변경
        private Material material;
        private Color originColor;
        #endregion
        void Awake()
        {
            //참조
            rb = GetComponent<Rigidbody>();
            material = GetComponent<Renderer>().material;
            
            //초기화
            originColor = material.color;
            MoveRightByForce();
        }

        void Update()
        {
            //입력
            //moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            //좌우로 힘을 줘서 이동
            //rb.AddForce(Vector3.right*moveX*movePower, ForceMode.Force);
        }

        public void MoveRightByForce()
        {
            rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }

        public void MoveLeftByForce()
        {
            rb.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }

        public void ChangeRedColor()
        {
            material.color = Color.red;
        }

        public void ResetColor()
        {
            material.color = originColor;
        }

    }
}