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
    class MyColumnCollectionDGServices
    {
        [DisplayName("ServiceId")]
        public long ServiceId { get; set; }
        [DisplayName("Nom Service")]
        public string ServiceName { get; set; }





        private Education_Service _obj;

        public MyColumnCollectionDGServices(Education_Service obj)
        {
            _obj = obj;
        }

        public Education_Service GetModel()
        {
            return _obj;
        }
    }
}
