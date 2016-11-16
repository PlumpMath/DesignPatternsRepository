using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Adapter.Models.Interfaces;

namespace _1_Adapter.FirstOrmLibrary {
    public interface IFirstOrm<TDbEntity> where TDbEntity : IDbEntity {
        void Create(TDbEntity entity);
        TDbEntity Read(int id);
        void Update(TDbEntity entity);
        void Delete(TDbEntity entity);
    }
}
