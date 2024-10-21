using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        //Action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion

        private void Awake()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }

        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;
            audioSource.Play();
        }

    }
}