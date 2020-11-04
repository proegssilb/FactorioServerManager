using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;
using BaseMigrationAttribute = FluentMigrator.MigrationAttribute;

namespace FactorioServerManager.DataStore
{
    public class MigrationAttribute : BaseMigrationAttribute
    {
        public MigrationAttribute(int year, int month, int day, int series, int step, string description = "", TransactionBehavior behavior = TransactionBehavior.Default)
            : base(ComputeVersion(year, month, day, series, step), behavior, description)
        {

        }

        private static long ComputeVersion(int year, int month, int day, int series, int step)
        {
            long dateBit = year * 1_00_00
                + month * 1_00
                + day;

            long orderBit = series * 1_0000 + step;

            return dateBit * 1_0000_0000 + orderBit;
        }
    }
}
