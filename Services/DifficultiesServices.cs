using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Models;

namespace Services
{
    public class DifficultiesServices : IDifficultiesServices
    {
        public int DifficultyId { get; set; }
        public string DifficultyName { set; get; }

        public DifficultiesServices(int difficultyId, string difficultyName)
        {
            this.DifficultyId = difficultyId;
            this.DifficultyName = difficultyName;
        }

        public DifficultiesServices()
        {

        }

        DifficultiesRepo _difficultiesRepo = new DifficultiesRepo();

        public Difficulties Create(Difficulties difficulty)
        {
            return _difficultiesRepo.Create(difficulty);
        }

        public List<Difficulties> RetrieveAll()
        {
            DataTable dt = _difficultiesRepo.RetrieveAll();
            List<Difficulties> difficulties = new List<Difficulties>();

            foreach (DataRow dr in dt.Rows)
            {
                Difficulties difficulty = new Difficulties(
                        Convert.ToInt32(dr["difficultyId"]),
                        dr["difficultyName"].ToString()

                    ); 
                difficulties.Add(difficulty);


            }
            return difficulties;
        }

        public Difficulties RetrieveById(int difficultyId)
        {
            DataTable dt = _difficultiesRepo.RetrieveById(difficultyId);
            DataRow dr = dt.Rows[0];
            Difficulties difficulty = new Difficulties(
                Convert.ToInt32(dr["difficultyId"]),
                dr["difficultyName"].ToString()
                );
            return difficulty;
        }


        public Difficulties Update(Difficulties difficulty)
        {
            return _difficultiesRepo.Update(difficulty);
        }

    }
}
