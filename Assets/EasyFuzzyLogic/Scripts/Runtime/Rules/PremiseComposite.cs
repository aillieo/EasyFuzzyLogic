using System;
using System.Collections;
using System.Collections.Generic;

namespace AillieoUtils.EasyFuzzyLogic
{
    [Serializable]
    public class PremiseComposite : IPremise
    {
        [Serializable]
        public enum Operator
        {
            And,
            Or,
            Not,
        }

        public Operator op;
        public IPremise premise0;
        public IPremise premise1;

        private PremiseComposite(Operator op, IPremise premise0, IPremise premise1)
        {
            this.op = op;
            this.premise0 = premise0;
            this.premise1 = premise1;
        }

        public static PremiseComposite And(IPremise premise0, IPremise premise1)
        {
            return new PremiseComposite(Operator.And, premise0, premise1);
        }

        public static PremiseComposite Or(IPremise premise0, IPremise premise1)
        {
            return new PremiseComposite(Operator.Or, premise0, premise1);
        }

        public static PremiseComposite Not(IPremise premise)
        {
            return new PremiseComposite(Operator.Not, premise, default);
        }

        public bool IsTrueFor(IDictionary<string, IDictionary<string, FuzzyValue>> inputValues)
        {
            throw new NotImplementedException();
        }
    }
}
