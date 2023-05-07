using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deptors
{
    //  For sort by name
    class Debtor_SortByName : IComparer<Debtor>
    {
        public int Compare(Debtor x, Debtor y)
        {
            return string.Compare(x.FullName, y.FullName);
        }
    }

    //  For sort by name
    class Debtor_SortByDept : IComparer<Debtor>
    {
        public int Compare(Debtor? x, Debtor? y)
        {
            if (x!.Debt < y!.Debt)
            {
                return 1;
            }
            else if (x!.Debt > y!.Debt)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    internal static class FilterFunctionsForDeptors
    {
        //  Check fullname length MIN 18 and there is 7 number MİN 2 units
        public static bool CheckNameLenghtAnd7Counts(Debtor debtor)
        {
            bool check = false;

            if (debtor.FullName.Length >= 18)
            {
                int count = 0;
                foreach (var symbol in debtor.Phone)
                {
                    if (symbol == '7')
                    {
                        count++;
                    }

                    if (count == 2)
                    {
                        check= true;
                        break;
                    }
                }
            }

            if (check)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //  Check there is not 8 number in phone
        public static bool CheckIsNot8NumberInPhone(Debtor debtor)
        {
            bool check = true;

            //  Search 8 number in phone
            foreach (var symbol in debtor.Phone)
            {
                if (symbol == '8')
                {
                    check = false;
                    break;
                }
            }

            return check;
        }

        //  Check there is symbol that its count in fullname is MIN 3
        public static bool CheckMIN3CountOfSymbol(Debtor debtor)
        {
            bool check = false;

            foreach (var MainSymbol in debtor.FullName)
            {
                int count = 0;
                foreach (var symbol in debtor.FullName)
                {
                    if (MainSymbol == symbol)
                    {
                        count++;
                    }
                }

                if (count == 3)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }

        //  Check there is no repeated number in phone
        public static bool CheckNoRepeatedNumberInPhone(Debtor debtor)
        {
            bool check = true;

            foreach (var MainNumber in debtor.Phone)
            {
                int CountMainNumber = 0;
                foreach (var number in debtor.Phone)
                {
                    if (MainNumber == number)
                    {
                        CountMainNumber++;
                        if (CountMainNumber == 2)
                        {
                            break;
                        }
                    }
                }
                if (CountMainNumber == 2)
                {
                    check = false;
                    break;
                }
            }

            return check;
        }

        //  Check pay to finish  until his birthday
        public static bool CheckFinishUntilBithday(Debtor debtor)
        {
            int TotalMonths = 0;

            if (debtor.BirthDay.Month < DateTime.Now.Month)
            {
                TotalMonths = (12 - DateTime.Now.Month) + debtor.BirthDay.Month;
            }
            else
            {
                TotalMonths = debtor.BirthDay.Month - DateTime.Now.Month;
            }
            

            if (TotalMonths * 500 >= debtor.Debt)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SearchSMILEInFullname(Debtor debtor)
        {
            bool check = false;
            bool ContainS = false, ContainM = false, ContainI = false, ContainL = false, ContainE = false;
            foreach (var symbol in debtor.FullName)
            {
                if (symbol == 's' || symbol == 'S') { ContainS = true; }
                if (symbol == 'm' || symbol == 'M') { ContainM = true; }
                if (symbol == 'i' || symbol == 'I') { ContainI = true; }
                if (symbol == 'l' || symbol == 'L') { ContainL = true; }
                if (symbol == 'e' || symbol == 'E') { ContainE = true; }
                if (ContainS && ContainM && ContainI && ContainL && ContainE) 
                { 
                    check = true;
                    break;
                }
            }
            
            return check;
        }
    }
}
