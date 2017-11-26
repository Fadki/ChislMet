using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLabChislMeth
{
    public class Result
    {
        private int size;
        private decimal maxDifference;
        private int countOperations;
        private decimal maxNorm;

        public Result(int _size, decimal _maxDifference, int _countOperations, decimal _maxNorm)
        {
            this.size = _size;
            this.maxDifference = _maxDifference;
            this.countOperations = _countOperations;
            this.maxNorm = _maxNorm;
        }

        public override string ToString()
        {
            if (maxNorm != 404)
            {
                return string.Format("{0} \t{1} \t{2} \t{3}.", size, maxDifference.ToString("G2", CultureInfo.InvariantCulture), countOperations, maxNorm.ToString("G2", CultureInfo.InvariantCulture));
            }
                return string.Format("{0} \t{1} \t{2} \t{3}.", size, maxDifference.ToString("G2", CultureInfo.InvariantCulture), countOperations, "Выход за границы числа. Слишком большое/малое значение");
        }
    }
}
