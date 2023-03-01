using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class Destructible : Entity
    {
        #region Properties

        [SerializeField] private bool m_indestructible;
        public bool IsIndestructible => m_indestructible;


        [SerializeField] private int m_hitpoints;
        public int Hitpoints => m_hitpoints;

        private int m_currentHitpoints;
        public int CurrentHitpoints => m_currentHitpoints;

        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_currentHitpoints = m_hitpoints;
        }

        #endregion

        #region Public API

        public void ApplyDamage(int damage)
        {
            if (m_indestructible) return;

            m_currentHitpoints -= damage;

            if (m_currentHitpoints <= 0) OnDeath();
        }

        #endregion

        protected virtual void OnDeath()
        {
            Destroy(gameObject);

            _EventOnDeath?.Invoke();
        }

        private static HashSet<Destructible> allDestructibles;

        public static IReadOnlyCollection<Destructible> AllDestructibles => allDestructibles;

        protected virtual void OnEnable()
        {
            if(allDestructibles == null) allDestructibles = new HashSet<Destructible>();

            allDestructibles.Add(this);
        }
        protected virtual void OnDestroy()
        {
            allDestructibles.Remove(this);
        }

        public const int TeamIDNeutral = 0, TeamIDAlly = 1, TeamIDEnemy = 2;

        [SerializeField] private int teamID;
        public int TeamID => teamID;

        [SerializeField] private UnityEvent _EventOnDeath;
        public UnityEvent EventOnDeath => _EventOnDeath;

        #region Score
        [SerializeField] private int score;
        public int Score => score;

        #endregion
    }
}

