using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Realms;

namespace POC.DataBase
{
    public class PersonListDataStore : IPersonListDataStore
    {

        public async Task<bool> DeletePerson(string contactNumber)
        {
            Realm realm = GetRealm();
            var updatePerson = await Get();
            if (updatePerson != null)
            {
                foreach (Models.Person item in updatePerson)
                {
                    try
                    {
                        if (item.ContactNumber == contactNumber)
                        {
                            using (var trans = realm.BeginWrite())
                            {
                                realm.Remove(item);
                                trans.Commit();
                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            return true;
        }

        public async Task<bool> InsertOrReplace(Models.Person perosonObj)
        {
                Realm realm = GetRealm();
                realm.Write(() =>
                {
                    realm.Add(perosonObj, update: true);
                });
            
            return true;
        }

   
        public async Task<IList<Models.Person>> Get()
        {
            Realm realmDb = GetRealm();
            var data = realmDb.All<Models.Person>().ToList();
            return await Task.FromResult(data);
        }


        private Realm GetRealm()
        {
            var config = new RealmConfiguration("PersonList.realm");
            config.SchemaVersion = 2;
            config.EncryptionKey = new byte[64]
                  {
                  0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x58,
                  0x21, 0x12, 0x13, 0x84, 0x45, 0x16, 0x15, 0x78,
                  0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x23, 0x25,
                  0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x56, 0x39,
                  0x61, 0x42, 0x43, 0x54, 0x45, 0x46, 0x44, 0x46,
                  0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x15, 0x57,
                  0x81, 0x62, 0x63, 0x74, 0x65, 0x66, 0x26, 0x38,
                  0x71, 0x72, 0x89, 0x74, 0x75, 0x76, 0x77, 0x39
                  };
            return Realm.GetInstance(config);
        }
    }
}
