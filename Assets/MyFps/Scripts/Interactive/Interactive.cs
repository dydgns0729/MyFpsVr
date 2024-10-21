using TMPro;
using UnityEngine;
namespace MyFps
{
    //인터렉티브 액션 구현하는 추상클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        //ActionUI
        public GameObject actionUI;
        public TextMeshProUGUI actionTextUI;
        public GameObject extraCross;
        [SerializeField] protected string action = "Input Message";

        protected float theDistance;
        #endregion

        protected void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        private void OnMouseOver()
        {
            if (theDistance <= 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //픽업시 화살표 비활성화, 피스톨 활성화, 트리거 비활성화를 위한 Destroy
                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }

        //마우스가 벗어나면 액션 UI를 숨긴다
        private void OnMouseExit()
        {
            HideActionUI();
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionTextUI.text = "";
            extraCross.SetActive(false);
        }

        void ShowActionUI()
        {
            actionTextUI.text = action;
            actionUI.SetActive(true);
            extraCross.SetActive(true);
        }
    }
}