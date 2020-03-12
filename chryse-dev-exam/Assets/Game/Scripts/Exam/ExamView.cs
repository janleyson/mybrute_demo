using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework.MVC;

namespace Exam
{
    public class ExamView : View
    {
        public Text debugText;

        public Text heroText;
        public Slider heroSlider;
        public ExamFighter hero;

        public Text enemyText;
        public Slider enemySlider;
        public ExamFighter enemy;

        public void DisplayEvent(ExamEvent ev)
        {
            this.debugText.text += ev.message;
        }

        public void UpdateText() {
            this.heroText.text = string.Format("Hero: {0}/{1}", this.hero.currenthp, this.hero.hp);
            //this.heroSlider.value = (float)(this.hero.hp) / (float)(this.hero.currenthp);
            this.heroSlider.maxValue = this.hero.hp;
            this.heroSlider.value = this.hero.currenthp;

            this.enemyText.text = string.Format("Enemy: {0}/{1}", this.enemy.currenthp, this.enemy.hp);
            //this.enemySlider.value = (float)(this.enemy.hp) / (float)(this.enemy.currenthp);
            this.enemySlider.maxValue = this.enemy.hp;
            this.enemySlider.value = this.enemy.currenthp;
        }

        public void ClearDisplay()
        {
            this.debugText.text = "";
        }
    }
}