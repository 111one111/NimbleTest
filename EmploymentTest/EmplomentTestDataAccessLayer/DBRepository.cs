using EmploymentTestDataAccessLayer.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmploymentTestDataAccessLayer
{
    public class DBRepository : IDBRepository
    {
        /// <summary>
        /// This is supposed to be pretending to hit a db and provide up to date data on interest rates
        /// </summary>
        /// <returns></returns>
        public Interest GetInterestRate()
        {
            return new Interest()
            {
                InterestRate = 42,
                TimesPerYear = 12
            };
        }
    }
}
