using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.MVC;

namespace Exam {
    public class ExamModel : Model {

        private ExamFighterList fighterList;

        public bool battleFinished { get; private set; }

        public void FighterVsFighter(ExamFighter attacker, ExamFighter defender, out bool hit, out int damage)
        {
            int misschance = Mathf.Clamp(defender.agi - attacker.agi, 0, 100);
            int rng = Random.Range(0, 100);

            //Debug.Log(string.Format("Rng {0} - Miss Chance {1}", rng, misschance));

            if(rng < misschance)
            {
                //miss
                hit = false;
                damage = 0;
            } else
            {
                //hit
                damage = (int)(Mathf.Clamp(attacker.str, 0, Mathf.Infinity));
                defender.Damage(damage);
                hit = true;
            }
        }

        private SortedList<int, ExamFighter> initiative;
        private ExamFighter currentFighter;

        private List<ExamFighter> heroSide;
        public ExamFighter heroLeader { get; private set; }

        private List<ExamFighter> enemySide;
        public ExamFighter enemyLeader { get; private set; }

        private int initiativeIndex;

        public ExamEvent StartBattle() 
        {
            this.initiative = new SortedList<int, ExamFighter>();
            this.initiativeIndex = 0;

            ResetBothSides();

            foreach (ExamFighter f in this.heroSide)
            {
                int init = Random.Range(10, 50) - f.spd;
                while(this.initiative.ContainsKey(init))
                {
                    init++;
                }
                this.initiative.Add(init, f);
            }

            foreach (ExamFighter f in this.enemySide)
            {
                int init = Random.Range(10, 50) - f.spd;
                while (this.initiative.ContainsKey(init))
                {
                    init++;
                }
                this.initiative.Add(init, f);
            }

            ExamEvent e = new ExamEvent();
            e.message = "Battle Start! Initiatives:\n";

            foreach(KeyValuePair<int,ExamFighter> x in initiative)
            {
                e.message += string.Format("{0} - {1}\n", x.Key, x.Value.name);
            }

            this.battleFinished = false;

            return e;
        }

        public ExamEvent BattleTurn()
        {
            bool hit;
            int damage;
            int init = this.initiative.Keys[initiativeIndex % this.initiative.Count];

            ExamFighter attacker = this.initiative[init];

            ExamFighter defender;

            if (this.heroSide.Contains(attacker))
            {
                defender = this.enemySide[Random.Range(0, this.enemySide.Count)];

            } else
            {
                defender = this.heroSide[Random.Range(0, this.heroSide.Count)];
            }
            FighterVsFighter(attacker, defender, out hit, out damage);

            ExamEvent e = new ExamEvent();
            e.message = string.Format("{0} attacks {1}!\n", attacker.name, defender.name);
            if(hit)
            {
                e.message += string.Format("{0} deals {1} to {2}\n", attacker.name, damage, defender.name);
            } else
            {
                e.message += string.Format("{0} misses {1}", attacker.name, defender.name);
            }

            initiativeIndex++;

            return e;
        }

        public ExamEvent BattleEndCheck()
        {
            ExamEvent e = new ExamEvent();

            if(heroLeader.currenthp <= 0)
            {
                e.message = "Your leader is defeated! You Lose!";
                
                this.battleFinished = true;
            } else if(enemyLeader.currenthp <= 0)
            {
                e.message = "Enemy leader is defeat! You Won!";
                this.battleFinished = true;
            } else
            {
                e.message = "";
            }

            return e;
        }

        public void ResetBothSides()
        {
            foreach (ExamFighter f in this.heroSide)
            {
                f.Reset();
            }

            foreach (ExamFighter f in this.enemySide)
            {
                f.Reset();
            }
        }

        private void Start()
        {
            this.fighterList = GetComponent<ExamFighterList>();

            this.heroSide = new List<ExamFighter>();
            this.enemySide = new List<ExamFighter>();

            this.heroSide.Add(this.fighterList.fighterList[0]);
            this.heroSide.Add(this.fighterList.fighterList[1]);
            this.enemySide.Add(this.fighterList.fighterList[2]);
            this.enemySide.Add(this.fighterList.fighterList[3]);

            this.heroLeader = this.fighterList.fighterList[0];
            this.enemyLeader = this.fighterList.fighterList[2];

            battleFinished = true;
        }
    }
}