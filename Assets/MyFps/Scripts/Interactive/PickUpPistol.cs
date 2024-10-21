using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        #region Variables
        //Action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoUI;
        public GameObject ammoBox;
        #endregion

        protected override void DoAction()
        {
            //픽업시 화살표 비활성화, 피스톨 활성화, 트리거 비활성화를 위한 Destroy
            realPistol.SetActive(true);
            arrow.SetActive(false);
            ammoUI.SetActive(true);
            ammoBox.SetActive(true);
            //총을 잡으면, 문을 열수있는 트리거 활성화
            enemyTrigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}