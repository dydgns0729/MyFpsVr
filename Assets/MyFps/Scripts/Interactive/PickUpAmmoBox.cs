using UnityEngine;

namespace MyFps
{
    //AmmoBox 아이템 획득
    public class PickUpAmmoBox : Interactive
    {
        #region Variables
        //AmmoBox 아이템 획득시 지급하는 ammo 갯수
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override void DoAction()
        {
            //탄환 7개 지급
            PlayerStats.Instance.AddAmmo(giveAmmo);

            //킬
            Destroy(gameObject);
        }
    }
}