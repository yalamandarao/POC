using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.DataBase
{
    public interface IPersonListDataStore
    {
        /// <summary>
        /// Get Person List
        /// </summary>
        /// <returns></returns>
        Task<IList<Models.Person>> Get();

        /// <summary>
        /// Delete the Person 
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <returns></returns>
        Task <bool> DeletePerson(string contactNumber);

        /// <summary>
        /// Add or Edit
        /// </summary>
        /// <param name="perosonObj"></param>
        /// <returns></returns>
        Task<bool> InsertOrReplace(Models.Person perosonObj);


    }
}
