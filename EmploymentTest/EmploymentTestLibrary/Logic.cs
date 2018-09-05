using EmploymentTestDataAccessLayer;
using EmploymentTestLibrary.Model;
using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EmploymentTestLibrary
{
    public class Logic : ILogic
    {
        IDBRepository _dBRepository;

        public Logic(IDBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        /// <summary>
        /// Orchestrates the calculation of the string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CalculatedResult EmploymentTest(string input)
        {
            if (!TestForValidCalculation(input))
            {
                return new CalculatedResult()
                {
                    Answer = "An error has happened. Invalid Calculation",
                    DailyInterestCharge = ""
                };
            }         

            var answer = CalculateString(input);
            var dailyCosts = EstimateDailyCost((double)answer);

            var result = new CalculatedResult() {
                Answer = answer.ToString("C", new CultureInfo("en-AU")),
                DailyInterestCharge = dailyCosts
            };

            return result;
        }

        /// <summary>
        /// Checks if theres any letters in the string that are invalid.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool TestForValidCalculation(string input)
        {
            if(Regex.IsMatch(input, @"^[0-9+-=/*.]"))
            {
                return true;
            }

            return false;
        }   

        /// <summary>
        /// Calculates the string and returns a decimal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public decimal CalculateString(string input)
        {
            var answer = new DataTable().Compute(input, null).ToString();           
            return decimal.Parse(answer);
        }


        /// <summary>
        /// Works out daily Interest Rate.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="yearlyInterestRate"></param>
        /// <returns></returns>
        public string EstimateDailyCost(double amount)
        {
            decimal dayOfOneYear = decimal.Divide(1 , 365);
            var interestInfo = _dBRepository.GetInterestRate();

            double interest = 1 + (interestInfo.InterestRate / interestInfo.TimesPerYear);
            double period = (double)decimal.Multiply(interestInfo.TimesPerYear, dayOfOneYear);

            var result = amount * Math.Pow(interest, period);

            return (result - amount)
                        .ToString("C", new CultureInfo("en-AU"));
        }
    }
}
