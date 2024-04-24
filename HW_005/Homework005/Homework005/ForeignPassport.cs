using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework005
{
    internal class ForeignPassport
    {
        public string PassportNumber { get; set; }
        public string OwnerName { get; set; }
        public DateTime IssueDate { get; set; }

        public ForeignPassport(string passportNumber, string ownerName, DateTime issueDate)
        {

            if (!IsValidPassportNumber(passportNumber))
            {
                throw new ArgumentException("Incorrect passport number");
            }


            PassportNumber = passportNumber;
            OwnerName = ownerName;
            IssueDate = issueDate;
        }


        private bool IsValidPassportNumber(string passportNumber)
        {
            if (passportNumber.Length != 8)
            {
                return false;
            }

           
            for (int i = 0; i < 2; i++)
            {
                if (!char.IsLetter(passportNumber[i]))
                {
                    return false;
                }
            }

           
            for (int i = 2; i < passportNumber.Length; i++)
            {
                if (!char.IsDigit(passportNumber[i]))
                {
                    return false;
                }
            }

            return true;



        }


    }
}

