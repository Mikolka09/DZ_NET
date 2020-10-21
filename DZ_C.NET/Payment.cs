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
        private int penalty;
        public int Penalty
        {
            get { return penalty = PayOnDay * CountDay; }
            set{}
        }
        private int sumNoPenalty;
        public int SumNoPenalty
        {
            get { return sumNoPenalty = PenaltyOnDay * NumberDaysOverdue; }
            set{}
        }
        private int sumTotal;
        public int SumTotal
        {
            get { return sumTotal = Penalty + SumNoPenalty; }
            set{}
        }
        public Payment()
        {

        }

        public Payment(int PayOnDay, int CountDay, int NumberDaysOverdue, int PenaltyOnDay)
        {
            this.PayOnDay = PayOnDay;
            this.CountDay = CountDay;
            this.NumberDaysOverdue = NumberDaysOverdue;
            this.PenaltyOnDay = PenaltyOnDay;
            penalty = PayOnDay * CountDay;
            sumNoPenalty = PenaltyOnDay * NumberDaysOverdue;
            sumTotal = Penalty + SumNoPenalty;
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
                penalty = info.GetInt32("Penalty");
                sumNoPenalty = info.GetInt32("SumNoPenalty");
                sumTotal = info.GetInt32("SumTotal");
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
