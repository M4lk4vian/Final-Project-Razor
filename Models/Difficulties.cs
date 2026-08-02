using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Difficulties
    {
        public int DifficultyId {  get; set; }
        public string DifficultyName { set; get; }

        public Difficulties() { }

        public Difficulties(string difficultyName)
        {
            this.DifficultyName = difficultyName;
        }

        public Difficulties(int difficultyId, string difficultyName)
        {
            this.DifficultyId = difficultyId;
            this.DifficultyName = difficultyName;
        }

    }
}
