using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_Adapter.Models.Interfaces;
using _1_Adapter.Models;
using _1_Adapter.FirstOrmLibrary;
using _1_Adapter.SecondOrmLibrary;


namespace _1_Adapter {
    class Program {
        class SecondOrmAdapter<Type>: IFirstOrm<IDbEntity> {
            ISecondOrm smth;
            public SecondOrmAdapter(ISecondOrm s) {
                smth=s;
            }
            public void Create(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Creating entity of ORM2 <DbUser>");
                    smth.Context.Users.Add(new DbUserEntity());
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Creating entity of ORM2 <DbUserInfo>");
                    smth.Context.UserInfos.Add(new DbUserInfoEntity());
                }
                else throw new NotImplementedException("Не тип БД");
            }
            public void Update(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Updating entity of ORM2 <DbUser>");
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Updating entity of ORM2 <DbUserInfo>");
                }
                else throw new NotImplementedException("Не тип БД");
            }
            public void Delete(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Deleting entity of ORM2 <DbUser>");
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Deleting entity of ORM2 <DbUserInfo>");
                }
                else throw new NotImplementedException("Не тип БД");
            }

            public IDbEntity Read(int id) {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args) {
            Client<DbUserEntity> client = new Client<DbUserEntity>();
            ConcreteFirst<DbUserEntity> first = new ConcreteFirst<DbUserEntity>();
            ConcreteSecond<DbUserEntity> second = new ConcreteSecond<DbUserEntity>();


            client.Create(first);   //метод Create() не знает с какой БД работает
            SecondOrmAdapter<DbUserEntity> adapter = new SecondOrmAdapter<DbUserEntity>(second);
            client.Create(adapter);

            Console.Read();
        }
        class Client<Type> {
            public ISecondOrm orm;
            int Id;

            public void Create(IFirstOrm<IDbEntity> first) {
                if (typeof(Type)==typeof(DbUserEntity))
                    first.Create(new DbUserEntity());
                else if (typeof(Type)==typeof(DbUserInfoEntity))
                    first.Create(new DbUserInfoEntity());

                else throw new NotImplementedException("Не тип БД");
            }
            public void Delete(IFirstOrm<IDbEntity> first) {
                if (typeof(Type)==typeof(DbUserEntity))
                    first.Delete(new DbUserEntity());
                else if (typeof(Type)==typeof(DbUserInfoEntity))
                    first.Delete(new DbUserInfoEntity());

                else throw new NotImplementedException("Не тип БД");
            }
            public void Update(IFirstOrm<IDbEntity> first) {
                if (typeof(Type)==typeof(DbUserEntity))
                    first.Update(new DbUserEntity());
                else if (typeof(Type)==typeof(DbUserInfoEntity))
                    first.Update(new DbUserInfoEntity());

                else throw new NotImplementedException("Не тип БД");
            }
            public IDbEntity Read(int id) {
                Id=id;
                if (typeof(Type)==typeof(DbUserEntity))
                    return new DbUserEntity();
                else if (typeof(Type)==typeof(DbUserInfoEntity))
                    return new DbUserInfoEntity();

                else throw new NotImplementedException("Не тип БД");
            }
        }
        class ConcreteFirst<Type>: IFirstOrm<IDbEntity> {
            int Id;
            public void Create(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Creating entity of ORM1 <DbUser>");
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Creating entity of ORM1 <DbUserInfo>");
                }

                else throw new NotImplementedException("Не тип БД");
            }
            public void Update(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Updating entity of ORM1 <DbUser>");
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Updating entity of ORM1 <DbUserInfo>");
                }

                else throw new NotImplementedException("Не тип БД");
            }
            public void Delete(IDbEntity entity) {
                if (typeof(Type)==typeof(DbUserEntity)) {
                    Console.WriteLine("Deleting entity of ORM1 <DbUser>");
                }
                else if (typeof(Type)==typeof(DbUserInfoEntity)) {
                    Console.WriteLine("Deleting entity of ORM1 <DbUserInfo>");
                }

                else throw new NotImplementedException("Не тип БД");
            }
            public IDbEntity Read(int id) {
                Id=id;
                if (typeof(Type)==typeof(DbUserEntity))
                    return new DbUserEntity();
                else if (typeof(Type)==typeof(DbUserInfoEntity))
                    return new DbUserInfoEntity();

                else throw new NotImplementedException("Не тип БД");
            }
        }
        class ConcreteSecond<Type>: ISecondOrm {
            public ISecondOrmContext Context {
                get {
                    if (typeof(Type)==typeof(DbUserEntity))
                        return new ConcreteSecondContext<DbUserEntity>();
                    else if (typeof(Type)==typeof(DbUserInfoEntity))
                        return new ConcreteSecondContext<DbUserInfoEntity>();

                    else throw new NotImplementedException("Не тип БД");
                }
            }
        }
        class ConcreteSecondContext<Type>: ISecondOrmContext {
            public HashSet<DbUserEntity> Users => new HashSet<DbUserEntity>();
            public HashSet<DbUserInfoEntity> UserInfos => new HashSet<DbUserInfoEntity>();
        }
    }
}
