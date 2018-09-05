using EmploymentTestLibrary.Model;

namespace EmploymentTestLibrary
{
    public interface ILogic
    {
        /// <summary>
        /// Orchestrates the calculation of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        CalculatedResult EmploymentTest(string input);
    }
}
