using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";
        //체력
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath;

        //데미지 효과
        public GameObject damageFlash;      //피격시 플래쉬 효과
        public AudioSource hurt01;          //피격시 효과음1
        public AudioSource hurt02;          //피격시 효과음2
        public AudioSource hurt03;          //피격시 효과음3
        #endregion

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            //데미지 효과
            StartCoroutine(DamageEffect());

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        private void Die()
        {
            isDeath = true;

            fader.FadeTo(loadToScene);

            //Debug.Log("Player Death");
            //SetState(RobotState.R_Death);
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);
            int randNumber = Random.Range(1, 4);
            if (randNumber == 1)
            {
                hurt01.Play();
            }
            else if (randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }
                yield return new WaitForSeconds(1f);
                damageFlash.SetActive(false);
            }

        }
    }