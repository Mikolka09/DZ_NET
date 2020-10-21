using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;

namespace ConsoleApplication1
{
    [Serializable]
    public class Payment : ISerializable
    {
        public static bool SerializationAll { get; set; } = true;
        public int PayOnDay { get; set; }
        public int CountDay { get; set; }
        public int PenaltyOnDay { get; set; }
        public int NumberDaysOverdue { get; set; }
        public int Penalty { get; set; }
        public int SumNoPenalty { get; }
        public int SumTotal { get; }

        public Payment()
        {

        }

        public Payment(int PayOnDay, int CountDay, int NumberDaysOverdue, int PenaltyOnDay)
        {
            this.PayOnDay = PayOnDay;
            this.CountDay = CountDay;
            this.NumberDaysOverdue = NumberDaysOverdue;
            this.PenaltyOnDay = PenaltyOnDay;
            Penalty = PayOnDay * CountDay;
            SumNoPenalty = PenaltyOnDay * NumberDaysOverdue;
            SumTotal = Penalty + SumNoPenalty;
        }

        protected Payment(SerializationInfo info, StreamingContext context)
        {
            if (!SerializationAll)
            {
                PayOnDay = info.GetInt32("PayOnDay");
                CountDay = info.GetInt32("CountDay");
                PenaltyOnDay = info.GetInt32("PenaltyOnDay");
                NumberDaysOverdue = info.GetInt32("NumberDaysOverdue");
            }
            else
            {
                PayOnDay = info.GetInt32("PayOnDay");
                CountDay = info.GetInt32("CountDay");
                PenaltyOnDay = info.GetInt32("PenaltyOnDay");
                NumberDaysOverdue = info.GetInt32("NumberDaysOverdue");
                Penalty = info.GetInt32("Penalty");
                SumNoPenalty = info.GetInt32("SumNoPenalty");
                SumTotal = info.GetInt32("SumTotal");
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (!SerializationAll)
            {
                info.AddValue("PayOnDay", PayOnDay);
                info.AddValue("CountDay", CountDay);
                info.AddValue("NumberDaysOverdue", NumberDaysOverdue);
                info.AddValue("PenaltyOnDay", PenaltyOnDay);
            }
            else
            {
                info.AddValue("PayOnDay", PayOnDay);
                info.AddValue("CountDay", CountDay);
                info.AddValue("PenaltyOnDay", PenaltyOnDay);
                info.AddValue("NumberDaysOverdue", NumberDaysOverdue);
                info.AddValue("Penalty", Penalty);
                info.AddValue("SumNoPenalty", SumNoPenalty);
                info.AddValue("SumTotal", SumTotal);
            }
        }


        public override string ToString()
        {
            return $"Оплата за день:                   {PayOnDay }\n" +
                   $"Количесвто дней:                  {CountDay }\n" +
                   $"Штраф за один день:               {PenaltyOnDay }\n" +
                   $"Количесвто дней задержки оплаты:  {NumberDaysOverdue }\n" +
                   $"Сумма к оплате без штрафа:        {SumNoPenalty }\n" +
                   $"Штраф:                            {Penalty}\n" +
                   $"Обшая сумма к оплате:             {SumTotal }\n";
        }

    }
}
