using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostReg
{
    public class PostRegItem
    {
        /// <summary>
        /// PSGVNO - номер по порядку макс 4 цифры.
        /// </summary>
        public int PSGVNO { get; set; }
        /// <summary>
        /// PSBARC - штрих-код, 13 символов.
        /// </summary>
        public String PSBARC { get; set; }
        /// <summary>
        /// RCCN3C - код страны 3 значный (804 Украина)
        /// </summary>
        public int RCCN3C { get; set; }
        /// <summary>
        /// RCPIDX - почтовый индекс 5 символов.
        /// </summary>
        public String RCPIDX { get; set; }
        /// <summary>
        /// RCADDR - адресс получателя 80 символов.
        /// </summary>
        public String RCADDR { get; set; }
        /// <summary>
        /// RCNAME - Кому (Получатель) 40 символов.
        /// </summary>
        public String RCNAME { get; set; }
        /// <summary>
        /// SNMTDC - ??? 1 цифра
        /// </summary>
        public int SNMTDC { get; set; }
        /// <summary>
        /// PSAPPC - ??? 6 цифр
        /// </summary>
        public int PSAPPC { get; set; }
        /// <summary>
        /// PSCATC - категория, 4 цифры
        /// </summary>
        public int PSCATC { get; set; }
        /// <summary>
        /// PSRAZC - разряд, 2 цифры
        /// </summary>
        public int PSRAZC { get; set; }
        /// <summary>
        /// PSNOTC - отметки, 12 цифр
        /// </summary>
        public int PSNOTC { get; set; }
        /// <summary>
        /// PSWGT - вес письма/посылки в гр. целое 6 цифр.
        /// </summary>
        public int PSWGT { get; set; }
        /// <summary>
        /// PKPRICE - стоимость, дробное 10 цифр, 2 дробных
        /// </summary>
        public double PKPRICE { get; set; }
        /// <summary>
        /// AFTPAY - наложный платеж? дробное 10 цифр, 2 дробных
        /// </summary>
        public double AFTPAY { get; set; }
        /// <summary>
        /// PHONE - телефон получателя, 15 символов.
        /// </summary>
        public String PHONE { get; set; }
    }
}
