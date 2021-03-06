﻿using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Repositories
{
    public class FormationCategoryDataAccess : RepositoryBase
    {
        private CFNEducation_FormationEntities db = new CFNEducation_FormationEntities();

        public FormationCategoryDataAccess()
        {

        }

        public List<Education_FormationCategory> LoadAllCategoryFormations()
        {
            return db.Education_FormationCategory.ToList();
        }
    }
}
