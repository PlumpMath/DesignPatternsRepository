using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using _1_Adapter.Models;
using _1_Adapter.Models.Interfaces;

namespace _1_Adapter.SecondOrmLibrary {
    public interface ISecondOrm {
        ISecondOrmContext Context { get; }
    }

    public interface ISecondOrmContext {
        HashSet<DbUserEntity> Users { get; }
        HashSet<DbUserInfoEntity> UserInfos { get; }
    }
}
