using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostReg
{
    public static class TestValue
    {
        public static int testPSGVNO(int value)
        {
            if (value < 0 && value > 9999)
                throw new OverflowException("#f#PSGVNO# Привышение максимального значения! (Макс 4 цифры и больше 0)");
            return value;
        }
        public static String testPSBARC(String value)
        {
            if (value.Length>13)
                throw new OverflowException("#f#PSBARC# Привышение максимального значения! (Макс 13 символов)");
            return value;
        }
        public static int testRCCN3C(int value)
        {
            if (value < 0 && value > 999)
                throw new OverflowException("#f#RCCN3C# Привышение максимального значения! (Макс 3 цифры и больше 0)");
            return value;
        }
        public static String testRCPIDX(String value)
        {
            if (value.Length > 5)
                throw new OverflowException("#f#RCPIDX# Привышение максимального значения! (Ровно 5 символов должно быть)");
            if (value.Length < 5)
                throw new ArgumentException ("#f#RCPIDX# Неправильное значение! (Ровно 5 символов должно быть)");
            if (!Index.Test(value))
                throw new ArgumentException("#f#RCPIDX# Некорректное значение! (Индекс не найден в базе.)");

            return value;
        }
        public static String testRCADDR(String value)
        {
            if (value.Length > 80 || value.Length <=1)
                throw new OverflowException("#f#RCADDR# Привышение максимального значения! (Макс 80 символов и больше 0) Текущее = " + value.Length);
            
            return value;
        }

        public static String testRCNAME(String value)
        {
            if (value.Length > 40 || value.Length <= 1)
                throw new OverflowException("#f#RCNAME# Привышение максимального значения! (Макс 40 символов и больше 0) Текущее = " + value.Length);

            return value;
        }

        public static int testSNMTDC(int value)
        {
            if (value < 0 && value > 9)
                throw new OverflowException("#f#SNMTDC# Привышение максимального значения! (Макс 1 цифра и больше 0)");
            return value;
        }

        public static int testPSAPPC(int value)
        {
            if (value < 0 && value > 999999)
                throw new OverflowException("#f#PSAPPC# Привышение максимального значения! (Макс 6 цифр и больше 0)");
            return value;
        }

        public static int testPSCATC(int value)
        {
            if (value < 0 && value > 9999)
                throw new OverflowException("#f#PSCATC# Привышение максимального значения! (Макс 4 цифр и больше 0)");
            return value;
        }
        public static int testPSRAZC(int value)
        {
            if (value < 0 && value > 99)
                throw new OverflowException("#f#PSRAZC# Привышение максимального значения! (Макс 2 цифры и больше 0)");
            return value;
        }
        public static int testPSNOTC(Int64 value)
        {
            if (value < 0 && value > 999999999999)
                throw new OverflowException("#f#PSNOTC# Привышение максимального значения! (Макс 12 цифра и больше 0)");
            if (value>Int32.MaxValue)
                throw new OverflowException("#f#PSNOTC# Привышение 32бит! (Макс 12 цифра и больше 0) Тек="+ value.ToString());

            return (Int32)value;
        }
        public static int testPSWGT(int value)
        {
            if (value < 0 && value > 999999)
                throw new OverflowException("#f#PSWGT# Привышение максимального значения! (Макс 6 цифр и больше 0)");
            return value;
        }

        public static double testPKPRICE(double value)
        {
            if (value < 0 && value > 9999999999)
                throw new OverflowException("#f#PKPRICE# Привышение максимального значения! (Макс 10 цифр и больше 0)");
            return Math.Round(value,2);
        }
        public static double testAFTPAY(double value)
        {
            if (value < 0 && value > 9999999999)
                throw new OverflowException("#f#AFTPAY# Привышение максимального значения! (Макс 10 цифр и больше 0)");
            return Math.Round(value, 2);
        }

        public static String testPHONE(String value)
        {
            if (value.Length > 15)
                throw new OverflowException("#f#PHONE# Привышение максимального значения! (Макс 15 символов) Текущее = " + value.Length);

            return value;
        }
    }
}
