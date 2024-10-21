using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }
    //로봇 enemy 관리 클래스
    public class RobotController : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject thePlayer;
        private Animator animator;

        //로봇이 죽을시 배경음으로 돌아오게 만들기 위한 오디오 소스
        public AudioSource bgm01;
        public AudioSource bgm02;

        //로봇 상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float maxHealth = 20f;
        private float currentHealth;

        private bool isDeath;

        //이동
        [SerializeField] private float moveSpeed = 1.5f;

        //공격
        [SerializeField] private float attackRange = 1.5f;      //공격 가능 범위
        [SerializeField] private float attackDamage = 5f;       //공격력
        [SerializeField] private float attackTimer = 2f;       //공격 쿨타임
        private float countdown = 0f;
        #endregion

        private void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            //초기화
            SetState(RobotState.R_Idle);
            currentHealth = maxHealth;
            isDeath = false;
            countdown = attackTimer;
        }

        private void Update()
        {
            if (isDeath) return;
            //방향 구하기(타겟 지정)
            Vector3 dir = thePlayer.transform.position - this.transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }

            //로봇 상태 구현
            switch (currentState)
            {
                case RobotState.R_Idle:         //대기
                    break;
                case RobotState.R_Walk:         //플레이어를 향해 걷는다(이동)
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                    transform.LookAt(thePlayer.transform);
                    break;
                case RobotState.R_Attack:       //플레이어를 향해 공격한다
                    if (distance > attackDamage)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    //AttackOnTimer();
                    break;
            }
        }

        //private void AttackOnTimer()
        //{
        //    if (countdown < 0f)
        //    {
        //        //타이머 초기화
        //        countdown = attackTimer;
        //    }
        //    countdown -= Time.deltaTime;
        //}

        private void Attack()
        {
            PlayerController player = thePlayer.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(attackDamage);
            }
        }

        //로봇의 상태변경
        public void SetState(RobotState newState)
        {
            //현재 상태 체크
            if (currentState == newState) return;

            //이전 상태 저장
            beforeState = currentState;
            //상태변경
            currentState = newState;
            //상태변경에 따른 구현 내용
            animator.SetInteger("RobotState", (int)newState);
        }

        public void TakeDamage(float damage)
        {

            currentHealth -= damage;
            //Debug.Log(currentHealth);

            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;

            //로봇이 죽으면 등장음을 멈추고 배경음으로 돌아옴
            bgm02.Stop();
            bgm01.Play();

            Debug.Log("Robot Death");
            SetState(RobotState.R_Death);

            //죽었을때 충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }
}