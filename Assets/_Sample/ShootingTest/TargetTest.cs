using MyFps;
using UnityEngine;

namespace MySample
{
    public class TargetTest : MonoBehaviour, IDamageable
    {
        #region Variables
        //체력
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath;
        #endregion

        void Start()
        {
            //초기화
            currentHealth = maxHealth;
            isDeath = false;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log($"남은 체력 : {currentHealth}");

            //데미지 효과


            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        void Die()
        {
            isDeath = true;
            //죽음처리
            //보상 - 경험치, 돈 등등

            //죽음 효과

            Destroy(gameObject, 3f);
        }
    }
}