using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Adapter.Models.Interfaces;


namespace _1_Adapter.Models.Interfaces {
    public class DbUserEntity: IDbEntity {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public int UserInfoId { get; set; }
    }
}
