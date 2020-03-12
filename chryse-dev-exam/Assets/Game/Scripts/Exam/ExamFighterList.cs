using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exam {
    public class ExamFighterList : MonoBehaviour {

        public List<ExamFighter> fighterList;

        private void Start()
        {
            this.fighterList = new List<ExamFighter>();

            this.fighterList.Add(new ExamFighter("Hero", 20, 4, 3, 2));
            this.fighterList.Add(new ExamFighter("Helper", 12, 2, 1, 1));

            this.fighterList.Add(new ExamFighter("Orc", 25, 3, 2, 4));
            this.fighterList.Add(new ExamFighter("Goblin", 13, 1, 2, 1));
        }
    }
}