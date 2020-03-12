using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework.MVC;

namespace Exam {
    public class ExamController : Controller {

        public ExamModel model;
        public ExamView view;

        public override void OnNotification(string p_event, Object p_target, params object[] p_data)
        {

        }

        public void FightButton()
        {
            if(model.battleFinished)
            {
                view.ClearDisplay();

                //start new battle
                ExamEvent e = model.StartBattle();
                view.DisplayEvent(e);

                view.hero = model.heroLeader;
                view.enemy = model.enemyLeader;
            } else
            {
                ExamEvent e = model.BattleTurn();
                view.DisplayEvent(e);

                e = model.BattleEndCheck();
                view.DisplayEvent(e);

                view.UpdateText();
            }
        }
    }
}