using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public bool IsTrueFor(IDictionary<string, IDictionary<string, FuzzyValue>> inputValues, out float degreeOfMembership)
        {
            switch (op)
            {
                case Operator.And:
                    {
                        bool trueFor0 = premise0.IsTrueFor(inputValues, out float dom0);
                        bool trueFor1 = premise1.IsTrueFor(inputValues, out float dom1);
                        degreeOfMembership = Mathf.Min(dom0, dom1);
                        return trueFor0 && trueFor1;
                    }

                case Operator.Or:
                    {
                        bool trueFor0 = premise0.IsTrueFor(inputValues, out float dom0);
                        bool trueFor1 = premise1.IsTrueFor(inputValues, out float dom1);
                        degreeOfMembership = Mathf.Max(dom0, dom1);
                        return trueFor0 || trueFor1;
                    }

                case Operator.Not:
                    {
                        bool trueFor0 = premise0.IsTrueFor(inputValues, out float dom0);
                        if (trueFor0)
                        {
                            degreeOfMembership = 1 - dom0;
                        }
                        else
                        {
                            degreeOfMembership = 0;
                        }

                        return trueFor0;
                    }

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
