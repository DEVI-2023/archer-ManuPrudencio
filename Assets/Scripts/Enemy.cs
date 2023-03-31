using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cu�ntas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        // M�todo que se llamar� cuando el enemigo reciba un impacto
        public void Hit()
        {
            this.animator.SetTrigger("Hit");
            hitPoints--;
        }

        private void Die()
        {
            this.animator.SetTrigger("Die");
        }

        private void OnTriggerEnter(Collider other)
            {
                Hit();
                    if (hitPoints == 0)
                {
                Die();    
                Destroy(this.gameObject, 2f);

                }
               
            }
        }
    }

