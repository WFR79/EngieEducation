using Module_Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_Education.Classes
{
    class MyColumnCollectionDGDepartement
    {
        [DisplayName("DepartementId")]
        public long DepartementId { get; set; }
        [DisplayName("Nom Département")]
        public string DepartementName { get; set; }

        private Education_Departement _obj;

        public MyColumnCollectionDGDepartement(Education_Departement obj)
        {
            _obj = obj;
        }

        public Education_Departement GetModel()
        {
            return _obj;
        }
    }
}
