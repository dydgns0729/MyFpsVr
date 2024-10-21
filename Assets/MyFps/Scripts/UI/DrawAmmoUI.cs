using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DrawAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoCount;
        #endregion
        private void Update()
        {
            ammoCount.text = PlayerStats.Instance.AmmoCount.ToString();
        }
    }
}