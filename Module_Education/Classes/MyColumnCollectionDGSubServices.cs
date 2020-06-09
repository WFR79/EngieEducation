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
    class MyColumnCollectionDGSubServices
    {
        [DisplayName("SubServiceId")]
        public long SubServiceId { get; set; }
        [DisplayName("Nom Sous-Service")]
        public string SubServiceName { get; set; }





        private Education_SousService _obj;

        public MyColumnCollectionDGSubServices(Education_SousService obj)
        {
            _obj = obj;
        }

        public Education_SousService GetModel()
        {
            return _obj;
        }
    }
}
