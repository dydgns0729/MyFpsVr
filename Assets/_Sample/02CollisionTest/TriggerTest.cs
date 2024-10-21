using UnityEngine;

namespace MySample
{
    public class TriggerTest : MonoBehaviour
    {
        #region Variables
        [SerializeField] float movePower = 2f;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Enter Trigger = {other.name}");
            //오른쪽으로 힘을 주고 컬러를 빨간색으로 바꾼다
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ChangeRedColor();
            }
            //Rigidbody rb =other.attachedRigidbody;
            //rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);

        }
        private void OnTriggerStay(Collider other)
        {
            Debug.Log($"Stay Trigger = {other.name}");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log($"Exit Trigger = {other.name}");
            //오른쪽으로 힘을 주고 컬러를 원래색으로 바꾼다
            MoveObject moveObject = other.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveRightByForce();
                moveObject.ResetColor();
            }
            //Rigidbody rb = other.attachedRigidbody;
            //rb.AddForce(Vector3.right * movePower, ForceMode.Impulse);
        }

    }
}