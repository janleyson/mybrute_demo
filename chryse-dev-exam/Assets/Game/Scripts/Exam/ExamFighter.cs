using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam {

    //fighter data
    public class ExamFighter {

        public string name;
        public int hp;
        public int str;
        public int agi; //evasion, precision
        public int spd; //initiative

        public int currenthp;

        public ExamFighter(string n, int h, int s, int a, int sp)
        {
            this.name = n;
            this.hp = h;
            this.str = s;
            this.agi = a;
            this.spd = sp;
            this.currenthp = h;
        }

        public void Reset()
        {
            this.currenthp = this.hp;
        }

        public void Damage(int damage)
        {
            this.currenthp = Mathf.Clamp(currenthp - damage, 0, this.hp);
        }
    }
}