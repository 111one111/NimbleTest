using EmploymentTestDataAccessLayer.DBModels;

namespace EmploymentTestDataAccessLayer
{
    /// <summary>
    /// This is supposed to be pretending to hit a db and provide up to date data on interest rates
    /// </summary>
    /// <returns></returns>
    public interface IDBRepository
    {
        Interest GetInterestRate();
    }
}