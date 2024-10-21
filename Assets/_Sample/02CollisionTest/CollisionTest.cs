using UnityEngine;

namespace MySample
{
    public class CollisionTest : MonoBehaviour
    {
        #region Variables
        [SerializeField] float movePower = 2f;
        #endregion

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Enter Collision = {collision.gameObject.name}");
            //왼쪽으로 힘을 준다
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
            //collision.rigidbody.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }

        private void OnCollisionStay(Collision collision)
        {
            Debug.Log($"Stay Collision = {collision.gameObject.name}");
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log($"Exit Collision = {collision.gameObject.name}");
            //왼쪽으로 힘을 준다
            MoveObject moveObject = collision.gameObject.GetComponent<MoveObject>();
            if (moveObject != null)
            {
                moveObject.MoveLeftByForce();
            }
            //collision.rigidbody.AddForce(Vector3.left * movePower, ForceMode.Impulse);
        }
    }
}